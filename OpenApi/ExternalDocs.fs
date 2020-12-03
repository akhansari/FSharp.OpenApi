namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type ExternalDocsBuilder () =

    member _.Yield _ =
        OpenApiExternalDocs ()

    /// REQUIRED. The URL for the target documentation. Value MUST be in the format of a URL.
    [<CustomOperation "url">]
    member _.Url (state: OpenApiExternalDocs, value) =
        state.Url <- value
        state

    /// A short description of the target documentation. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiExternalDocs, value) =
        state.Description <- value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiExternalDocs, key, value) =
        state.Extensions.Add (key, value)
        state
