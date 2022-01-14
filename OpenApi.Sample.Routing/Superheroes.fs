module Repo

open System
open System.Collections.Concurrent

type Power =
    { Kind: string }

type Superhero =
    { Name: string
      AlterEgo: string
      Powers: Power list }

let private db = ConcurrentBag ()

let private addSamples () =
    [ { Name = "Batman"; AlterEgo = "Bruce Wayne"; Powers = [ { Kind = "Genius intellect" }; { Kind = "Expert detective" } ] }
      { Name = "Flash"; AlterEgo = "Barry Allen"; Powers = [ { Kind = "Speed force" } ] } ]
    |> Seq.iter db.Add
addSamples ()

let add hero = db.Add hero
let getAll () = List.ofSeq db
let get name = Seq.tryFind (fun h -> String.Compare(h.Name, name, true) = 0) db
