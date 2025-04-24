namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type ErrorBuilder () =

    member _.Yield _ =
        OpenApiError ("", "")

    [<CustomOperation "messages">]
    member _.Name (state: OpenApiError, value) =
        state.Message <- value
        state

    [<CustomOperation "description">]
    member _.Description (state: OpenApiError, value) =
        state.Pointer <- value
        state
