
## FSharp OpenAPI [![NuGet Status](https://img.shields.io/nuget/v/FSharp.OpenApi.svg)](https://www.nuget.org/packages/FSharp.OpenApi)

F# Wrapper for [OpenAPI.NET SDK](https://github.com/microsoft/OpenAPI.NET).

- Describe API specifications with computation expressions.
- Provide helpers for F# libraries to write specifications and exposing them to Swagger UI.

This is still a work in progress project and breaking changes could be frequent.\
Contributions are welcome.

### Example Usage

Creating an OpenAPI document

```fsharp
let document =
    apiDocument {
        info (apiInfo {
            version "1.0.0"
            title "Swagger Petstore (Simple)"
        })
        servers [
            apiServer {
                url "http://petstore.swagger.io/api"
            }
        ]
        paths [
            "/pets", apiPathItem {
                operations [
                    OperationType.Get, apiOperation {
                        description "Returns all pets from the system that the user has access to"
                        responses [
                            HttpStatusCode.OK, apiResponse {
                                description "OK"
                            }
                        ]
                    }
                ]
            }
        ]
    }

let outputString =
    document.Serialize (OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Json)
```
