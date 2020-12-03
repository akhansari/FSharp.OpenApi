﻿namespace OpenApi.Builders

open System
open Microsoft.OpenApi.Models

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

    [<CustomOperation "addExample">]
    member _.Examples (state: OpenApiHeader, key, value) =
        state.Examples.Add (key, value)
        state

    [<CustomOperation "addContent">]
    member _.Content (state: OpenApiHeader, key, value) =
        state.Content.Add (key, value)
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiHeader, key, value) =
        state.Extensions.Add (key, value)
        state

    [<CustomOperation "unresolvedReference">]
    member _.UnresolvedReference (state: OpenApiHeader, value) =
        state.UnresolvedReference <- value
        state

    [<CustomOperation "reference">]
    member _.Reference (state: OpenApiHeader, value) =
        state.Reference <- value
        state