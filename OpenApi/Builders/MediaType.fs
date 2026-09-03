namespace OpenApi.Builders

open System.Collections.Generic
open Microsoft.OpenApi

type MediaTypeBuilder () =

    member _.Yield _ =
        OpenApiMediaType ()

    /// The schema defining the content of the request, response, or parameter.
    [<CustomOperation "schema">]
    member _.Schema (state: OpenApiMediaType, value) =
        state.Schema <- value
        state

    /// The schema applied independently to each item of a sequential media type.
    [<CustomOperation "itemSchema">]
    member _.ItemSchema (state: OpenApiMediaType, value) =
        state.ItemSchema <- value
        state

    /// Example of the media type. The example object SHOULD be in the correct format as specified by the media type.
    /// The example field is mutually exclusive of the examples field.
    /// Furthermore, if referencing a schema which contains an example,
    /// the example value SHALL override the example provided by the schema.
    [<CustomOperation "example">]
    member _.Example (state: OpenApiMediaType, value) =
        state.Example <- value
        state

    /// Examples of the media type.
    [<CustomOperation "examples">]
    member _.Examples (state: OpenApiMediaType, values: KVs<_, OpenApiExample>) =
        if isNull state.Examples then state.Examples <- Dictionary()
        values |> Seq.iter state.Examples.Add
        state

    /// A map between a property name and its encoding information.
    /// The key, being the property name, MUST exist in the schema as a property.
    /// The encoding object SHALL only apply to requestBody objects when the media type is multipart or application/x-www-form-urlencoded.
    [<CustomOperation "encoding">]
    member _.Encoding (state: OpenApiMediaType, values: KVs<_, OpenApiEncoding>) =
        if isNull state.Encoding then state.Encoding <- Dictionary()
        values |> Seq.iter state.Encoding.Add
        state

    /// Encoding information for repeated array items.
    [<CustomOperation "itemEncoding">]
    member _.ItemEncoding (state: OpenApiMediaType, value) =
        state.ItemEncoding <- value
        state

    /// Encoding information for tuple-style array items.
    [<CustomOperation "prefixEncoding">]
    member _.PrefixEncoding (state: OpenApiMediaType, values) =
        if isNull state.PrefixEncoding then state.PrefixEncoding <- List()
        values |> Seq.iter state.PrefixEncoding.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiMediaType, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
