#r "nuget: Microsoft.CodeAnalysis.CSharp, 5.9.0"

open System
open System.IO
open Microsoft.CodeAnalysis.CSharp
open Microsoft.CodeAnalysis.CSharp.Syntax

let models =
    let modelsPath = Path.Combine(__SOURCE_DIRECTORY__, "..", "..", "..", "pb", "OpenAPI.NET", "src", "Microsoft.OpenApi", "Models")
    Directory.EnumerateFiles(modelsPath, "OpenApi*.cs")
    |> Seq.map (fun path -> {| Path = path; Name = Path.GetFileNameWithoutExtension(path).Replace("OpenApi", "") |})
    |> Seq.toList

let builders =
    let excluded =
        Set [ "Constants"
              "ExtensibleDictionary"
              "ReferenceWithDescription"
              "ReferenceWithDescriptionAndSummary" ]
    let buildersPath = Path.Combine(__SOURCE_DIRECTORY__, "..", "OpenApi", "Builders")
    models
    |> List.filter (fun model -> excluded |> Set.contains model.Name |> not)
    |> List.map (fun model ->
        {| Name = model.Name
           ModelPath = model.Path
           Path = Path.Combine(buildersPath, model.Name + ".fs") |})

let getPublicProperties (modelPath: string) =
    let code = File.ReadAllText modelPath
    let root = CSharpSyntaxTree.ParseText(code).GetRoot()
    let hasPublicSetter (prop: PropertyDeclarationSyntax) =
        if isNull prop.AccessorList then false
        else
            prop.AccessorList.Accessors
            |> Seq.exists (fun accessor ->
                accessor.Kind() = SyntaxKind.SetAccessorDeclaration
                && accessor.Modifiers
                   |> Seq.exists (fun modifier ->
                       modifier.Kind() = SyntaxKind.InternalKeyword
                       || modifier.Kind() = SyntaxKind.PrivateKeyword
                       || modifier.Kind() = SyntaxKind.ProtectedKeyword)
                   |> not)

    root.DescendantNodes()
    |> Seq.choose (function 
        | :? PropertyDeclarationSyntax as prop when
                prop.Modifiers |> Seq.exists (fun m -> m.Kind() = SyntaxKind.PublicKeyword)
                && hasPublicSetter prop ->
            Some prop.Identifier.Text
        | _ -> None)
    |> Seq.toList

printfn "Not implemented:\n"

for builder in builders do
    let code = if File.Exists builder.Path then File.ReadAllText builder.Path else ""
    let props = getPublicProperties builder.ModelPath
    for prop in props do
        if code.Contains($"state.{prop}", StringComparison.OrdinalIgnoreCase) |> not then
            printfn "%s.%s" builder.Name prop 

printfn "\nDone."
