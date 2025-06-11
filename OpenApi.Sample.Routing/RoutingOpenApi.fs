[<AutoOpen>]
module RoutingOpenApi

open System
open System.Net.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Routing
open OpenApi
open Microsoft.OpenApi

type IEndpointRouteBuilder with

    member this.MapGet(pattern: string, handler: Delegate, factory: OpenApiFactory, operation: OpenApiOperation) =
        factory.AddOperation HttpMethod.Get pattern operation
        this.MapGet(pattern, handler) |> ignore

    member this.MapPost(pattern: string, handler: Delegate, factory: OpenApiFactory, operation: OpenApiOperation) =
        factory.AddOperation HttpMethod.Post pattern operation
        this.MapPost(pattern, handler) |> ignore
