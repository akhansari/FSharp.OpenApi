namespace FalcoSwagger

open System
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

type AspFeature =
    ( (IServiceCollection -> IServiceCollection) *
      (IApplicationBuilder -> IApplicationBuilder) )

[<RequireQualifiedAccess>]
module Asp =

    let hostBuilderWith (features: AspFeature list) =

        let configureServices (_: WebHostBuilderContext) (services: IServiceCollection) =
            for (setup, _) in features do
                setup services |> ignore

        let configureApp (_: WebHostBuilderContext) (app: IApplicationBuilder) =
            for (_, setup) in features do
                setup app |> ignore

        let configureWebHost (builder: IWebHostBuilder) =
            builder
                .ConfigureLogging(fun loggingBuilder ->
                    loggingBuilder.AddDebug().AddConsole() |> ignore)
                .UseKestrel()
                .ConfigureServices(configureServices)
                .Configure(configureApp)
            |> ignore

        HostBuilder()
            .ConfigureWebHost(Action<IWebHostBuilder> configureWebHost)
