namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type ServerVariableBuilder () =

    member _.Yield _ =
        OpenApiServerVariable ()

    [<CustomOperation "description">]
    member _.Description (state: OpenApiServerVariable, value) =
        state.Description <- value
        state

    [<CustomOperation "default">]
    member _.Default (state: OpenApiServerVariable, value) =
        state.Default <- value
        state

    [<CustomOperation "enums">]
    member _.Enums (state: OpenApiServerVariable, value) =
        Seq.iter state.Enum.Add value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiServerVariable, value: KVs<_, Interfaces.IOpenApiExtension>) =
        value |> Seq.iter state.Extensions.Add
        state
