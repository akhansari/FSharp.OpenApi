namespace FalcoSwagger

open Microsoft.Extensions.Hosting

module Program =

    let CreateHostBuilder (_: string[]) =
        [ ApiFeature.getDefault
          EndpointsFeature.getDefault
          SwaggerFeature.getDefault ]
        |> Asp.hostBuilderWith

    [<EntryPoint>]
    let main args =
        CreateHostBuilder(args).Build().Run()
        0
