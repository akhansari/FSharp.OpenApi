namespace OpenApi.Builders

open System
open System.Text.Json.Nodes
open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type SchemaBuilder () =

    member _.Yield _ =
        OpenApiSchema ()

    /// Identifies a schema resource with its canonical URI.
    [<CustomOperation "id">]
    member _.Id (state: OpenApiSchema, value) =
        state.Id <- value
        state

    /// Follow JSON Schema definition. Short text providing information about the data.
    [<CustomOperation "title">]
    member _.Title (state: OpenApiSchema, value) =
        state.Title <- value
        state

    /// A JSON Schema dialect identifier. Value must be a URI.
    [<CustomOperation "schema">]
    member _.Schema (state: OpenApiSchema, value) =
        state.Schema <- value
        state

    [<CustomOperation "schemaType">]
    member _.Type (state: OpenApiSchema, value) =
        state.Type <- Nullable value
        state

    /// Reserves a location for comments from schema authors to readers or maintainers of the schema.
    [<CustomOperation "comment">]
    member _.Comment (state: OpenApiSchema, value) =
        state.Comment <- value
        state

    /// Used in meta-schemas to identify the vocabularies available for use in schemas described by that meta-schema.
    [<CustomOperation "vocabulary">]
    member _.Vocabulary (state: OpenApiSchema, values: KVs<_, bool>) =
        values |> Seq.iter state.Vocabulary.Add
        state

    /// An applicator that allows for deferring the full resolution until runtime, at which point it is resolved each time it is encountered while evaluating an instance.
    [<CustomOperation "dynamicRef">]
    member _.DynamicRef (state: OpenApiSchema, value) =
        state.DynamicRef <- value
        state

    /// Used to create plain name fragments that are not tied to any particular structural location for referencing purposes, which are taken into consideration for dynamic referencing.
    [<CustomOperation "dynamicAnchor">]
    member _.DynamicAnchor (state: OpenApiSchema, value) =
        state.DynamicAnchor <- value
        state

    [<CustomOperation "definitions">]
    member _.Definitions (state: OpenApiSchema, values: KVs<_, OpenApiSchema>) =
        values |> Seq.iter state.Definitions.Add
        state

    [<CustomOperation "unEvaluatedPropertie">]
    member _.UnEvaluatedProperties (state: OpenApiSchema, value) =
        state.UnEvaluatedProperties <- value
        state

    [<CustomOperation "externalDoc">]
    member _.ExternalDoc (state: OpenApiSchema, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "const">]
    member _.Const (state: OpenApiSchema, value) =
        state.Const <- value
        state

    [<CustomOperation "format">]
    member _.Format (state: OpenApiSchema, value) =
        state.Format <- value
        state

    [<CustomOperation "description">]
    member _.Description (state: OpenApiSchema, value) =
        state.Description <- value
        state

    [<CustomOperation "maximum">]
    member _.Maximum (state: OpenApiSchema, value) =
        state.Maximum <- Nullable value
        state

    [<CustomOperation "exclusiveMaximum">]
    member _.ExclusiveMaximum (state: OpenApiSchema, value) =
        state.ExclusiveMaximum <- Nullable value
        state

    [<CustomOperation "v31ExclusiveMaximum">]
    member _.V31ExclusiveMaximum (state: OpenApiSchema, value) =
        state.V31ExclusiveMaximum <- Nullable value
        state

    [<CustomOperation "minimum">]
    member _.Minimum (state: OpenApiSchema, value) =
        state.Minimum <- Nullable value
        state

    [<CustomOperation "exclusiveMinimum">]
    member _.ExclusiveMinimum (state: OpenApiSchema, value) =
        state.ExclusiveMinimum <- Nullable value
        state

    [<CustomOperation "v31ExclusiveMinimum">]
    member _.V31ExclusiveMinimum (state: OpenApiSchema, value) =
        state.V31ExclusiveMinimum <- Nullable value
        state

    [<CustomOperation "maxLength">]
    member _.MaxLength (state: OpenApiSchema, value) =
        state.MaxLength <- Nullable value
        state

    [<CustomOperation "minLength">]
    member _.MinLength (state: OpenApiSchema, value) =
        state.MinLength <- Nullable value
        state

    [<CustomOperation "pattern">]
    member _.Pattern (state: OpenApiSchema, value) =
        state.Pattern <- value
        state

    [<CustomOperation "multipleOf">]
    member _.MultipleOf (state: OpenApiSchema, value) =
        state.MultipleOf <- Nullable value
        state

    [<CustomOperation "readOnly">]
    member _.ReadOnly (state: OpenApiSchema, value) =
        state.ReadOnly <- value
        state

    [<CustomOperation "writeOnly">]
    member _.WriteOnly (state: OpenApiSchema, value) =
        state.WriteOnly <- value
        state

    [<CustomOperation "allOf">]
    member _.AllOf (state: OpenApiSchema, value) =
        value |> Seq.iter (fun v -> state.AllOf.Add v)
        state

    [<CustomOperation "oneOf">]
    member _.OneOf (state: OpenApiSchema, value) =
        value |> Seq.iter (fun v -> state.OneOf.Add v)
        state

    [<CustomOperation "anyOf">]
    member _.AnyOf (state: OpenApiSchema, value) =
        value |> Seq.iter (fun v -> state.AnyOf.Add v)
        state

    [<CustomOperation "notEqual">]
    member _.Not (state: OpenApiSchema, value) =
        state.Not <- value
        state

    [<CustomOperation "required">]
    member _.Required (state: OpenApiSchema, value) =
        value |> Seq.iter (fun v -> state.Required.Add v |> ignore)
        state

    [<CustomOperation "Items">]
    member _.Items (state: OpenApiSchema, value) =
        state.Items <- value
        state

    [<CustomOperation "maxItems">]
    member _.MaxItems (state: OpenApiSchema, value) =
        state.MaxItems <- Nullable value
        state

    [<CustomOperation "minItems">]
    member _.MinItems (state: OpenApiSchema, value) =
        state.MinItems <- Nullable value
        state

    [<CustomOperation "uniqueItems">]
    member _.UniqueItems (state: OpenApiSchema, value) =
        state.UniqueItems <- value
        state

    [<CustomOperation "properties">]
    member _.Properties (state: OpenApiSchema, values: KVs<_, OpenApiSchema>) =
        values |> Seq.iter state.Properties.Add
        state

    [<CustomOperation "patternPropertie">]
    member _.PatternPropertie (state: OpenApiSchema, values: KVs<_, OpenApiSchema>) =
        values |> Seq.iter state.PatternProperties.Add
        state

    [<CustomOperation "maxProperties">]
    member _.MaxProperties (state: OpenApiSchema, value) =
        state.MaxProperties <- Nullable value
        state

    [<CustomOperation "minProperties">]
    member _.MinProperties (state: OpenApiSchema, value) =
        state.MinProperties <- Nullable value
        state

    [<CustomOperation "additionalPropertiesAllowed">]
    member _.AdditionalPropertiesAllowed (state: OpenApiSchema, value) =
        state.AdditionalPropertiesAllowed <- value
        state

    [<CustomOperation "additionalProperties">]
    member _.AdditionalProperties (state: OpenApiSchema, value) =
        state.AdditionalProperties <- value
        state

    [<CustomOperation "discriminator">]
    member _.Discriminator (state: OpenApiSchema, value) =
        state.Discriminator <- value
        state

    [<CustomOperation "example">]
    member _.Example (state: OpenApiSchema, value) =
        state.Example <- value
        state

    [<CustomOperation "examples">]
    member _.Examples (state: OpenApiSchema, value) =
        Seq.iter state.Examples.Add value
        state

    [<CustomOperation "enums">]
    member _.Enums (state: OpenApiSchema, values: JsonNode seq) =
        Seq.iter state.Enum.Add values
        state

    [<CustomOperation "deprecated">]
    member _.Deprecated (state: OpenApiSchema, value) =
        state.Deprecated <- value
        state

    [<CustomOperation "xml">]
    member _.Xml (state: OpenApiSchema, value) =
        state.Xml <- value
        state

    [<CustomOperation "unrecognizedKeywords">]
    member _.UnrecognizedKeywords (state: OpenApiSchema, values: KVs<_, JsonNode>) =
        values |> Seq.iter state.UnrecognizedKeywords.Add
        state

    [<CustomOperation "extensions">]
    member _.Extension (state: OpenApiSchema, values: KVs<_, Interfaces.IOpenApiExtension>) =
        values |> Seq.iter state.Extensions.Add
        state

    [<CustomOperation "defaultValue">]
    member _.Default (state: OpenApiSchema, value) =
        state.Default <- value
        state

    [<CustomOperation "dependentRequired">]
    member _.DependentRequired (state: OpenApiSchema, values: KVs<_, Set<string>>) =
        values |> Seq.iter (fun (k, v) -> state.DependentRequired.Add(k, Collections.Generic.HashSet v))
        state

    [<CustomOperation "annotations">]
    member _.Annotations (state: OpenApiSchema, values: KVs<_, obj>) =
        values |> Seq.iter state.Annotations.Add
        state

