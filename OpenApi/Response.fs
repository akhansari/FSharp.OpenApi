namespace OpenApi.Builders

open Microsoft.OpenApi.Any
open Microsoft.OpenApi.Models

type ResponseBuilder () =

    member _.Yield _ =
        OpenApiResponse ()

    /// REQUIRED. A short description of the response. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiResponse, value) =
        state.Description <- value
        state

    /// Maps a header name to its definition. RFC7230 states header names are case insensitive.
    /// If a response header is defined with the name "Content-Type", it SHALL be ignored.
    [<CustomOperation "addHeader">]
    member _.Header (state: OpenApiResponse, value) =
        state.Headers.Add value
        state

    /// A map containing descriptions of potential response payloads.
    /// The key is a media type or media type range and the value describes it.
    /// For responses that match multiple keys, only the most specific key is applicable. e.g. text/plain overrides text/*
    [<CustomOperation "addContent">]
    member _.Content (state: OpenApiResponse, key, value) =
        state.Content.Add (key, value)
        state

    /// Helper for a JSON content.
    [<CustomOperation "jsonContent">]
    member _.JsonContent (state: OpenApiResponse, example: OpenApiString) =
        let mediaType = OpenApiMediaType (Example = example)
        state.Content.Add ("application/json", mediaType)
        state

    /// A map of operations links that can be followed from the response.
    /// The key of the map is a short name for the link, following the naming constraints of the names for Component Objects.
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

type ResponsesBuilder () =

    member _.Yield _ =
        OpenApiResponses ()

    [<CustomOperation "addResponse">]
    member _.Responses (state: OpenApiResponses, key, value) =
        state.Add (key, value)
        state
