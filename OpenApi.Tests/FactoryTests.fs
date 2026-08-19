module FactoryTests

open System.Net.Http
open System.Text.Json
open Microsoft.OpenApi
open OpenApi
open Xunit

type Example =
    { FirstName: string }

let private createFactory version =
    OpenApiFactory.simpleDocument "Example API" version
    |> OpenApiFactory.create (JsonSerializerOptions())

[<Fact>]
let ``Version returns the document version`` () =
    let factory = createFactory "2.1.0"

    Assert.Equal("2.1.0", factory.Version)

[<Fact>]
let ``SpecificationUrl includes a non-empty document version`` () =
    let factory = createFactory "2.1.0"

    Assert.Equal("/openapi/2.1.0.json", factory.SpecificationUrl)

[<Theory>]
[<InlineData(null)>]
[<InlineData("")>]
[<InlineData("   ")>]
let ``SpecificationUrl falls back for a missing document version`` (version: string) =
    let factory = createFactory version

    Assert.Equal("/openapi/v1.json", factory.SpecificationUrl)

[<Fact>]
let ``AddOperation creates a missing path`` () =
    let factory = createFactory "1.0.0"
    let expected = OpenApiOperation()

    factory.AddOperation HttpMethod.Get "/pets" expected

    Assert.Same(expected, factory.Document.Paths["/pets"].Operations[HttpMethod.Get])

[<Fact>]
let ``AddOperation initializes operations on an existing empty path`` () =
    let factory = createFactory "1.0.0"
    let pathItem = apiPathItem { summary "Pets" }
    let expected = OpenApiOperation()
    factory.Document.Paths.Add("/pets", pathItem)

    factory.AddOperation HttpMethod.Get "/pets" expected

    Assert.Equal("Pets", factory.Document.Paths["/pets"].Summary)
    Assert.Same(expected, factory.Document.Paths["/pets"].Operations[HttpMethod.Get])

[<Fact>]
let ``AddOperation accumulates methods on an existing path`` () =
    let factory = createFactory "1.0.0"
    let getOperation = OpenApiOperation()
    let postOperation = OpenApiOperation()

    factory.AddOperation HttpMethod.Get "/pets" getOperation
    factory.AddOperation HttpMethod.Post "/pets" postOperation

    Assert.Equal(2, factory.Document.Paths["/pets"].Operations.Count)
    Assert.Same(getOperation, factory.Document.Paths["/pets"].Operations[HttpMethod.Get])
    Assert.Same(postOperation, factory.Document.Paths["/pets"].Operations[HttpMethod.Post])

[<Fact>]
let ``MakeJsonContent uses the configured serializer options`` () =
    let options = JsonSerializerOptions(PropertyNamingPolicy = JsonNamingPolicy.CamelCase)
    let factory =
        OpenApiFactory.simpleDocument "Example API" "1.0.0"
        |> OpenApiFactory.create options

    let actual = factory.MakeJsonContent { FirstName = "Ada" }

    Assert.Equal("Ada", actual["firstName"].GetValue<string>())
    Assert.Null(actual["FirstName"])
