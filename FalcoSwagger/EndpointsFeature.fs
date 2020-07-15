[<RequireQualifiedAccess>]
module FalcoSwagger.EndpointsFeature

open System.Net
open Microsoft.OpenApi.Models
open Microsoft.AspNetCore.Builder
open Falco
open Falco.OpenApi

let private responseOfJson ctx obj =
    Response.ofJsonOptions obj JsonSerializer.options ctx
let private responseOfRawJson json =
    Response.withContentType "application/json; charset=utf-8"
    >> Response.ofPlainText json

let v1Factory =
    OpenApiFactory.create (JsonSerializer.createOptions ()) "Heroes Open Data" "v1"
let specifyV1 =
    OpenApiFactory.specify v1Factory
let faker = Bogus.Faker()

let superheroes =
    fun ctx ->
        [ Superhero { Name = "Bruce Wayne"; Powers = [ { Kind = "Genius intellect" } ]}
          Superhero { Name = "Barry Allen"; Powers = [ { Kind = "Speed force" } ]} ]
        |> responseOfJson ctx
    |> get "/api/v1/superheroes"
    |> specifyV1 (openApiOperation {
        tags [ OpenApiTag (Name = "Superhero") ]
        summary "Get the list of superheroes."
        responses
            [ HttpStatusCode.OK, openApiResponse {
                description "Success"
                jsonContent
                    (Superhero
                        { Name = faker.Name.FullName ()
                          Powers = [ { Kind = faker.Hacker.Adjective () } ] }
                    |> OpenApiFactory.makeJsonContent v1Factory)
              } ]
        })

let supervillains =
    fun ctx ->
        [ Supervillain { Name = "Joker"; Powers = [ { Kind = "Criminal mastermind" } ]}
          Supervillain { Name = "Eobard Thawne"; Powers = [ { Kind = "Negative speed force" } ]} ]
        |> responseOfJson ctx
    |> get "/api/v1/supervillains"
    |> specifyV1 (openApiOperation {
        tags [ OpenApiTag (Name = "Supervillain") ]
        summary "Get the list of supervillains."
        })

let openApiV1Specification =
    v1Factory
    |> OpenApiFactory.serialize
    |> responseOfRawJson
    |> get "/api/specifications/v1"

let endpoints =
    [ superheroes
      supervillains
      openApiV1Specification ]

let useApi (app: IApplicationBuilder) =
    app.UseHttpEndPoints endpoints

let getDefault =
    (id, useApi)
