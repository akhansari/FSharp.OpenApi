[<RequireQualifiedAccess>]
module FalcoSwagger.ApiFeature

open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection

let addApi (services: IServiceCollection) =
    services
        .AddHealthChecks().Services
        .AddResponseCompression()
        .AddRouting()

let useApi (app: IApplicationBuilder) =
    app
        .UseDeveloperExceptionPage()
        .UseResponseCompression()
        .UseRouting()
        .UseEndpoints(fun endpoints ->
            endpoints.MapHealthChecks("/health") |> ignore)

let getDefault =
    (addApi, useApi)
