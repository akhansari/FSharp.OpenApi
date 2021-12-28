namespace OpenApi.Builders

open Microsoft.OpenApi
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
    [<CustomOperation "variables">]
    member _.Variables (state: OpenApiServer, value: KVs<_, OpenApiServerVariable>) =
        value |> Seq.iter state.Variables.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiServer, value: KVs<_, Interfaces.IOpenApiExtension>) =
        value |> Seq.iter state.Extensions.Add
        state
