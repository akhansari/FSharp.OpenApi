namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type ServerBuilder () =

    member _.Yield _ =
        OpenApiServer ()

    /// REQUIRED. A URL to the target host.
    /// This URL supports Server Variables and MAY be relative,
    /// to indicate that the host location is relative to the location
    /// where the OpenAPI document is being served.
    /// Variable substitutions will be made when a variable is named in {brackets}.
    [<CustomOperation "url">]
    member _.Url (state: OpenApiServer, value) =
        state.Url <- value
        state

    /// An optional string describing the host designated by the URL. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiServer, value) =
        state.Description <- value
        state

    /// A map between a variable name and its value.
    /// The value is used for substitution in the server's URL template.
    [<CustomOperation "addVariable">]
    member _.Variables (state: OpenApiServer, key, value) =
        state.Variables.Add (key, value)
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiServer, key, value) =
        state.Extensions.Add (key, value)
        state
