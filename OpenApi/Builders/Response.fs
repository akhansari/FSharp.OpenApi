namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Any
open Microsoft.OpenApi.Models
open System.Text.Json.Nodes

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
    [<CustomOperation "headers">]
    member _.Headers (state: OpenApiResponse, value: KVs<_, OpenApiHeader>) =
        value |> Seq.iter state.Headers.Add
        state

    /// A map containing descriptions of potential response payloads.
    /// The key is a media type or media type range and the value describes it.
    /// For responses that match multiple keys, only the most specific key is applicable. e.g. text/plain overrides text/*
    [<CustomOperation "content">]
    member _.Content (state: OpenApiResponse, value: KVs<_, OpenApiMediaType>) =
        value |> Seq.iter state.Content.Add
        state

    /// JSON content.
    [<CustomOperation "jsonContent">]
    member _.JsonContent (state: OpenApiResponse, example: JsonNode) =
        let mediaType = OpenApiMediaType (Example = example)
        state.Content.Add (MediaTypes.Json, mediaType)
        state

    /// A map of operations links that can be followed from the response.
    /// The key of the map is a short name for the link, following the naming constraints of the names for Component Objects.
    [<CustomOperation "links">]
    member _.Links (state: OpenApiResponse, value: KVs<_, OpenApiLink>) =
        value |> Seq.iter state.Links.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiResponse, value: KVs<_, Interfaces.IOpenApiExtension>) =
        value |> Seq.iter state.Extensions.Add
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

    [<CustomOperation "responses">]
    member _.Responses (state: OpenApiResponses, value: KVs<_, OpenApiResponse>) =
        value |> Seq.iter state.Add
        state
