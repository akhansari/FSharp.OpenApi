namespace Sample

type Power =
    { Kind: string }

type SuperbeingInfo =
    { Name: string
      Powers: Power list }

type Superbeing =
    | Superhero of SuperbeingInfo
    | Supervillain of SuperbeingInfo

module Repo =
    open System.Collections.Concurrent

    let db = ConcurrentBag ()
    let add superbeing = db.Add superbeing
    let addRange superbeings = Seq.iter db.Add superbeings
    let getAll () = List.ofSeq db

    let addSamples () =
        addRange
            [ Superhero { Name = "Bruce Wayne"; Powers = [ { Kind = "Genius intellect" } ] }
              Superhero { Name = "Barry Allen"; Powers = [ { Kind = "Speed force" } ] }
              Supervillain { Name = "Joker"; Powers = [ { Kind = "Criminal mastermind" } ] }
              Supervillain { Name = "Eobard Thawne"; Powers = [ { Kind = "Negative speed force" } ] } ]

    addSamples ()
