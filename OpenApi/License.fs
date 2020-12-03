namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type LicenseBuilder () =

    member _.Yield _ =
        OpenApiLicense ()

    /// REQUIRED. The license name used for the API.
    [<CustomOperation "name">]
    member _.Name (state: OpenApiLicense, value) =
        state.Name <- value
        state

    /// A URL to the license used for the API. MUST be in the format of a URL.
    [<CustomOperation "url">]
    member _.Url (state: OpenApiLicense, value) =
        state.Url <- value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiLicense, key, value) =
        state.Extensions.Add (key, value)
        state
