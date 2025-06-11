namespace OpenApi.Builders

open System
open Microsoft.OpenApi

type HeaderBuilder () =

    member _.Yield _ =
        OpenApiHeader ()

    [<CustomOperation "description">]
    member _.Description (state: OpenApiHeader, value) =
        state.Description <- value
        state

    [<CustomOperation "required">]
    member _.Required (state: OpenApiHeader, value) =
        state.Required <- value
        state

    [<CustomOperation "deprecated">]
    member _.Deprecated (state: OpenApiHeader, value) =
        state.Deprecated <- value
        state

    [<CustomOperation "allowEmptyValue">]
    member _.AllowEmptyValue (state: OpenApiHeader, value) =
        state.AllowEmptyValue <- value
        state

    [<CustomOperation "style">]
    member _.Style (state: OpenApiHeader, value) =
        state.Style <- Nullable value
        state

    [<CustomOperation "explode">]
    member _.Explode (state: OpenApiHeader, value) =
        state.Explode <- value
        state

    [<CustomOperation "allowReserved">]
    member _.AllowReserved (state: OpenApiHeader, value) =
        state.AllowReserved <- value
        state

    [<CustomOperation "schema">]
    member _.Schema (state: OpenApiHeader, value) =
        state.Schema <- value
        state

    [<CustomOperation "example">]
    member _.Example (state: OpenApiHeader, value) =
        state.Example <- value
        state

    [<CustomOperation "examples">]
    member _.Examples (state: OpenApiHeader, values: KVs<_, OpenApiExample>) =
        values |> Seq.iter state.Examples.Add
        state

    [<CustomOperation "content">]
    member _.Content (state: OpenApiHeader, values: KVs<_, OpenApiMediaType>) =
        values |> Seq.iter state.Content.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiHeader, values: KVs<_, IOpenApiExtension>) =
        values |> Seq.iter state.Extensions.Add
        state
