namespace OpenApi.Builders

open System.Collections.Generic
open Microsoft.OpenApi

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
        if isNull state.Enum then state.Enum <- List()
        Seq.iter state.Enum.Add value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiServerVariable, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
