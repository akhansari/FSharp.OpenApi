namespace OpenApi.Builders

open System.Collections.Generic
open Microsoft.OpenApi

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

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiExternalDocs, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
