namespace OpenApi.Builders

open System.Collections.Generic
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
        if state.Servers = null then state.Servers <- List()
        Seq.iter state.Servers.Add value
        state

    [<CustomOperation "paths">]
    member _.Paths (state: OpenApiDocument, value) =
        Seq.iter state.Paths.Add value
        state

    [<CustomOperation "webhooks">]
    member _.Webhooks (state: OpenApiDocument, values: KVs<_, OpenApiPathItem>) =
        if isNull state.Webhooks then state.Webhooks <- Dictionary()
        values |> Seq.iter state.Webhooks.Add
        state

    [<CustomOperation "components">]
    member _.Components (state: OpenApiDocument, value) =
        state.Components <- value
        state

    [<CustomOperation "security">]
    member _.security (state: OpenApiDocument, values: OpenApiSecurityRequirement seq) =
        if isNull state.Security then state.Security <- List()
        values |> Seq.iter state.Security.Add
        state

    [<CustomOperation "tags">]
    member _.Tags (state: OpenApiDocument, values) =
        if state.Tags = null then state.Tags <- HashSet()
        values |> Seq.iter (state.Tags.Add >> ignore)
        state

    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiDocument, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiDocument, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state

    [<CustomOperation "metadata">]
    member _.Metadata (state: OpenApiDocument, values: KVs<_, obj>) =
        if isNull state.Metadata then state.Metadata <- Dictionary()
        values |> Seq.iter state.Metadata.Add
        state
