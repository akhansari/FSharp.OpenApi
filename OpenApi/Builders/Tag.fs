namespace OpenApi.Builders

open System.Collections.Generic
open Microsoft.OpenApi

type TagBuilder () =

    member _.Yield _ =
        OpenApiTag ()

    [<CustomOperation "name">]
    member _.Name (state: OpenApiTag, value) =
        state.Name <- value
        state

    [<CustomOperation "description">]
    member _.Description (state: OpenApiTag, value) =
        state.Description <- value
        state

    [<CustomOperation "summary">]
    member _.Summary (state: OpenApiTag, value) =
        state.Summary <- value
        state

    [<CustomOperation "parent">]
    member _.Parent (state: OpenApiTag, value) =
        state.Parent <- OpenApiTagReference value
        state

    [<CustomOperation "kind">]
    member _.Kind (state: OpenApiTag, value) =
        state.Kind <- value
        state

    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiTag, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiTag, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
