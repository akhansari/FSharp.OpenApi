[<RequireQualifiedAccess>]
module AspFeat.Features.Endpoint

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Routing
open Microsoft.Extensions.DependencyInjection

let addApi (services: IServiceCollection) =
    services
        .AddResponseCompression()
        .AddRouting()

let useApi configureEndpoints (app: IApplicationBuilder) =
    app
        .UseResponseCompression()
        .UseRouting()
        .UseEndpoints(Action<IEndpointRouteBuilder> configureEndpoints)

let featureWith configureEndpoints =
    (addApi, useApi configureEndpoints)
