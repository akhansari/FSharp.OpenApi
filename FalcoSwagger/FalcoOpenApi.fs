module Falco.OpenApi

open System.Net
open System.Text.Json
open Microsoft.OpenApi
open Microsoft.OpenApi.Any
open Microsoft.OpenApi.Extensions
open Microsoft.OpenApi.Models
open Falco.Core

type OpenApiOperationBuilder () =
    member _.Yield _ = OpenApiOperation ()
    [<CustomOperation "summary">]
    member _.Summary (state: OpenApiOperation, value) = state.Summary <- value; state
    [<CustomOperation "description">]
    member _.Description (state: OpenApiOperation, value) = state.Description <- value; state
    [<CustomOperation "tags">]
    member _.Tags (state: OpenApiOperation, values: OpenApiTag list) = List.iter state.Tags.Add values; state
    [<CustomOperation "parameters">]
    member _.Parameters (state: OpenApiOperation, values: OpenApiParameter list) = List.iter state.Parameters.Add values; state
    [<CustomOperation "requestBody">]
    member _.RequestBody (state: OpenApiOperation, value: OpenApiRequestBody) = state.RequestBody <- value; state
    [<CustomOperation "responses">]
    member _.Responses (state: OpenApiOperation, keyValues: (HttpStatusCode * OpenApiResponse) list) =
        for (key, value) in keyValues do state.Responses.Add (string key, value)
        state
let openApiOperation = OpenApiOperationBuilder ()

type OpenApiResponseBuilder () =
    member _.Yield _ = OpenApiResponse ()
    [<CustomOperation "description">]
    member _.Description (state: OpenApiResponse, value) = state.Description <- value; state
    [<CustomOperation "jsonContent">]
    member _.JsonContent (state: OpenApiResponse, getValue: unit -> OpenApiString) =
        let mediaType = OpenApiMediaType (Example = getValue ())
        state.Content.Add ("application/json", mediaType)
        state
let openApiResponse = OpenApiResponseBuilder ()

type OpenApiMediaTypeBuilder () =
    member _.Yield _ = OpenApiMediaType ()
let openApiMediaType = OpenApiMediaTypeBuilder ()

type private HttpVerb with
    member this.toOperationType () =
        match this with
        | GET -> OperationType.Get
        | HEAD -> OperationType.Head
        | POST -> OperationType.Post
        | PUT -> OperationType.Put
        | PATCH -> OperationType.Patch
        | DELETE -> OperationType.Delete
        | OPTIONS -> OperationType.Options
        | TRACE -> OperationType.Trace
        | ANY -> failwith "HttpVerb.ANY is not supported"

type OpenApiFactory =
    { JsonSerializerOptions: JsonSerializerOptions
      Document: OpenApiDocument }

[<RequireQualifiedAccess>]
module OpenApiFactory =

    let create (jsonSerializerOptions: JsonSerializerOptions) title version =
        jsonSerializerOptions.WriteIndented <- true
        { JsonSerializerOptions = jsonSerializerOptions
          Document =
            OpenApiDocument
                ( Info = OpenApiInfo (Title = title, Version = version),
                  Paths = OpenApiPaths () ) }

    let serialize (gen: OpenApiFactory) =
        gen.Document.Serialize (OpenApiSpecVersion.OpenApi3_0, OpenApiFormat.Json)

    let specify (gen: OpenApiFactory) operation (context: HttpEndpoint) =
        let pathItem = OpenApiPathItem ()
        pathItem.Operations.Add (context.Verb.toOperationType (), operation)
        gen.Document.Paths.Add (context.Pattern, pathItem)
        context

    let makeJsonContent (gen: OpenApiFactory) (content: 'T) () =
        JsonSerializer.Serialize (content, gen.JsonSerializerOptions)
        |> OpenApiString
