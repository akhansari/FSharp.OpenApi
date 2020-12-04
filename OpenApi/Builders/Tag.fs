namespace OpenApi.Builders

open Microsoft.OpenApi.Models

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

    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiTag, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiTag, value: KVs<string, 'T>) =
        value |> List.iter state.Extensions.Add
        state

    [<CustomOperation "unresolvedReference">]
    member _.UnresolvedReference (state: OpenApiTag, value) =
        state.UnresolvedReference <- value
        state

    [<CustomOperation "reference">]
    member _.Reference (state: OpenApiTag, value) =
        state.Reference <- value
        state
