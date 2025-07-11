[<AutoOpen>]
module Tools

open System.IO
open Xunit
open Microsoft.OpenApi

let private eq<'T> (actual: 'T) (expected: 'T) = Assert.Equal(actual, expected)
let (=!) expected actual = eq actual expected

let private eqStr (actual: string) (expected: string) = Assert.Equal(actual, expected, ignoreAllWhiteSpace = true)
let (=~!) expected actual = eqStr actual expected

let toYaml (value: 'T when 'T :> IOpenApiSerializable) =
    use stringWriter = new StringWriter()
    let writer = OpenApiYamlWriter(stringWriter)
    value.SerializeAsV31(writer)
    stringWriter.ToString()