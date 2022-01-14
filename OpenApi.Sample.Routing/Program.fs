module Program

open System
open System.Net
open System.Text.Json
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.OpenApi.Models
open OpenApi

type SpecFactory () =

    let jsonOptions = JsonSerializerOptions JsonSerializerDefaults.Web
    let v1Factory = OpenApiFactory.create jsonOptions "Heroes Open Data" "v1"

    let superheroesTag = apiTag { name "Superheroes" }

    let superheroSample: Repo.Superhero =
        { Name = "name"
          AlterEgo = "Alter ego"
          Powers = [ { Kind = "kind" } ] }

    member _.V1 = v1Factory

    member _.GetSuperheroes =
        apiOperation {
            tags [ superheroesTag ]
            summary "Get the list of superheroes."
            responses [
                HttpStatusCode.OK, apiResponse {
                    description "Success"
                    jsonContent (v1Factory.MakeJsonContent [ superheroSample ])
                }
            ]
        }

    member _.GetSuperhero =
        apiOperation {
            tags [ superheroesTag ]
            summary "Find a superhero."
            parameters [
                apiParameter {
                    name "name"
                    location ParameterLocation.Path
                }
            ]
            responses [
                HttpStatusCode.OK, apiResponse {
                    description "Success"
                    jsonContent (v1Factory.MakeJsonContent superheroSample)
                }
                HttpStatusCode.NotFound, apiResponse { description "Not found" }
            ]
        }

    member _.AddSuperheroes =
        apiOperation {
            tags [ superheroesTag ]
            summary "Add a superhero."
            requestBody (apiRequestBody {
                jsonContent (v1Factory.MakeJsonContent superheroSample)
            })
            responses [
                HttpStatusCode.OK, apiResponse {
                    description "Success"
                    jsonContent (v1Factory.MakeJsonContent superheroSample)
                }
                HttpStatusCode.NotFound, apiResponse { description "Not found" }
            ]
        }

let getSuperhero name =
    match Repo.get name with
    | Some hero -> Results.Ok hero
    | None -> Results.NotFound ()

let addSuperhero model =
    Repo.add model
    Results.Created ($"/api/v1/superheroes/{model.Name}", model)

[<EntryPoint>]
let main args =
    let app = WebApplication.CreateBuilder(args).Build()

    let spec = SpecFactory ()

    app.UseSwaggerUI(fun o -> o.SwaggerEndpoint(spec.V1.SpecificationUrl, spec.V1.Version)) |> ignore

    app.MapGet("/api/v1/superheroes", Func<_> Repo.getAll, spec.V1, spec.GetSuperheroes)
    app.MapGet("/api/v1/superheroes/{name}", Func<_,_> (fun name -> getSuperhero name), spec.V1, spec.GetSuperhero)
    app.MapPost("/api/v1/superheroes", Func<_,_> (fun model -> addSuperhero model), spec.V1, spec.AddSuperheroes)

    app.MapGet(spec.V1.SpecificationUrl, RequestDelegate (fun ctx -> spec.V1.Write ctx.Response.WriteAsync)) |> ignore

    app.Run()
    0
