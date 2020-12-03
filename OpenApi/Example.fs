namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type ExampleBuilder () =

    member _.Yield _ =
        OpenApiExample ()

    /// Short description for the example.
    [<CustomOperation "summary">]
    member _.Summary (state: OpenApiExample, value) =
        state.Summary <- value
        state

    /// Long description for the example. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Descriptio n (state: OpenApiExample, value) =
        state.Description <- value
        state

    /// Embedded literal example. The value field and externalValue field are mutually exclusive.
    /// To represent examples of media types that cannot naturally represented in JSON or YAML,
    /// use a string value to contain the example, escaping where necessary.
    [<CustomOperation "value">]
    member _.Value (state: OpenApiExample, value) =
        state.Value <- value
        state

    /// A URL that points to the literal example. This provides the capability to reference examples
    /// that cannot easily be included in JSON or YAML documents.
    /// The value field and externalValue field are mutually exclusive.
    [<CustomOperation "externalValue">]
    member _.ExternalValue (state: OpenApiExample, value) =
        state.ExternalValue <- value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiExample, key, value) =
        state.Extensions.Add (key, value)
        state

    [<CustomOperation "reference">]
    member _.Reference (state: OpenApiExample, value) =
        state.Reference <- value
        state

    [<CustomOperation "unresolvedReference">]
    member _.UnresolvedReference (state: OpenApiExample, value) =
        state.UnresolvedReference <- value
        state
