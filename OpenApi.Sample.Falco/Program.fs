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
    apiOperation {
        tags [ apiTag { name "Products" } ]
        summary "Get the list of products."
        responses [
            HttpStatusCode.OK, apiResponse {
                description "Success"
                jsonContent (v1Factory.MakeJsonContent [ { Id = 0; Name = "name" } ])
            } ]
        }
    |> FalcoOpenApi.addOperation v1Factory endpoint

let endpoints =
    [
        get "/products" getProducts |> getProductsSpec
        get v1Factory.SpecificationUrl (v1Factory.Write Response.ofPlainText)
    ]

let useSwaggerUi (app: IApplicationBuilder) =
    app.UseSwaggerUI (fun options ->
        options.SwaggerEndpoint(v1Factory.SpecificationUrl, v1Factory.Version))

[<EntryPoint>]
let main _ =
    [ FalcoOpenApi.featWith endpoints
      (id, useSwaggerUi) ]
    |> WebHost.run
