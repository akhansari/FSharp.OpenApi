[<RequireQualifiedAccess>]
module FalcoSwagger.JsonSerializer

open System.Text.Json
open System.Text.Json.Serialization

let setupOptions (opt: JsonSerializerOptions) =
    opt.PropertyNamingPolicy <- JsonNamingPolicy.CamelCase
    opt.Converters.Add(JsonStringEnumConverter())
    opt.Converters.Add(
        JsonFSharpConverter(
            JsonUnionEncoding.FSharpLuLike,
            unionTagNamingPolicy = JsonNamingPolicy.CamelCase))
    opt.IgnoreNullValues <- true
    opt

let createOptions () =
    JsonSerializerOptions ()
    |> setupOptions

let options =
    createOptions ()

let serialize value =
    JsonSerializer.Serialize (value, options)

let deserialize<'T> (json: string) =
    JsonSerializer.Deserialize<'T> (json, options)

