namespace OpenApi.Builders

open Microsoft.OpenApi
open Microsoft.OpenApi.Models

type ContactBuilder () =

    member _.Yield _ =
        OpenApiContact ()

    /// The identifying name of the contact person/organization.
    [<CustomOperation "name">]
    member _.Name (state: OpenApiContact, value) =
        state.Name <- value
        state

    /// The URL pointing to the contact information.
    [<CustomOperation "url">]
    member _.Url (state: OpenApiContact, value) =
        state.Url <- value
        state

    /// The email address of the contact person/organization.
    [<CustomOperation "email">]
    member _.Email (state: OpenApiContact, value) =
        state.Email <- value
        state

    [<CustomOperation "extensions">]
    member _.Extensions (state: OpenApiContact, value: KVs<_, Interfaces.IOpenApiExtension>) =
        value |> Seq.iter state.Extensions.Add
        state
