namespace OpenApi.Builders

open System.Net
open Microsoft.OpenApi.Models

type OperationBuilder () =

    member _.Yield _ =
        OpenApiOperation ()

    /// REQUIRED. The list of possible responses as they are returned from executing this operation.
    [<CustomOperation "addResponse">]
    member _.Responses (state: OpenApiOperation, (key: HttpStatusCode), value) =
        state.Responses.Add (string key, value)
        state
    member _.Responses (state: OpenApiOperation, key, value) =
        state.Responses.Add (key, value)
        state

    /// A list of tags for API documentation control.
    /// Tags can be used for logical grouping of operations by resources or any other qualifier.
    [<CustomOperation "addTag">]
    member _.Tags (state: OpenApiOperation, value) =
        state.Tags.Add value
        state

    /// A short summary of what the operation does.
    [<CustomOperation "summary">]
    member _.Summary (state: OpenApiOperation, value) =
        state.Summary <- value
        state

    /// A verbose explanation of the operation behavior. CommonMark syntax.
    [<CustomOperation "description">]
    member _.Description (state: OpenApiOperation, value) =
        state.Description <- value
        state

    /// Additional external documentation for this operation.
    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiOperation, value) =
        state.ExternalDocs <- value
        state

    /// Unique string used to identify the operation.
    /// The id MUST be unique among all operations described in the API.
    /// The operationId value is case-sensitive.
    /// Tools and libraries MAY use the operationId to uniquely identify an operation,
    /// therefore, it is RECOMMENDED to follow common programming naming conventions.
    [<CustomOperation "operationId">]
    member _.OperationId (state: OpenApiOperation, value) =
        state.OperationId <- value
        state

    /// A list of parameters that are applicable for this operation.
    /// If a parameter is already defined at the Path Item,
    /// the new definition will override it but can never remove it.
    /// The list MUST NOT include duplicated parameters.
    /// A unique parameter is defined by a combination of a name and location.
    /// The list can use the Reference Object to link to parameters that are defined at the OpenAPI Object's components/parameters.
    [<CustomOperation "addParameter">]
    member _.Parameters (state: OpenApiOperation, value) =
        state.Parameters.Add value
        state

    /// The request body applicable for this operation.
    /// The requestBody is only supported in HTTP methods where the HTTP 1.1 specification RFC7231 has explicitly defined semantics for request bodies.
    /// In other cases where the HTTP spec is vague, requestBody SHALL be ignored by consumers.
    [<CustomOperation "requestBody">]
    member _.RequestBody (state: OpenApiOperation, value) =
        state.RequestBody <- value
        state

    /// A map of possible out-of band callbacks related to the parent operation.
    /// The key is a unique identifier for the Callback Object.
    /// Each value in the map is a Callback Object that describes a request
    /// that may be initiated by the API provider and the expected responses.
    [<CustomOperation "addCallback">]
    member _.CallBack (state: OpenApiOperation, key, value) =
        state.Callbacks.Add (key, value)
        state

    /// Declares this operation to be deprecated. Consumers SHOULD refrain from usage of the declared operation.
    /// Default value is false.
    [<CustomOperation "deprecated">]
    member _.Deprecated (state: OpenApiOperation, value) =
        state.Deprecated <- value
        state

    /// A declaration of which security mechanisms can be used for this operation.
    /// The list of values includes alternative security requirement objects that can be used.
    /// Only one of the security requirement objects need to be satisfied to authorize a request.
    /// To make security optional, an empty security requirement ({}) can be included in the array.
    /// This definition overrides any declared top-level security.
    /// To remove a top-level security declaration, an empty array can be used.
    [<CustomOperation "addSecurity">]
    member _.Security (state: OpenApiOperation, value) =
        state.Security.Add value
        state

    /// An alternative server array to service this operation.
    /// If an alternative server object is specified at the Path Item Object or Root level,
    /// it will be overridden by this value.
    [<CustomOperation "addServer">]
    member _.Servers (state: OpenApiOperation, value) =
        state.Servers.Add value
        state

    [<CustomOperation "addExtension">]
    member _.Extensions (state: OpenApiOperation, key, value) =
        state.Extensions.Add (key, value)
        state
