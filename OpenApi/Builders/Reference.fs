namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type ReferenceBuilder () =

    member _.Yield _ =
        OpenApiReference()

    // This class has many init only properties

    [<CustomOperation "summary">]
    member _.Summary (state: OpenApiReference, value) =
        state.Summary <- value
        state

    [<CustomOperation "description">]
    member _.Description (state: OpenApiReference, value) =
        state.Description <- value
        state

