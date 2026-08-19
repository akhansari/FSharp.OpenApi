namespace OpenApi.Builders

open System.Collections.Generic
open Microsoft.OpenApi

type OAuthFlowBuilder () =

    member _.Yield _ =
        OpenApiOAuthFlow ()

    /// REQUIRED. The authorization URL to be used for this flow. This MUST be in the form of a URL.
    [<CustomOperation "authorizationUrl">]
    member _.AuthorizationUrl (state: OpenApiOAuthFlow, value) =
        state.AuthorizationUrl <- value
        state

    /// REQUIRED. The token URL to be used for this flow. This MUST be in the form of a URL.
    [<CustomOperation "tokenUrl">]
    member _.TokenUrl (state: OpenApiOAuthFlow, value) =
        state.TokenUrl <- value
        state

    /// The URL to be used for obtaining refresh tokens. This MUST be in the form of a URL.
    [<CustomOperation "refreshUrl">]
    member _.RefreshUrl (state: OpenApiOAuthFlow, value) =
        state.RefreshUrl <- value
        state

    /// REQUIRED for device authorization flows. The device authorization endpoint URL.
    [<CustomOperation "deviceAuthorizationUrl">]
    member _.DeviceAuthorizationUrl (state: OpenApiOAuthFlow, value) =
        state.DeviceAuthorizationUrl <- value
        state

    /// The available scopes for the OAuth2 security scheme.
    /// A map between the scope name and a short description for it. The map MAY be empty.
    [<CustomOperation "scopes">]
    member _.Scopes (state: OpenApiOAuthFlow, values: KVs<string, string>) =
        if isNull state.Scopes then state.Scopes <- Dictionary()
        values |> Seq.iter state.Scopes.Add
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiOAuthFlow, values: KVs<_, IOpenApiExtension>) =
        if isNull state.Extensions then state.Extensions <- Dictionary()
        values |> Seq.iter state.Extensions.Add
        state
