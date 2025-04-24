namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type ComponentsBuilder () =

    member _.Yield _ =
        OpenApiComponents ()

    [<CustomOperation "schemas">]
    member _.Schemas (state: OpenApiComponents, values: KVs<_, OpenApiSchema>) =
        values |> Seq.iter state.Schemas.Add
        state

    [<CustomOperation "responses">]
    member _.Responses (state: OpenApiComponents, values: KVs<_, OpenApiResponse>) =
        values |> Seq.iter state.Responses.Add
        state

    [<CustomOperation "parameters">]
    member _.Parameters (state: OpenApiComponents, values: KVs<_, OpenApiParameter>) =
        values |> Seq.iter state.Parameters.Add
        state

    [<CustomOperation "examples">]
    member _.Examples (state: OpenApiComponents, values: KVs<_, OpenApiExample>) =
        values |> Seq.iter state.Examples.Add
        state

    [<CustomOperation "requestBodies">]
    member _.RequestBodies (state: OpenApiComponents, values: KVs<_, OpenApiRequestBody>) =
        values |> Seq.iter state.RequestBodies.Add
        state

    [<CustomOperation "headers">]
    member _.Headers (state: OpenApiComponents, values: KVs<_, OpenApiHeader>) =
        values |> Seq.iter state.Headers.Add
        state

    [<CustomOperation "securitySchemes">]
    member _.SecuritySchemes (state: OpenApiComponents, values: KVs<_, OpenApiSecurityScheme>) =
        values |> Seq.iter state.SecuritySchemes.Add
        state

    [<CustomOperation "links">]
    member _.Links (state: OpenApiComponents, values: KVs<_, OpenApiLink>) =
        values |> Seq.iter state.Links.Add
        state

    [<CustomOperation "callbacks">]
    member _.Callbacks (state: OpenApiComponents, values: KVs<_, OpenApiCallback>) =
        values |> Seq.iter state.Callbacks.Add
        state

    [<CustomOperation "pathItems">]
    member _.PathItems (state: OpenApiComponents, values: KVs<_, OpenApiPathItem>) =
        values |> Seq.iter state.PathItems.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiComponents, values: KVs<_, Interfaces.IOpenApiExtension>) =
        values |> Seq.iter state.Extensions.Add
        state
