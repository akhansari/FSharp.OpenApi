namespace OpenApi

open System
open System.Text.Json
open Microsoft.OpenApi
open Microsoft.OpenApi.Extensions
open Microsoft.OpenApi.Models
open OpenApi.Expressions

[<NoComparison>]
type OpenApiFactory =
    { Document: OpenApiDocument
      JsonSerializerOptions: JsonSerializerOptions }

    member this.Version =
        this.Document.Info.Version

    member this.SpecificationUrl =
        if String.IsNullOrWhiteSpace this.Version
        then "/openapi/v1.json"
        else $"/openapi/{this.Version}.json"

    member this.Serialize (?version, ?format) =
        let version = defaultArg version OpenApiSpecVersion.OpenApi3_1
        let format = defaultArg format OpenApiFormat.Json
        this.Document.SerializeAsync(version, format) |> Async.AwaitTask |> Async.RunSynchronously 

    member this.MakeJsonContent content =
        JsonSerializer.SerializeToNode(content, this.JsonSerializerOptions)

    member this.Write (writer: string -> 'T, ?version, ?format) =
        this.Serialize(?version = version, ?format = format)
        |> writer

    member this.AddOperation operationType path operation =
        if this.Document.Paths.ContainsKey path then
            this.Document.Paths[path].Operations.Add (operationType, operation)
        else
            let item = apiPathItem { operations [ operationType, operation ] }
            this.Document.Paths.Add (path, item)

[<RequireQualifiedAccess>]
module OpenApiFactory =

    let simpleDocument docTitle docVersion =
        apiDocument {
            info (apiInfo { title docTitle; version docVersion })
        }

    let create jsonSerializerOptions document =
        { JsonSerializerOptions = jsonSerializerOptions
          Document = document }
