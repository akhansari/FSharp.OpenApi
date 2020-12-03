namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type MediaTypeBuilder () =

    member _.Yield _ =
        OpenApiMediaType ()

    /// The schema defining the content of the request, response, or parameter.
    [<CustomOperation "schema">]
    member _.Schema (state: OpenApiMediaType, value) =
        state.Schema <- value
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
    [<CustomOperation "addExample">]
    member _.Examples (state: OpenApiMediaType, key, value) =
        state.Examples.Add (key, value)
        state

    /// A map between a property name and its encoding information.
    /// The key, being the property name, MUST exist in the schema as a property.
    /// The encoding object SHALL only apply to requestBody objects when the media type is multipart or application/x-www-form-urlencoded.
    [<CustomOperation "addEncoding">]
    member _.Encoding (state: OpenApiMediaType, key, value) =
        state.Encoding.Add (key, value)
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiMediaType, key, value) =
        state.Extensions.Add (key, value)
        state
