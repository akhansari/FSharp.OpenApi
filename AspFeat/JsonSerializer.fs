[<RequireQualifiedAccess>]
module AspFeat.JsonSerializer

open System.Text.Json
open System.Text.Json.Serialization

let setupOptions (opt: JsonSerializerOptions) =
    opt.PropertyNamingPolicy <- JsonNamingPolicy.CamelCase
    opt.Converters.Add(JsonStringEnumConverter())
    opt.Converters.Add(
        JsonFSharpConverter(
            JsonUnionEncoding.FSharpLuLike,
            unionTagCaseInsensitive = true,
            unionTagNamingPolicy = JsonNamingPolicy.CamelCase))
    opt.IgnoreNullValues <- true
    opt

let createOptions () =
    JsonSerializerOptions ()
    |> setupOptions
