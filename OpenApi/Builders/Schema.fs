namespace OpenApi.Builders

open System
open Microsoft.OpenApi.Models

type SchemaBuilder () =

    member _.Yield _ =
        OpenApiSchema ()

    [<CustomOperation "title">]
    member _.Title (state: OpenApiSchema, value) =
        state.Title <- value
        state

    [<CustomOperation "type">]
    member _.Type (state: OpenApiSchema, value) =
        state.Type <- value
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

    [<CustomOperation "minimum">]
    member _.Minimum (state: OpenApiSchema, value) =
        state.Minimum <- Nullable value
        state

    [<CustomOperation "exclusiveMinimum">]
    member _.ExclusiveMinimum (state: OpenApiSchema, value) =
        state.ExclusiveMinimum <- Nullable value
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

    [<CustomOperation "not">]
    member _.Not (state: OpenApiSchema, value) =
        state.Not <- value
        state

    [<CustomOperation "required">]
    member _.Required (state: OpenApiSchema, value) =
        List.map state.Required.Add value |> ignore
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
    member _.Properties (state: OpenApiSchema, value: KVs<string, 'T>) =
        value |> List.iter state.Properties.Add
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

    [<CustomOperation "enums">]
    member _.Enums (state: OpenApiSchema, value) =
        List.iter state.Enum.Add value
        state

    [<CustomOperation "nullable">]
    member _.Nullable (state: OpenApiSchema, value) =
        state.Nullable <- value
        state

    [<CustomOperation "deprecated">]
    member _.Deprecated (state: OpenApiSchema, value) =
        state.Deprecated <- value
        state

    [<CustomOperation "xml">]
    member _.Xml (state: OpenApiSchema, value) =
        state.Xml <- value
        state

    [<CustomOperation "extensions">]
    member _.Extension (state: OpenApiSchema, value: KVs<string, 'T>) =
        value |> List.iter state.Extensions.Add
        state

    [<CustomOperation "unresolvedReference">]
    member _.UnresolvedReference (state: OpenApiSchema, value) =
        state.UnresolvedReference <- value
        state

    [<CustomOperation "reference">]
    member _.Reference (state: OpenApiSchema, value) =
        state.Reference <- value
        state
