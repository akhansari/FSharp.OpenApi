namespace OpenApi.Builders

open Microsoft.OpenApi

type DocumentBuilder () =

    member _.Yield _ =
        let doc = OpenApiDocument ()
        doc.Paths <- OpenApiPaths ()
        doc

    [<CustomOperation "workspace">]
    member _.Workspace (state: OpenApiDocument, value) =
        state.Workspace <- value
        state

    [<CustomOperation "info">]
    member _.Info (state: OpenApiDocument, value) =
        state.Info <- value
        state

    [<CustomOperation "jsonSchemaDialect">]
    member _.JsonSchemaDialect (state: OpenApiDocument, value) =
        state.JsonSchemaDialect <- value
        state

    [<CustomOperation "servers">]
    member _.Servers (state: OpenApiDocument, value) =
        Seq.iter state.Servers.Add value
        state

    [<CustomOperation "paths">]
    member _.Paths (state: OpenApiDocument, value) =
        Seq.iter state.Paths.Add value
        state

    [<CustomOperation "webhooks">]
    member _.Webhooks (state: OpenApiDocument, values: KVs<_, OpenApiPathItem>) =
        values |> Seq.iter state.Webhooks.Add
        state

    [<CustomOperation "components">]
    member _.Components (state: OpenApiDocument, value) =
        state.Components <- value
        state

    [<CustomOperation "security">]
    member _.security (state: OpenApiDocument, values: OpenApiSecurityRequirement seq) =
        values |> Seq.iter state.Security.Add
        state

    [<CustomOperation "tags">]
    member _.Tags (state: OpenApiDocument, values) =
        values |> Seq.iter (state.Tags.Add >> ignore)
        state

    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiDocument, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiDocument, values: KVs<_, IOpenApiExtension>) =
        values |> Seq.iter state.Extensions.Add
        state

    [<CustomOperation "metadata">]
    member _.Metadata (state: OpenApiDocument, values: KVs<_, obj>) =
        values |> Seq.iter state.Metadata.Add
        state
