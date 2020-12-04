namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type InfoBuilder () =

    member _.Yield _ =
        OpenApiInfo ()

    /// REQUIRED. The title of the API.
    [<CustomOperation "title">]
    member _.Title (state: OpenApiInfo, value) =
        state.Title <- value
        state

    /// REQUIRED. The version of the OpenAPI document.
    [<CustomOperation "version">]
    member _.Version (state: OpenApiInfo, value) =
        state.Version <- value
        state

    /// A short description of the API. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiInfo, value) =
        state.Description <- value
        state

    /// A URL to the Terms of Service for the API. MUST be in the format of a URL.
    [<CustomOperation "termsOfService">]
    member _.TermsOfService (state: OpenApiInfo, value) =
        state.TermsOfService <- value
        state

    /// The contact information for the exposed API.
    [<CustomOperation "contact">]
    member _.Contact (state: OpenApiInfo, value) =
        state.Contact <- value
        state

    /// The license information for the exposed API.
    [<CustomOperation "license">]
    member _.License (state: OpenApiInfo, value) =
        state.License <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiInfo, value: KVs<string, 'T>) =
        value |> List.iter state.Extensions.Add
        state
