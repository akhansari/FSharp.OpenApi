namespace OpenApi.Builders

open System
open System.Collections.Generic
open Microsoft.OpenApi

type ParameterBuilder () =

    member _.Yield _ =
        OpenApiParameter ()

    /// REQUIRED. The name of the parameter. Parameter names are case sensitive.
    /// If in is "path", the name field MUST correspond to a template expression occurring within the path field in the Paths Object. See Path Templating for further information.
    /// If in is "header" and the name field is "Accept", "Content-Type" or "Authorization", the parameter definition SHALL be ignored.
    /// For all other cases, the name corresponds to the parameter name used by the in property.
    [<CustomOperation "name">]
    member _.Name (state: OpenApiParameter, value) =
        state.Name <- value
        state

    /// REQUIRED. The location of the parameter. Possible values are "query", "header", "path" or "cookie".
    [<CustomOperation "location">]
    member _.In (state: OpenApiParameter, value) =
        state.In <- Nullable value
        state

    /// A brief description of the parameter. This could contain examples of use. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiParameter, value) =
        state.Description <- value
        state

    /// Determines whether this parameter is mandatory.
    /// If the parameter location is "path", this property is REQUIRED and its value MUST be true.
    /// Otherwise, the property MAY be included and its default value is false.
    [<CustomOperation "required">]
    member _.Required (state: OpenApiParameter, value) =
        state.Required <- value
        state

    /// Specifies that a parameter is deprecated and SHOULD be transitioned out of usage.
    /// Default value is false.
    [<CustomOperation "deprecated">]
    member _.Deprecated (state: OpenApiParameter, value) =
        state.Deprecated <- value
        state

    /// Describes how the parameter value will be serialized depending on the type of the parameter value.
    /// Default values (based on value of in): for query - form; for path - simple; for header - simple; for cookie - form.
    [<CustomOperation "style">]
    member _.Style (state: OpenApiParameter, value) =
        state.Style <- Nullable value
        state

    /// When this is true, parameter values of type array or object generate separate parameters
    /// for each value of the array or key-value pair of the map.
    /// For other types of parameters this property has no effect. When style is form, the default value is true.
    /// For all other styles, the default value is false.
    [<CustomOperation "explode">]
    member _.Explode (state: OpenApiParameter, value) =
        state.Explode <- value
        state

    /// Determines whether the parameter value SHOULD allow reserved characters,
    /// as defined by RFC3986 :/?#[]@!$&'()*+,;= to be included without percent-encoding.
    /// This property only applies to parameters with an in value of query. The default value is false.
    [<CustomOperation "allowReserved">]
    member _.AllowReserved (state: OpenApiParameter, value) =
        state.AllowReserved <- value
        state

    /// The schema defining the type used for the parameter.
    [<CustomOperation "schema">]
    member _.Schema (state: OpenApiParameter, value) =
        state.Schema <- value
        state

    /// Examples of the parameter's potential value.
    [<CustomOperation "examples">]
    member _.Examples (state: OpenApiParameter, values: KVs<_, OpenApiExample>) =
        if isNull state.Examples then state.Examples <- Dictionary()
        values |> Seq.iter state.Examples.Add
        state

    /// Example of the parameter's potential value.
    /// The example SHOULD match the specified schema and encoding properties if present.
    /// The example field is mutually exclusive of the examples field.
    /// Furthermore, if referencing a schema that contains an example,
    /// the example value SHALL override the example provided by the schema.
    /// To represent examples of media types that cannot naturally be represented in JSON or YAML,
    /// a string value can contain the example with escaping where necessary.
    [<CustomOperation "example">]
    member _.Example (state: OpenApiParameter, value) =
        state.Example <- value
        state

    /// A map containing the representations for the parameter.
    /// The key is the media type and the value describes it.
    /// The map MUST only contain one entry.
    [<CustomOperation "content">]
    member _.Content (state: OpenApiParameter, values: KVs<string, 'T>) =
        if isNull state.Content then state.Content <- Dictionary()
        values |> Seq.iter state.Content.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiParameter, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
