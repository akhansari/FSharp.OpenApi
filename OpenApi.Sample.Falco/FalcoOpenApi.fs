module FalcoOpenApi

open System
open System.Net.Http
open Falco
open OpenApi

let toOperation = function
    | GET     -> HttpMethod.Get
    | HEAD    -> HttpMethod.Head
    | POST    -> HttpMethod.Post
    | PUT     -> HttpMethod.Put
    | PATCH   -> HttpMethod.Patch
    | DELETE  -> HttpMethod.Delete
    | OPTIONS -> HttpMethod.Options
    | TRACE   -> HttpMethod.Trace
    | ANY     -> NotSupportedException "HttpVerb" |> raise

let addOperation (factory: OpenApiFactory) (endpoint: HttpEndpoint) operation =
    let httpVerb = endpoint.Handlers |> Seq.head |> fst |> toOperation
    factory.AddOperation httpVerb endpoint.Pattern operation
    endpoint
