namespace OpenApi.Builders

open Microsoft.OpenApi

type SecurityRequirementBuilder () =

    member _.Yield _ =
        OpenApiSecurityRequirement ()

    [<CustomOperation "securityRequirements">]
    member _.SecurityRequirements (state: OpenApiSecurityRequirement, values: KVs<OpenApiSecuritySchemeReference, string seq>) =
        values |> Seq.iter (fun (k, v) -> state.Add(k, ResizeArray v))
        state
