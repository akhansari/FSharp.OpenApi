namespace OpenApi.Builders

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

    [<CustomOperation "addServer">]
    member _.Servers (state: OpenApiDocument, value) =
        state.Servers.Add value
        state

    [<CustomOperation "paths">]
    member _.Paths (state: OpenApiDocument, value) =
        state.Paths <- value
        state

    [<CustomOperation "components">]
    member _.Components (state: OpenApiDocument, value) =
        state.Components <- value
        state

    [<CustomOperation "addSecurityRequirement">]
    member _.SecurityRequirements (state: OpenApiDocument, value) =
        state.SecurityRequirements.Add value
        state

    [<CustomOperation "addTag">]
    member _.Tags (state: OpenApiDocument, value) =
        state.Tags.Add value
        state

    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiDocument, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiDocument, key, value) =
        state.Extensions.Add (key, value)
        state
