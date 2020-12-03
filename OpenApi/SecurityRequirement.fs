namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type SecurityRequirementBuilder () =

    member _.Yield _ =
        OpenApiSecurityRequirement ()

    [<CustomOperation "addSecurityRequirement">]
    member _.SecurityRequirement (state: OpenApiSecurityRequirement, key, value) =
        state.Add (key, value)
        state
