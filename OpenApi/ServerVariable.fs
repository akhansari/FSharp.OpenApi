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

    [<CustomOperation "addEnum">]
    member _.Enum (state: OpenApiServerVariable, value) =
        state.Enum.Add value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiServerVariable, key, value) =
        state.Extensions.Add (key, value)
        state
