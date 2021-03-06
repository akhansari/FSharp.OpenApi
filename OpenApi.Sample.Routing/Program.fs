module Program

open System.Net
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Routing
open OpenApi
open OpenApi.Expressions
open Sample
open AspFeat.Builder

let v1Factory =
    OpenApiFactory.create (AspFeat.JsonSerializer.createOptions ())
        "Heroes Open Data" "v1"

let configureEndpoints (builder: IEndpointRouteBuilder) =
    let mapWithSpec = Route.mapWithSpec builder v1Factory
    let map = Route.map builder

    let superbeingTag = apiTag { name "Superbeing" }

    apiOperation {
        tags [ superbeingTag ]
        summary "Get the list of superbeings."
        responses [
            HttpStatusCode.OK, apiResponse {
                description "Success"
                jsonContent
                    (v1Factory.MakeJsonContent [ Superhero
                        { Name = "name"
                          Powers = [{ Kind = "kind" }] } ])
            } ]
        }
    |> mapWithSpec Get "/api/v1/superbeings" (fun ctx ->
        Repo.getAll ()
        |> Response.writeAsJson ctx)

    map Get v1Factory.SpecificationUrl (fun ctx -> v1Factory.Write ctx.Response.WriteAsync)

let useSwaggerUi (app: IApplicationBuilder) =
    app.UseSwaggerUI (fun options ->
        options.SwaggerEndpoint(v1Factory.SpecificationUrl, v1Factory.Version))

[<EntryPoint>]
let main _ =
    [ Endpoints.featWith configureEndpoints
      (id, useSwaggerUi) ]
    |> WebHost.run
