module BuilderConversionTests

open System.Text.Json.Nodes
open Microsoft.OpenApi
open OpenApi
open Xunit

[<Fact>]
let ``empty document initializes Paths`` () =
    let document = apiDocument { yield () }

    Assert.NotNull document.Paths
    Assert.Empty document.Paths

[<Fact>]
let ``schemaType populates the nullable schema type`` () =
    let schema = apiSchema {
        schemaType JsonSchemaType.String
    }

    Assert.True schema.Type.HasValue
    Assert.Equal(JsonSchemaType.String, schema.Type.Value)

[<Fact>]
let ``schema example and examples accumulate values`` () =
    let first = JsonValue.Create "first"
    let second = JsonValue.Create "second"

    let schema = apiSchema {
        example first
        examples [ second ]
    }

    Assert.Equal(2, schema.Examples.Count)
    Assert.Same(first, schema.Examples[0])
    Assert.Same(second, schema.Examples[1])

[<Fact>]
let ``dependentRequired converts FSharp sets to schema sets`` () =
    let schema = apiSchema {
        dependentRequired [ "creditCard", Set [ "billingAddress"; "securityCode" ] ]
    }

    let required = schema.DependentRequired["creditCard"]
    Assert.Equal(2, required.Count)
    Assert.Contains("billingAddress", required)
    Assert.Contains("securityCode", required)

[<Fact>]
let ``parameter location populates the nullable location`` () =
    let parameter = apiParameter {
        location ParameterLocation.Query
    }

    Assert.True parameter.In.HasValue
    Assert.Equal(ParameterLocation.Query, parameter.In.Value)

[<Fact>]
let ``encoding flags populate nullable values`` () =
    let encoding = apiEncoding {
        explode true
        allowReserved false
    }

    Assert.True encoding.Explode.HasValue
    Assert.True encoding.Explode.Value
    Assert.True encoding.AllowReserved.HasValue
    Assert.False encoding.AllowReserved.Value

[<Fact>]
let ``attribute true selects the XML attribute node type`` () =
    let xml = apiXml {
        attribute true
    }

    Assert.True xml.NodeType.HasValue
    Assert.Equal(OpenApiXmlNodeType.Attribute, xml.NodeType.Value)

[<Fact>]
let ``attribute false clears the XML node type`` () =
    let xml = apiXml {
        attribute false
    }

    Assert.False xml.NodeType.HasValue
