let rnd = System.Random()

let data =
    List.init 10 (fun i -> (i, rnd.Next(100)))
    |> Map

data[1]

data |> Map.tryFind 11  
data |> Map.tryFind 9  

data.Keys

let dick =
    List.init 10 (fun i -> (i, rnd.Next(100)))
    |> dict

let onlyDick =
    List.init 10 (fun i -> (i, rnd.Next(100)))
    |> readOnlyDict