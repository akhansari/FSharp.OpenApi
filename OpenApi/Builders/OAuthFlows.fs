namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type OAuthFlowsBuilder () =

    member _.Yield _ =
        OpenApiOAuthFlows ()

    /// Configuration for the OAuth Implicit flow.
    [<CustomOperation "implicit">]
    member _.Implicit (state: OpenApiOAuthFlows, value) =
        state.Implicit <- value
        state

    /// Configuration for the OAuth Resource Owner Password flow.
    [<CustomOperation "password">]
    member _.Password (state: OpenApiOAuthFlows, value) =
        state.Password <- value
        state

    /// Configuration for the OAuth Client Credentials flow.
    [<CustomOperation "clientCredentials">]
    member _.ClientCredentials (state: OpenApiOAuthFlows, value) =
        state.ClientCredentials <- value
        state

    /// Configuration for the OAuth Authorization Code flow.
    [<CustomOperation "authorizationCode">]
    member _.AuthorizationCode (state: OpenApiOAuthFlows, value) =
        state.AuthorizationCode <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiOAuthFlows, value: KVs<string, 'T>) =
        value |> List.iter state.Extensions.Add
        state
