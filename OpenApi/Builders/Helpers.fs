namespace OpenApi.Builders

type private KVs<'TKey, 'TValue> = ('TKey * 'TValue) seq

module internal MediaTypes =

    let [<Literal>] Json = "application/json"
