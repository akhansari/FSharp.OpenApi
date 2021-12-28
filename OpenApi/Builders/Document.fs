namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type DocumentBuilder () =

    member _.Yield _ =
        let doc = OpenApiDocument ()
        doc.Paths <- OpenApiPaths ()
        doc

    [<CustomOperation "info">]
    member _.Info (state: OpenApiDocument, value) =
        state.Info <- value
        state

    [<CustomOperation "servers">]
    member _.Servers (state: OpenApiDocument, value) =
        Seq.iter state.Servers.Add value
        state

    [<CustomOperation "paths">]
    member _.Paths (state: OpenApiDocument, value) =
        Seq.iter state.Paths.Add value
        state

    [<CustomOperation "components">]
    member _.Components (state: OpenApiDocument, value) =
        state.Components <- value
        state

    [<CustomOperation "securityRequirements">]
    member _.SecurityRequirements (state: OpenApiDocument, value) =
        Seq.iter state.SecurityRequirements.Add value
        state

    [<CustomOperation "tags">]
    member _.Tags (state: OpenApiDocument, value) =
        Seq.iter state.Tags.Add value
        state

    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiDocument, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiDocument, value: KVs<_, Interfaces.IOpenApiExtension>) =
        value |> Seq.iter state.Extensions.Add
        state
