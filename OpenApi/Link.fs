namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type LinkBuilder () =

    member _.Yield _ =
        OpenApiLink ()

    /// A relative or absolute URI reference to an OAS operation.
    /// This field is mutually exclusive of the operationId field, and MUST point to an Operation Object.
    /// Relative operationRef values MAY be used to locate an existing Operation Object in the OpenAPI definition.
    [<CustomOperation "operationRef">]
    member _.OperationRef (state: OpenApiLink, value) =
        state.OperationRef <- value
        state

    /// The name of an existing, resolvable OAS operation, as defined with a unique operationId.
    /// This field is mutually exclusive of the operationRef field.
    [<CustomOperation "operationId">]
    member _.OperationId (state: OpenApiLink, value) =
        state.OperationId <- value
        state

    /// A map representing parameters to pass to an operation as specified with operationId or identified via operationRef.
    /// The key is the parameter name to be used, whereas the value can be a constant or an expression
    /// to be evaluated and passed to the linked operation.
    /// The parameter name can be qualified using the parameter location [{in}.]{name} for operations
    /// that use the same parameter name in different locations (e.g. path.id).
    [<CustomOperation "addParameter">]
    member _.Parameters (state: OpenApiLink, key, value) =
        state.Parameters.Add (key, value)
        state

    /// A literal value or {expression} to use as a request body when calling the target operation.
    [<CustomOperation "requestBody">]
    member _.RequestBody (state: OpenApiLink, value) =
        state.RequestBody <- value
        state

    /// A description of the link. CommonMark syntax MAY be used for rich text representation.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiLink, value) =
        state.Description <- value
        state

    /// A server object to be used by the target operation.
    [<CustomOperation "server">]
    member _.Server (state: OpenApiLink, value) =
        state.Server <- value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiLink, key, value) =
        state.Extensions.Add (key, value)
        state

    [<CustomOperation "unresolvedReference">]
    member _.UnresolvedReference (state: OpenApiLink, value) =
        state.UnresolvedReference <- value
        state

    [<CustomOperation "reference">]
    member _.Reference (state: OpenApiLink, value) =
        state.Reference <- value
        state
