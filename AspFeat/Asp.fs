namespace AspFeat.Builder

open System
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.Http.Json
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open AspFeat

type Feat =
    ( (IServiceCollection -> IServiceCollection) *
      (IApplicationBuilder -> IApplicationBuilder) )

[<RequireQualifiedAccess>]
module Host =

    let addConsole (host: IHostBuilder) =
        host.ConfigureLogging(fun b -> b.AddConsole() |> ignore)

    let run (host: IHostBuilder) =
        host.Build().Run()
        0

[<RequireQualifiedAccess>]
module WebHost =

    let create
        (extendWebHost: IWebHostBuilder -> IWebHostBuilder)
        (feats: Feat list)
        =

        let configureServices (_: WebHostBuilderContext) (services: IServiceCollection) =

            services.Configure(fun (o: JsonOptions) ->
                JsonSerializer.setupOptions o.SerializerOptions |> ignore)
            |> ignore

            for (setup, _) in feats do
                setup services |> ignore

        let configureApp (context: WebHostBuilderContext) (app: IApplicationBuilder) =

            if context.HostingEnvironment.IsDevelopment () then
                app.UseDeveloperExceptionPage () |> ignore

            for (_, setup) in feats do
                setup app |> ignore

        let configureWebHost (builder: IWebHostBuilder) =
            builder
                .UseKestrel()
                .ConfigureServices(configureServices)
                .Configure(configureApp)
            |> extendWebHost
            |> ignore

        HostBuilder()
            .ConfigureWebHost(Action<IWebHostBuilder> configureWebHost)

    let run feats =
        create id feats
        |> Host.addConsole
        |> Host.run
