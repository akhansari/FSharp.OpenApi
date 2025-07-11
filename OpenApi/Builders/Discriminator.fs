namespace OpenApi.Builders

open System.Collections.Generic
open Microsoft.OpenApi

type DiscriminatorBuilder () =

    member _.Yield _ =
        OpenApiDiscriminator ()

    /// REQUIRED. The name of the property in the payload that will hold the discriminator value.
    [<CustomOperation "propertyName">]
    member _.PropertyName (state: OpenApiDiscriminator, value) =
        state.PropertyName <- value
        state

    /// An object to hold mappings between payload values and schema names or references.
    [<CustomOperation "mapping">]
    member _.Mapping (state: OpenApiDiscriminator, values: KVs<_, OpenApiSchemaReference>) =
        if isNull state.Mapping then state.Mapping <- Dictionary()
        values |> Seq.iter state.Mapping.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiDiscriminator, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
