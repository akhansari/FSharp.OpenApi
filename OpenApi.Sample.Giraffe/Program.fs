module Program

open System.Net
open System.Net.Http
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Scalar.AspNetCore
open Giraffe
open OpenApi

type Product = { Id: int32; Name: string }

type SpecFactory () =

    let v1Factory =
        OpenApiFactory.simpleDocument "Products API" "v1"
        |> OpenApiFactory.create Json.FsharpFriendlySerializer.DefaultOptions

    let addOperation (factory: OpenApiFactory) verb path operation =
        factory.AddOperation verb path operation
        path

    member _.V1 = v1Factory

    member _.GetProducts path =
        apiOperation {
            tags [ "Products" ]
            summary "Get the list of products."
            responses [
                HttpStatusCode.OK, apiResponse {
                    description "Success"
                    jsonContent (v1Factory.MakeJsonContent [ { Id = 0; Name = "name" } ])
                } ]
            }
        |> addOperation v1Factory HttpMethod.Get path

let getProducts : HttpHandler =
    fun _ ctx ->
        [ { Id = 1; Name = "Cat Food" } ]
        |> ctx.WriteJsonAsync

[<EntryPoint>]
let main args =

    let spec = SpecFactory ()

    let webApp =
        choose [
            GET >=> choose [
                route (spec.GetProducts "/products") >=> getProducts
                route spec.V1.SpecificationUrl >=> spec.V1.Write text
            ]
        ]

    let addGiraffe (services: IServiceCollection) =
        services
            .AddGiraffe()
        |> ignore

    let configureApp (app: IApplicationBuilder) =
        app
            .UseRouting()
            .UseEndpoints(fun e -> e.MapScalarApiReference() |> ignore)
            .UseGiraffe(webApp)
        |> ignore

    WebHost
        .CreateDefaultBuilder(args)
        .UseKestrel()
        .ConfigureServices(addGiraffe)
        .Configure(configureApp)
        .Build()
        .Run()
    0
