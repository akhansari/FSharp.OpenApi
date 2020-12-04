namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type RequestBodyBuilder () =

    member _.Yield _ =
        OpenApiRequestBody ()

    /// REQUIRED. The content of the request body.
    /// The key is a media type or media type range and the value describes it.
    /// For requests that match multiple keys, only the most specific key is applicable. e.g. text/plain overrides text/*
    [<CustomOperation "content">]
    member _.Content (state: OpenApiRequestBody, value: KVs<string, 'T>) =
        value |> List.iter state.Content.Add
        state

    /// A brief description of the request body. This could contain examples of use. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiRequestBody, value) =
        state.Description <- value
        state

    /// Determines if the request body is required in the request. Defaults to false.
    [<CustomOperation "required">]
    member _.Required (state: OpenApiRequestBody, value) =
        state.Required <- value
        state

    [<CustomOperation "unresolvedReference">]
    member _.UnresolvedReference (state: OpenApiRequestBody, value) =
        state.UnresolvedReference <- value
        state

    [<CustomOperation "reference">]
    member _.Reference (state: OpenApiRequestBody, value) =
        state.Reference <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiRequestBody, value: KVs<string, 'T>) =
        value |> List.iter state.Extensions.Add
        state