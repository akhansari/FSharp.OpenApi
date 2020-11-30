module GiraffeOpenApi

open System
open Microsoft.OpenApi.Models
open Giraffe.EndpointRouting
open OpenApi

let private toOperationType = function
    | GET     -> OperationType.Get
    | POST    -> OperationType.Post
    | PUT     -> OperationType.Put
    | PATCH   -> OperationType.Patch
    | DELETE  -> OperationType.Delete
    | HEAD    -> OperationType.Head
    | OPTIONS -> OperationType.Options
    | TRACE   -> OperationType.Trace
    | _       -> NotSupportedException "HttpVerb" |> raise

let private endpointInfo (endpoint: Endpoint) =
    match endpoint with
    | SimpleEndpoint (verb, template, _, _) ->
        (toOperationType verb, template)
    | _ ->
        NotSupportedException "Endpoint" |> raise

let addOperation (factory: OpenApiFactory) endpoint operation =
    let verb, path = endpointInfo endpoint
    factory.addOperation verb path operation
    endpoint
