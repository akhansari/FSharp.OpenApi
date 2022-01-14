module Program

open System.Net
open Microsoft.AspNetCore.Builder
open Falco
open Falco.Routing
open Falco.HostBuilder
open OpenApi

type Product =
    { Id: int32; Name: string }

type SpecFactory () =

    let v1Factory = OpenApiFactory.create Constants.defaultJsonOptions "Products API" "v1"

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

let getProducts =
    [ { Id = 1; Name = "Cat Food" } ]
    |> Response.ofJson

[<EntryPoint>]
let main args =

    let spec = SpecFactory ()

    let useSwaggerUi (app: IApplicationBuilder) =
        app.UseSwaggerUI (fun o -> o.SwaggerEndpoint(spec.V1.SpecificationUrl, spec.V1.Version))

    webHost args {
        endpoints [
            get "/products" getProducts |> spec.GetProducts
            get spec.V1.SpecificationUrl (spec.V1.Write Response.ofPlainText)
        ]
        use_middleware useSwaggerUi
    }

    0
