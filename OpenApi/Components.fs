namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type ComponentsBuilder () =

    member _.Yield _ =
        OpenApiComponents ()

    [<CustomOperation "addSchema">]
    member _.Schemas (state: OpenApiComponents, key, value) =
        state.Schemas.Add (key, value)
        state

    [<CustomOperation "addResponse">]
    member _.Responses (state: OpenApiComponents, key, value) =
        state.Responses.Add (key, value)
        state

    [<CustomOperation "addParameter">]
    member _.Parameters (state: OpenApiComponents, key, value) =
        state.Parameters.Add (key, value)
        state

    [<CustomOperation "addExample">]
    member _.Examples (state: OpenApiComponents, key, value) =
        state.Examples.Add (key, value)
        state

    [<CustomOperation "addRequestBody">]
    member _.RequestBodies (state: OpenApiComponents, key, value) =
        state.RequestBodies.Add (key, value)
        state

    [<CustomOperation "addHeader">]
    member _.Headers (state: OpenApiComponents, key, value) =
        state.Headers.Add (key, value)
        state

    [<CustomOperation "addSecurityScheme">]
    member _.SecuritySchemes (state: OpenApiComponents, key, value) =
        state.SecuritySchemes.Add (key, value)
        state

    [<CustomOperation "addLink">]
    member _.Links (state: OpenApiComponents, key, value) =
        state.Links.Add (key, value)
        state

    [<CustomOperation "addCallback">]
    member _.Callbacks (state: OpenApiComponents, key, value) =
        state.Callbacks.Add (key, value)
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiComponents, key, value) =
        state.Extensions.Add (key, value)
        state
