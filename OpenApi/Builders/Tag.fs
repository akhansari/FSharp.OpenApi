namespace OpenApi.Builders

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

    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiTag, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiTag, values: KVs<_, IOpenApiExtension>) =
        values |> Seq.iter state.Extensions.Add
        state
