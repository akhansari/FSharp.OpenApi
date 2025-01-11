module Program

open System.Net
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.OpenApi.Models
open Giraffe
open OpenApi

type Product = { Id: int32; Name: string }

type SpecFactory (jsonOptions) =

    let v1Factory = OpenApiFactory.create jsonOptions "Products API" "v1"

    let addOperation (factory: OpenApiFactory) verb path operation =
        factory.AddOperation verb path operation
        path

    member _.V1 = v1Factory

    member _.GetProducts path =
        apiOperation {
            tags [ apiTag { name "Products" } ]
            summary "Get the list of products."
            responses [
                HttpStatusCode.OK, apiResponse {
                    description "Success"
                    jsonContent (v1Factory.MakeJsonContent [ { Id = 0; Name = "name" } ])
                } ]
            }
        |> addOperation v1Factory OperationType.Get path

let getProducts : HttpHandler =
    fun _ ctx ->
        [ { Id = 1; Name = "Cat Food" } ]
        |> ctx.WriteJsonAsync

[<EntryPoint>]
let main args =

    let jsonOptions = System.Text.Json.JsonSerializerOptions ()
    let spec = SpecFactory jsonOptions

    let webApp =
        choose [
            GET >=> choose [
                route (spec.GetProducts "/products") >=> getProducts
                route spec.V1.SpecificationUrl >=> (spec.V1.Write text)
            ]
        ]

    let addGiraffe (services: IServiceCollection) =
        services
            .AddGiraffe()
        |> ignore

    let useSwaggerUi (app: IApplicationBuilder) =
        app
            .UseSwaggerUI(fun o -> o.SwaggerEndpoint(spec.V1.SpecificationUrl, spec.V1.Version))
            .UseGiraffe(webApp)
        |> ignore

    WebHost
        .CreateDefaultBuilder(args)
        .UseKestrel()
        .ConfigureServices(addGiraffe)
        .Configure(useSwaggerUi)
        .Build()
        .Run()
    0
