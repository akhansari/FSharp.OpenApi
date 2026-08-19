module ContentBuilderTests

open System.Text.Json.Nodes
open Microsoft.OpenApi
open OpenApi
open Xunit

[<Fact>]
let ``request body jsonContent creates JSON media content`` () =
    let example = JsonObject()

    let requestBody = apiRequestBody {
        jsonContent example
    }

    let mediaType = Assert.Single(requestBody.Content).Value
    Assert.True(requestBody.Content.ContainsKey "application/json")
    Assert.Same(example, mediaType.Example)
    Assert.NotNull mediaType.Schema

[<Fact>]
let ``response jsonContent creates JSON media content`` () =
    let example = JsonObject()

    let response = apiResponse {
        jsonContent example
    }

    let mediaType = Assert.Single(response.Content).Value
    Assert.True(response.Content.ContainsKey "application/json")
    Assert.Same(example, mediaType.Example)

[<Fact>]
let ``content and jsonContent accumulate distinct media types`` () =
    let textMediaType = OpenApiMediaType()
    let example = JsonObject()

    let response = apiResponse {
        content [ "text/plain", textMediaType ]
        jsonContent example
    }

    Assert.Equal(2, response.Content.Count)
    Assert.Same(textMediaType, response.Content["text/plain"])
    Assert.Same(example, response.Content["application/json"].Example)
