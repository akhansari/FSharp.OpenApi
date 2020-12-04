namespace OpenApi.Builders

open Microsoft.OpenApi.Models

type SecurityRequirementBuilder () =

    member _.Yield _ =
        OpenApiSecurityRequirement ()

    [<CustomOperation "securityRequirements">]
    member _.SecurityRequirements (state: OpenApiSecurityRequirement, value: KVs<OpenApiSecurityScheme, string list>) =
        value |> List.iter (fun (k, v) -> state.Add (k, ResizeArray v))
        state
