namespace OpenApi

open System.Text.Json
open Microsoft.OpenApi
open Microsoft.OpenApi.Any
open Microsoft.OpenApi.Extensions
open Microsoft.OpenApi.Models
open OpenApi.Expressions

type OpenApiFactory =
    { JsonSerializerOptions: JsonSerializerOptions
      Document: OpenApiDocument }

    member this.Version =
        this.Document.Info.Version

    member this.SpecificationUrl =
        $"/api/specifications/{this.Document.Info.Version}"

    member this.Serialize () =
        this.Document.Serialize (OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Json)

    member this.MakeJsonContent content =
        JsonSerializer.Serialize (content, this.JsonSerializerOptions)
        |> OpenApiString

    member this.Write (writer: string -> 'T) =
        this.Serialize () |> writer

    member this.AddOperation operationType path operation =
        let item = pathItem { addOperation operationType operation }
        this.Document.Paths.Add (path, item)

[<RequireQualifiedAccess>]
module OpenApiFactory =

    let create (jsonSerializerOptions: JsonSerializerOptions) title version =
        jsonSerializerOptions.WriteIndented <- true
        { JsonSerializerOptions = jsonSerializerOptions
          Document =
            OpenApiDocument
                ( Info = OpenApiInfo (Title = title, Version = version),
                  Paths = OpenApiPaths () ) }
