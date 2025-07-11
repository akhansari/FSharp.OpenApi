namespace OpenApi.Builders

open Microsoft.OpenApi

type ErrorBuilder () =

    member _.Yield _ =
        OpenApiError ("", "")

    [<CustomOperation "messages">]
    member _.Messages (state: OpenApiError, value) =
        state.Message <- value
        state

    [<CustomOperation "description">]
    member _.Description (state: OpenApiError, value) =
        state.Pointer <- value
        state
