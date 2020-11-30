namespace OpenApi.Builders

open System.Net
open Microsoft.OpenApi.Models

type OperationBuilder () =

    member _.Yield _ =
        OpenApiOperation ()

    [<CustomOperation "addTag">]
    member _.Tag (state: OpenApiOperation, value) =
        state.Tags.Add value
        state

    [<CustomOperation "summary">]
    member _.Summary (state: OpenApiOperation, value) =
        state.Summary <- value
        state

    [<CustomOperation "description">]
    member _.Description (state: OpenApiOperation, value) =
        state.Description <- value
        state

    [<CustomOperation "externalDocs">]
    member _.ExternalDocs (state: OpenApiOperation, value) =
        state.ExternalDocs <- value
        state

    [<CustomOperation "operationId">]
    member _.OperationId (state: OpenApiOperation, value) =
        state.OperationId <- value
        state

    [<CustomOperation "addParameter">]
    member _.Parameters (state: OpenApiOperation, value) =
        state.Parameters.Add value
        state

    [<CustomOperation "requestBody">]
    member _.RequestBody (state: OpenApiOperation, value) =
        state.RequestBody <- value
        state

    [<CustomOperation "addResponse">]
    member _.Response (state: OpenApiOperation, (key: HttpStatusCode), value) =
        state.Responses.Add (string key, value)
        state

    [<CustomOperation "addCallback">]
    member _.CallBack (state: OpenApiOperation, key, value) =
        state.Callbacks.Add (key, value)
        state

    [<CustomOperation "deprecated">]
    member _.Deprecated (state: OpenApiOperation, value) =
        state.Deprecated <- value
        state

    [<CustomOperation "addSecurity">]
    member _.Security (state: OpenApiOperation, value) =
        state.Security.Add value
        state

    [<CustomOperation "addServer">]
    member _.Server (state: OpenApiOperation, value) =
        state.Servers.Add value
        state

    [<CustomOperation "addExtension">]
    member _.Extension (state: OpenApiOperation, key, value) =
        state.Extensions.Add (key, value)
        state
