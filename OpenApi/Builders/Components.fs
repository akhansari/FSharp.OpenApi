namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type ComponentsBuilder () =

    member _.Yield _ =
        OpenApiComponents ()

    [<CustomOperation "schemas">]
    member _.Schemas (state: OpenApiComponents, value: KVs<_, OpenApiSchema>) =
        value |> Seq.iter state.Schemas.Add
        state

    [<CustomOperation "responses">]
    member _.Responses (state: OpenApiComponents, value: KVs<_, OpenApiResponse>) =
        value |> Seq.iter state.Responses.Add
        state

    [<CustomOperation "parameters">]
    member _.Parameters (state: OpenApiComponents, value: KVs<_, OpenApiParameter>) =
        value |> Seq.iter state.Parameters.Add
        state

    [<CustomOperation "examples">]
    member _.Examples (state: OpenApiComponents, value: KVs<_, OpenApiExample>) =
        value |> Seq.iter state.Examples.Add
        state

    [<CustomOperation "requestBodies">]
    member _.RequestBodies (state: OpenApiComponents, value: KVs<_, OpenApiRequestBody>) =
        value |> Seq.iter state.RequestBodies.Add
        state

    [<CustomOperation "headers">]
    member _.Headers (state: OpenApiComponents, value: KVs<_, OpenApiHeader>) =
        value |> Seq.iter state.Headers.Add
        state

    [<CustomOperation "securitySchemes">]
    member _.SecuritySchemes (state: OpenApiComponents, value: KVs<_, OpenApiSecurityScheme>) =
        value |> Seq.iter state.SecuritySchemes.Add
        state

    [<CustomOperation "links">]
    member _.Links (state: OpenApiComponents, value: KVs<_, OpenApiLink>) =
        value |> Seq.iter state.Links.Add
        state

    [<CustomOperation "callbacks">]
    member _.Callbacks (state: OpenApiComponents, value: KVs<_, OpenApiCallback>) =
        value |> Seq.iter state.Callbacks.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiComponents, value: KVs<_, Interfaces.IOpenApiExtension>) =
        value |> Seq.iter state.Extensions.Add
        state
