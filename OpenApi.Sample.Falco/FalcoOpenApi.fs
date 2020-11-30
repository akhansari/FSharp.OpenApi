module FalcoOpenApi

open System
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Microsoft.OpenApi.Models
open Falco
open OpenApi

let featureWith endpoints =
    ( (fun (services: IServiceCollection) -> services.AddFalco ()),
      (fun (app: IApplicationBuilder) -> app.UseFalco endpoints))

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
    factory.addOperation httpVerb endpoint.Pattern operation
    endpoint