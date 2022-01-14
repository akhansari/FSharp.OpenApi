module FalcoOpenApi

open System
open Microsoft.OpenApi.Models
open Falco
open OpenApi

let toOperation = function
    | GET     -> OperationType.Get
    | HEAD    -> OperationType.Head
    | POST    -> OperationType.Post
    | PUT     -> OperationType.Put
    | PATCH   -> OperationType.Patch
    | DELETE  -> OperationType.Delete
    | OPTIONS -> OperationType.Options
    | TRACE   -> OperationType.Trace
    | ANY     -> NotSupportedException "HttpVerb" |> raise

let addOperation (factory: OpenApiFactory) (endpoint: HttpEndpoint) operation =
    let httpVerb = endpoint.Handlers |> List.head |> fst |> toOperation
    factory.AddOperation httpVerb endpoint.Pattern operation
    endpoint
