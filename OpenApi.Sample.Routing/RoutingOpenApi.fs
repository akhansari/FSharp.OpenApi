[<AutoOpen>]
module RoutingOpenApi

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Routing
open Microsoft.OpenApi.Models
open OpenApi

type IEndpointRouteBuilder with

    member this.MapGet(pattern: string, handler: Delegate, factory: OpenApiFactory, operation: OpenApiOperation) =
        factory.AddOperation OperationType.Get pattern operation
        this.MapGet(pattern, handler) |> ignore

    member this.MapPost(pattern: string, handler: Delegate, factory: OpenApiFactory, operation: OpenApiOperation) =
        factory.AddOperation OperationType.Post pattern operation
        this.MapPost(pattern, handler) |> ignore
