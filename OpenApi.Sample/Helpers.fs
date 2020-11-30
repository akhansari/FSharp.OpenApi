namespace Sample

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Routing
open Microsoft.OpenApi.Models
open OpenApi

module Response =

    let empty (ctx: HttpContext) =
        ctx.Response.CompleteAsync ()

    let emptyWith (ctx: HttpContext) statusCode =
        ctx.Response.StatusCode <- statusCode
        empty ctx

    let writeAsJson (ctx: HttpContext) value =
        ctx.Response.WriteAsJsonAsync value

type HttpVerb =
    | Get
    member this.OperationType =
        match this with
        | Get -> OperationType.Get

module Route =

    let map (builder: IEndpointRouteBuilder) (httpVerb: HttpVerb) pattern handler =
        builder.MapMethods (pattern, [ httpVerb.ToString () ], RequestDelegate handler) |> ignore

    let mapWithSpec builder (factory: OpenApiFactory) httpVerb pattern handler operation =
        map builder httpVerb pattern handler
        factory.addOperation httpVerb.OperationType pattern operation