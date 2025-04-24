namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

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
    member _.Mapping (state: OpenApiDiscriminator, values: KVs<_, string>) =
        values |> Seq.iter state.Mapping.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiDiscriminator, values: KVs<_, Interfaces.IOpenApiExtension>) =
        values |> Seq.iter state.Extensions.Add
        state
