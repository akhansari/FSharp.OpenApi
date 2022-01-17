namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type PathItemBuilder () =

    member _.Yield _ =
        OpenApiPathItem ()

    /// An optional, string summary, intended to apply to all operations in this path.
    [<CustomOperation "summary">]
    member _.Summary (state: OpenApiPathItem, value) =
        state.Summary <- value
        state

    /// An optional, string description, intended to apply to all operations in this path. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiPathItem, value) =
        state.Description <- value
        state

    /// A definition of a HTTP operation on this path.
    [<CustomOperation "operations">]
    member _.Operations (state: OpenApiPathItem, value: KVs<_, OpenApiOperation>) =
        value |> Seq.iter state.Operations.Add
        state

    /// An alternative server array to service all operations in this path.
    [<CustomOperation "servers">]
    member _.Servers (state: OpenApiPathItem, value: OpenApiServer seq) =
        value |> Seq.iter state.Servers.Add
        state

    /// A list of parameters that are applicable for all the operations described under this path.
    /// These parameters can be overridden at the operation level, but cannot be removed there.
    /// The list MUST NOT include duplicated parameters.
    /// A unique parameter is defined by a combination of a name and location.
    /// The list can use the Reference Object to link to parameters that are defined at the OpenAPI Object's components/parameters.
    [<CustomOperation "parameters">]
    member _.Parameters (state: OpenApiPathItem, value: OpenApiParameter seq) =
        value |> Seq.iter state.Parameters.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiPathItem, value: KVs<_, Interfaces.IOpenApiExtension>) =
        value |> Seq.iter state.Extensions.Add
        state

type PathsBuilder () =

    member _.Yield _ =
        OpenApiPaths ()

    [<CustomOperation "pathItems">]
    member _.PathItems (state: OpenApiPaths, value: KVs<_, OpenApiPathItem>) =
        value |> Seq.iter state.Add
        state
