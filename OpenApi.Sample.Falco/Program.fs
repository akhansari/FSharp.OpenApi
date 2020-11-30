module Program

open System.Net
open Microsoft.AspNetCore.Builder
open Falco
open Falco.Routing
open OpenApi
open OpenApi.Expressions
open AspFeat.Builder

type Product = { Id: int32; Name: string }

let v1Factory =
    OpenApiFactory.create (AspFeat.JsonSerializer.createOptions ())
        "Products API" "v1"

let getProducts =
    [ { Id = 1; Name = "Cat Food" } ]
    |> Response.ofJson

let getProductsSpec endpoint =
    operation {
        addTag (tag { name "Products" })
        summary "Get the list of products."
        addResponse HttpStatusCode.OK
            (response {
                description "Success"
                jsonContent (v1Factory.makeJsonContent [ { Id = 0; Name = "name" } ])
            })
        }
    |> FalcoOpenApi.addOperation v1Factory endpoint

let endpoints =
    [
        get "/products" getProducts |> getProductsSpec
        get v1Factory.SpecificationUrl (v1Factory.write Response.ofPlainText)
    ]

let useSwaggerUi (app: IApplicationBuilder) =
    app.UseSwaggerUI (fun options ->
        options.SwaggerEndpoint(v1Factory.SpecificationUrl, v1Factory.Version))

[<EntryPoint>]
let main _ =
    [ FalcoOpenApi.featureWith endpoints
      (id, useSwaggerUi) ]
    |> Asp.createWebHost id
    |> Asp.addConsole
    |> Asp.run
