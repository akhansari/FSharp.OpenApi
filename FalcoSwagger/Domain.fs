namespace FalcoSwagger

type Power =
    { Kind: string }

type SuperbeingInfo =
    { Name: string
      Powers: Power list }

type Superbeing =
    | Superhero of SuperbeingInfo
    | Supervillain of SuperbeingInfo
