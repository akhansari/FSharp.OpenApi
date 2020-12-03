namespace OpenApi.Builders

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
    [<CustomOperation "addOperation">]
    member _.Operations (state: OpenApiPathItem, key, value) =
        state.Operations.Add (key, value)
        state

    /// An alternative server array to service all operations in this path.
    [<CustomOperation "addServer">]
    member _.Servers (state: OpenApiPathItem, value) =
        state.Servers.Add value
        state

    /// A list of parameters that are applicable for all the operations described under this path.
    /// These parameters can be overridden at the operation level, but cannot be removed there.
    /// The list MUST NOT include duplicated parameters.
    /// A unique parameter is defined by a combination of a name and location.
    /// The list can use the Reference Object to link to parameters that are defined at the OpenAPI Object's components/parameters.
    [<CustomOperation "addParameter">]
    member _.Parameters (state: OpenApiPathItem, value) =
        state.Parameters.Add value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiPathItem, key, value) =
        state.Extensions.Add (key, value)
        state

type PathsBuilder () =

    member _.Yield _ =
        OpenApiPaths ()

    [<CustomOperation "addPathItem">]
    member _.Extensions (state: OpenApiPaths, key, value) =
        state.Add (key, value)
        state
