namespace OpenApi.Builders

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
        List.iter state.Enum.Add value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiServerVariable, value: KVs<string, 'T>) =
        value |> List.iter state.Extensions.Add
        state
