[<RequireQualifiedAccess>]
module FalcoSwagger.SwaggerFeature

open Microsoft.AspNetCore.Builder

let private formatSpecUrl =
    sprintf "/api/specifications/%s"

let useSwaggerUi (app: IApplicationBuilder) =
    app
        .UseSwaggerUI(fun options ->
            let version = "v1"
            options.SwaggerEndpoint(formatSpecUrl version, version)
            options.HeadContent <-
                "<style>
                pre { font-family: fira code,monospace !important; }
                pre.microlight { font-size: 13px !important; }
                </style>"
        )

let getDefault =
    (id, useSwaggerUi)
