namespace OpenApi.Builders

open System.Collections.Generic
open Microsoft.OpenApi

type CallbackBuilder () =

    member _.Yield _ =
        OpenApiCallback ()

    /// Describes a set of requests that may be initiated by the API provider and the expected responses.
    /// The key value used to identify the path item object is an expression, evaluated at runtime,
    /// that identifies a URL to use for the callback operation.
    [<CustomOperation "pathItems">]
    member _.PathItems (state: OpenApiCallback, values: KVs<RuntimeExpression, OpenApiPathItem>) =
        if isNull state.PathItems then state.PathItems <- Dictionary()
        values |> Seq.iter state.PathItems.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiCallback, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
