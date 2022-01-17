namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type CallbackBuilder () =

    member _.Yield _ =
        OpenApiCallback ()

    /// Describes a set of requests that may be initiated by the API provider and the expected responses.
    /// The key value used to identify the path item object is an expression, evaluated at runtime,
    /// that identifies a URL to use for the callback operation.
    [<CustomOperation "pathItems">]
    member _.PathItems (state: OpenApiCallback, value: KVs<Expressions.RuntimeExpression, OpenApiPathItem>) =
        value |> Seq.iter state.PathItems.Add
        state

    [<CustomOperation "unresolvedReference">]
    member _.UnresolvedReference (state: OpenApiCallback, value) =
        state.UnresolvedReference <- value
        state

    [<CustomOperation "reference">]
    member _.Reference (state: OpenApiCallback, value) =
        state.Reference <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiCallback, value: KVs<_, Interfaces.IOpenApiExtension>) =
        value |> Seq.iter state.Extensions.Add
        state
