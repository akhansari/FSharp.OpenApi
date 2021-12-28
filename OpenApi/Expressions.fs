[<AutoOpen>]
module OpenApi.Expressions

open OpenApi.Builders

(*
    Documentation from version 3.0.3
    https://swagger.io/specification/
*)

/// A map of possible out-of band callbacks related to the parent operation.
let apiCallback = CallbackBuilder ()

/// Holds a set of reusable objects for different aspects of the OAS.
/// All objects defined within the components object will have no effect on the API
/// unless they are explicitly referenced from properties outside the components object.
let apiComponents = ComponentsBuilder ()

/// Contact information for the exposed API.
let apiContact = ContactBuilder ()

/// When request bodies or response payloads may be one of a number of different schemas,
/// a discriminator object can be used to aid in serialization, deserialization, and validation.
/// The discriminator is a specific object in a schema which is used
/// to inform the consumer of the specification of an alternative schema based on the value associated with it.
/// When using the discriminator, inline schemas will not be considered.
let apiDiscriminator = DiscriminatorBuilder ()

let apiDocument = DocumentBuilder ()

/// A single encoding definition applied to a single schema property.
let apiEncoding = EncodingBuilder ()

/// Example object.
let apiExample = ExampleBuilder ()

/// Allows referencing an external resource for extended documentation.
let apiExternalDocs = ExternalDocsBuilder ()

/// The Header Object follows the structure of the Parameter object.
let apiHeader = HeaderBuilder ()

/// The object provides metadata about the API.
/// The metadata MAY be used by the clients if needed,
/// and MAY be presented in editing or documentation generation tools for convenience.
let apiInfo = InfoBuilder ()

/// License information for the exposed API.
let apiLicense = LicenseBuilder ()

/// The Link object represents a possible design-time link for a response.
/// The presence of a link does not guarantee the caller's ability to successfully invoke it,
/// rather it provides a known relationship and traversal mechanism between responses and other operations.
/// Unlike dynamic links (i.e. links provided in the response payload),
/// the OAS linking mechanism does not require link information in the runtime response.
let apiLink = LinkBuilder ()

/// Each Media Type Object provides schema and examples for the media type identified by its key.
let apiMediaType = MediaTypeBuilder ()

/// Configuration details for a supported OAuth Flow
let apiOAuthFlow = OAuthFlowBuilder ()

/// Allows configuration of the supported OAuth Flows.
let apiOAuthFlows = OAuthFlowsBuilder ()

/// Describes a single API operation on a path.
let apiOperation = OperationBuilder ()

/// Describes a single operation parameter.
/// A unique parameter is defined by a combination of a name and location.
let apiParameter = ParameterBuilder ()

/// Describes the operations available on a single path.
/// A Path Item MAY be empty, due to ACL constraints.
/// The path itself is still exposed to the documentation viewer
/// but they will not know which operations and parameters are available.
let apiPathItem = PathItemBuilder ()

/// Holds the relative paths to the individual endpoints and their operations.
/// The path is appended to the URL from the Server Object in order to construct the full URL.
/// The Paths MAY be empty, due to ACL constraints.
let apiPaths = PathsBuilder ()

let apiReference = ReferenceBuilder ()

/// Describes a single request body.
let apiRequestBody = RequestBodyBuilder ()

/// Describes a single response from an API Operation, including design-time, static links to operations based on the response.
let apiResponse = ResponseBuilder ()

/// A container for the expected responses of an operation.
/// The container maps a HTTP response code to the expected response.
let apiResponses = ResponsesBuilder ()

/// The Schema Object allows the definition of input and output data types.
let apiSchema = SchemaBuilder ()

/// Lists the required security schemes to execute this operation.
let apiSecurityRequirement = SecurityRequirementBuilder ()

/// Defines a security scheme that can be used by the operations.
/// Supported schemes are HTTP authentication, an API key (either as a header, a cookie parameter or as a query parameter),
/// OAuth2's common flows (implicit, password, client credentials and authorization code) as defined in RFC6749, and OpenID Connect Discovery.
let apiSecurityScheme = SecuritySchemeBuilder ()

/// An object representing a Server.
let apiServer = ServerBuilder ()

/// An object representing a Server Variable for server URL template substitution.
let apiServerVariable = ServerVariableBuilder ()

let apiTag = TagBuilder ()
