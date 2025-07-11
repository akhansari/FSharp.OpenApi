namespace OpenApi.Builders

open System.Collections.Generic
open Microsoft.OpenApi

type ComponentsBuilder () =

    member _.Yield _ =
        OpenApiComponents ()

    [<CustomOperation "schemas">]
    member _.Schemas (state: OpenApiComponents, values: KVs<_, OpenApiSchema>) =
        if isNull state.Schemas then state.Schemas <- Dictionary()
        values |> Seq.iter state.Schemas.Add
        state

    [<CustomOperation "responses">]
    member _.Responses (state: OpenApiComponents, values: KVs<_, OpenApiResponse>) =
        if isNull state.Responses then state.Responses <- Dictionary()
        values |> Seq.iter state.Responses.Add
        state

    [<CustomOperation "parameters">]
    member _.Parameters (state: OpenApiComponents, values: KVs<_, OpenApiParameter>) =
        if isNull state.Parameters then state.Parameters <- Dictionary()
        values |> Seq.iter state.Parameters.Add
        state

    [<CustomOperation "examples">]
    member _.Examples (state: OpenApiComponents, values: KVs<_, OpenApiExample>) =
        if isNull state.Examples then state.Examples <- Dictionary()
        values |> Seq.iter state.Examples.Add
        state

    [<CustomOperation "requestBodies">]
    member _.RequestBodies (state: OpenApiComponents, values: KVs<_, OpenApiRequestBody>) =
        if isNull state.RequestBodies then state.RequestBodies <- Dictionary()
        values |> Seq.iter state.RequestBodies.Add
        state

    [<CustomOperation "headers">]
    member _.Headers (state: OpenApiComponents, values: KVs<_, OpenApiHeader>) =
        if isNull state.Headers then state.Headers <- Dictionary()
        values |> Seq.iter state.Headers.Add
        state

    [<CustomOperation "securitySchemes">]
    member _.SecuritySchemes (state: OpenApiComponents, values: KVs<_, OpenApiSecurityScheme>) =
        if isNull state.SecuritySchemes then state.SecuritySchemes <- Dictionary()
        values |> Seq.iter state.SecuritySchemes.Add
        state

    [<CustomOperation "links">]
    member _.Links (state: OpenApiComponents, values: KVs<_, OpenApiLink>) =
        if isNull state.Links then state.Links <- Dictionary()
        values |> Seq.iter state.Links.Add
        state

    [<CustomOperation "callbacks">]
    member _.Callbacks (state: OpenApiComponents, values: KVs<_, OpenApiCallback>) =
        if isNull state.Callbacks then state.Callbacks <- Dictionary()
        values |> Seq.iter state.Callbacks.Add
        state

    [<CustomOperation "pathItems">]
    member _.PathItems (state: OpenApiComponents, values: KVs<_, OpenApiPathItem>) =
        if isNull state.PathItems then state.PathItems <- Dictionary()
        values |> Seq.iter state.PathItems.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiComponents, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
