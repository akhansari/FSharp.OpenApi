module OperationTests

open System.Net
open Microsoft.OpenApi
open Xunit
open OpenApi

[<Fact>]
let ``tags converts names to tag references`` () =
    let operation = apiOperation {
        tags [ "test" ]
    }

    let tag = Assert.Single operation.Tags
    Assert.Equal("test", tag.Name)

[<Fact>]
let ``tagReferences preserves supplied references`` () =
    let expected = OpenApiTagReference "test"

    let operation = apiOperation {
        tagReferences [ expected ]
    }

    Assert.Same(expected, Assert.Single operation.Tags)

[<Fact>]
let ``summary sets Summary`` () =
    let operation = apiOperation {
        summary "summary test"
    }

    Assert.Equal("summary test", operation.Summary)

[<Fact>]
let ``description sets Description`` () =
    let operation = apiOperation {
        description "desc test"
    }

    Assert.Equal("desc test", operation.Description)

[<Fact>]
let ``responses converts an HTTP status code to its numeric key`` () =
    let expected = OpenApiResponse()

    let operation = apiOperation {
        responses [ HttpStatusCode.Created, expected ]
    }

    Assert.Same(expected, operation.Responses["201"])

[<Fact>]
let ``responses preserves a string response key`` () =
    let expected = OpenApiResponse()

    let operation = apiOperation {
        responses [ "default", expected ]
    }

    Assert.Same(expected, operation.Responses["default"])

[<Fact>]
let ``repeated parameters operations accumulate values`` () =
    let first = OpenApiParameter()
    let second = OpenApiParameter()

    let operation = apiOperation {
        parameters [ first ]
        parameters [ second ]
    }

    Assert.Equal(2, operation.Parameters.Count)
    Assert.Same(first, operation.Parameters[0])
    Assert.Same(second, operation.Parameters[1])
