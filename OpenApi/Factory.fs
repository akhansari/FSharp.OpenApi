namespace OpenApi

open System
open System.Text.Json
open Microsoft.OpenApi
open Microsoft.OpenApi.Any
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
        then "/swagger.json"
        else $"/swagger/{this.Version}/swagger.json"

    member this.Serialize () =
        this.Document.Serialize (OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Json)

    member this.MakeJsonContent content =
        JsonSerializer.Serialize (content, this.JsonSerializerOptions)
        |> OpenApiString

    member this.Write (writer: string -> 'T) =
        this.Serialize () |> writer

    member this.AddOperation operationType path operation =
        if this.Document.Paths.ContainsKey path then
            this.Document.Paths.[path].Operations.Add (operationType, operation)
        else
            let item = apiPathItem { operations [ operationType, operation ] }
            this.Document.Paths.Add (path, item)

[<RequireQualifiedAccess>]
module OpenApiFactory =

    let create (jsonSerializerOptions: JsonSerializerOptions) docTitle docVersion =
        jsonSerializerOptions.WriteIndented <- true
        let document =
            apiDocument {
                info (apiInfo { title docTitle; version docVersion })
            }
        { JsonSerializerOptions = jsonSerializerOptions
          Document = document }
