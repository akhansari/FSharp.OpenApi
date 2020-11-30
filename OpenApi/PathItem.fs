namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type PathItemBuilder () =

    member _.Yield _ =
        OpenApiPathItem ()

    [<CustomOperation "summary">]
    member _.Summary (state: OpenApiPathItem, value) =
        state.Summary <- value
        state

    [<CustomOperation "description">]
    member _.Description (state: OpenApiPathItem, value) =
        state.Description <- value
        state

    [<CustomOperation "addOperation">]
    member _.Operations (state: OpenApiPathItem, key, value) =
        state.Operations.Add (key, value)
        state
        
    [<CustomOperation "addServer">]
    member _.Servers (state: OpenApiPathItem, value) =
        state.Servers.Add value
        state

    [<CustomOperation "addParameter">]
    member _.Parameters (state: OpenApiPathItem, value) =
        state.Parameters.Add value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiPathItem, key, value) =
        state.Extensions.Add (key, value)
        state
