namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type XmlBuilder () =

    member _.Yield _ =
        OpenApiXml()

    [<CustomOperation "name">]
    member _.Name (state: OpenApiXml, value) =
        state.Name <- value
        state

    [<CustomOperation "namespace">]
    member _.Namespace (state: OpenApiXml, value) =
        state.Namespace <- value
        state

    [<CustomOperation "prefix">]
    member _.Prefix (state: OpenApiXml, value) =
        state.Prefix <- value
        state

    [<CustomOperation "attribute">]
    member _.Attribute (state: OpenApiXml, value) =
        state.Attribute <- value
        state

    [<CustomOperation "Wrapped">]
    member _.Wrapped (state: OpenApiXml, value) =
        state.Wrapped <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiXml, values: KVs<_, Interfaces.IOpenApiExtension>) =
        values |> Seq.iter state.Extensions.Add
        state
