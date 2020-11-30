namespace OpenApi.Builders

open Microsoft.OpenApi.Any
open Microsoft.OpenApi.Models

type ResponseBuilder () =

    member _.Yield _ =
        OpenApiResponse ()

    [<CustomOperation "description">]
    member _.Description (state: OpenApiResponse, value) =
        state.Description <- value
        state

    [<CustomOperation "addHeader">]
    member _.Header (state: OpenApiResponse, value) =
        state.Headers.Add value
        state

    [<CustomOperation "addContent">]
    member _.Content (state: OpenApiResponse, key, value) =
        state.Content.Add (key, value)
        state

    [<CustomOperation "jsonContent">]
    member _.JsonContent (state: OpenApiResponse, example: OpenApiString) =
        let mediaType = OpenApiMediaType (Example = example)
        state.Content.Add ("application/json", mediaType)
        state

    [<CustomOperation "addLink">]
    member _.Links (state: OpenApiResponse, key, value) =
        state.Links.Add (key, value)
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiResponse, key, value) =
        state.Extensions.Add (key, value)
        state

    [<CustomOperation "unresolvedReference">]
    member _.UnresolvedReference (state: OpenApiResponse, value) =
        state.UnresolvedReference <- value
        state

    [<CustomOperation "reference">]
    member _.Reference (state: OpenApiResponse, value) =
        state.Reference <- value
        state
