namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type MediaTypeBuilder () =

    member _.Yield _ =
        OpenApiMediaType ()

    [<CustomOperation "schema">]
    member _.Schema (state: OpenApiMediaType, value) =
        state.Schema <- value
        state

    [<CustomOperation "example">]
    member _.Example (state: OpenApiMediaType, value) =
        state.Example <- value
        state

    [<CustomOperation "addExample">]
    member _.Examples (state: OpenApiMediaType, key, value) =
        state.Examples.Add (key, value)
        state

    [<CustomOperation "addEncoding">]
    member _.Encoding (state: OpenApiMediaType, key, value) =
        state.Encoding.Add (key, value)
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiMediaType, key, value) =
        state.Extensions.Add (key, value)
        state
