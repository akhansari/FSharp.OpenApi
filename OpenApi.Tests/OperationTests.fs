module OperationTests

open Microsoft.OpenApi
open Xunit
open OpenApi

[<Fact>]
let tags () =
    let operation = apiOperation {
        tags [ "test" ]
    }
    "tags:
    - test
    responses: { }" =~! toYaml operation
    
[<Fact>]
let tagsRef () =
    let operation = apiOperation {
        tagReferences [ OpenApiTagReference "test" ]
    }
    "tags:
    - test
    responses: { }" =~! toYaml operation
    
[<Fact>]
let summary () =
    let operation = apiOperation {
        summary "summary test"
    }
    "summary: summary test
    responses: { }" =~! toYaml operation
    
[<Fact>]
let description () =
    let operation = apiOperation {
        description "desc test"
    }
    "description: desc test
    responses: { }" =~! toYaml operation
