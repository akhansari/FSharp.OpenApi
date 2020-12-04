namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type ComponentsBuilder () =

    member _.Yield _ =
        OpenApiComponents ()

    [<CustomOperation "schemas">]
    member _.Schemas (state: OpenApiComponents, value: KVs<string, OpenApiSchema>) =
        value |> List.iter state.Schemas.Add
        state

    [<CustomOperation "responses">]
    member _.Responses (state: OpenApiComponents, value: KVs<string, OpenApiResponse>) =
        value |> List.iter state.Responses.Add
        state

    [<CustomOperation "parameters">]
    member _.Parameters (state: OpenApiComponents, value: KVs<string, OpenApiParameter>) =
        value |> List.iter state.Parameters.Add
        state

    [<CustomOperation "examples">]
    member _.Examples (state: OpenApiComponents, value: KVs<string, OpenApiExample>) =
        value |> List.iter state.Examples.Add
        state

    [<CustomOperation "requestBodies">]
    member _.RequestBodies (state: OpenApiComponents, value: KVs<string, OpenApiRequestBody>) =
        value |> List.iter state.RequestBodies.Add
        state

    [<CustomOperation "headers">]
    member _.Headers (state: OpenApiComponents, value: KVs<string, OpenApiHeader>) =
        value |> List.iter state.Headers.Add
        state

    [<CustomOperation "securitySchemes">]
    member _.SecuritySchemes (state: OpenApiComponents, value: KVs<string, OpenApiSecurityScheme>) =
        value |> List.iter state.SecuritySchemes.Add
        state

    [<CustomOperation "links">]
    member _.Links (state: OpenApiComponents, value: KVs<string, OpenApiLink>) =
        value |> List.iter state.Links.Add
        state

    [<CustomOperation "callbacks">]
    member _.Callbacks (state: OpenApiComponents, value: KVs<string, OpenApiCallback>) =
        value |> List.iter state.Callbacks.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiComponents, value: KVs<string, 'T>) =
        value |> List.iter state.Extensions.Add
        state
