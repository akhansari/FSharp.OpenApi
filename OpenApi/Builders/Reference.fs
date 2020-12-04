namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type ReferenceBuilder () =

    member _.Yield _ =
        OpenApiReference ()

    [<CustomOperation "externalResource">]
    member _.ExternalResource (state: OpenApiReference, value) =
        state.ExternalResource <- value
        state

    [<CustomOperation "type">]
    member _.Type (state: OpenApiReference, value) =
        state.Type <- value
        state

    [<CustomOperation "id">]
    member _.Id (state: OpenApiReference, value) =
        state.Id <- value
        state
