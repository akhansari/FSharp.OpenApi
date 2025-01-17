module Program

open System.Net
open System.Text.Json
open Microsoft.AspNetCore.Builder
open Falco
open Falco.Routing
open Falco.HostBuilder
open Scalar.AspNetCore
open OpenApi

type Product =
    { Id: int32; Name: string }

type SpecFactory (jsonOptions) =

    let v1Factory = OpenApiFactory.create jsonOptions "Products API" "v1"

    member _.V1 = v1Factory

    member _.GetProducts endpoint =
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

let jsonOptions = JsonSerializerOptions JsonSerializerDefaults.Web

let getProducts =
    [ { Id = 1; Name = "Cat Food" } ]
    |> Response.ofJsonOptions jsonOptions

[<EntryPoint>]
let main args =

    let spec = SpecFactory (jsonOptions)

    let useOpenApiUI (app: IApplicationBuilder) =
        app
            .UseRouting()
            .UseEndpoints(fun e -> e.MapScalarApiReference() |> ignore)

    webHost args {
        endpoints [
            get "/products" getProducts |> spec.GetProducts
            get spec.V1.SpecificationUrl (spec.V1.Write Response.ofPlainText)
        ]
        use_middleware useOpenApiUI
    }

    0
