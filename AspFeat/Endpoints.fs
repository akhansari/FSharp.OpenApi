[<RequireQualifiedAccess>]
module AspFeat.Builder.Endpoints

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Routing
open Microsoft.Extensions.DependencyInjection

let private addApi (services: IServiceCollection) =
    services
        .AddResponseCompression()
        .AddRouting()

let private useApi configureEndpoints (app: IApplicationBuilder) =
    app
        .UseResponseCompression()
        .UseRouting()
        .UseEndpoints(Action<IEndpointRouteBuilder> configureEndpoints)

let featWith configureEndpoints =
    (addApi, useApi configureEndpoints)
