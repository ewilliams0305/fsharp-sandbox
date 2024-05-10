
// Comprehension
let data = [1..10] // 1 - 10
let data1 = [1..3..10] // 1 - 10
let data2 = [for i in 1..10 do i]


// Add Items (imutable)
let newData = 1::data // Added to the start [1][1..10]

// Pattern Match
let getList items =
    match items with
    | [] -> "Empty"
    | [item] -> $"List with single item {item}"
    | head::tail -> $"head {head} tail {tail}"

getList []
getList ["single"]
getList [1;2;3]

// Module vs Dot
data.Head

data |> List.head

// Init the list
let rnd = System.Random()
let myList = List.init 200 (fun i -> (i, rnd.Next(200)))

// Filter

let myList2 = 
    List.init 200 (fun i -> (i, rnd.Next(200))) 
    |> List.filter (fun (x , y) -> y % 2 = 0) 
    |> List.filter (fun (x , y) -> x % 2 = 0) 
    |> List.map (fun (x, y) -> x + y)

// Map (see above)
[1..10] 
|> List.map (fun i -> i * 2)
|> List.map (fun i -> sprintf $"{i} string")

// Reduce and Fold
[1..10] |> List.reduce (fun accu item -> accu + item)

[1..10] |> List.fold (fun accu item -> accu + item) 10

[] |> List.reduce (fun accu item -> accu + item) // -> Exception

[] |> List.fold (fun accu item -> accu + item) 10

// Groupby
[1..10] @ [5..10] |> List.groupBy (fun x -> x)

// Iter foreach...
[1..10] |> List.iter (fun x -> printfn $"ITEM: {x}")

// Partial vs Complete
let bad1: int = [] |> List.head
let bad2: int option = [] |> List.tryHead

// Composition return sum of squares of the odd numbers

let nums = [1..10]

// filter -> map -> sum
nums 
|> List.filter (fun x -> x % 2 = 1)
|> List.map (fun x -> x * x)
|> List.sum
// Choose
nums
|> List.choose (fun x -> if x % 2 = 1 then Some (x * x) else None)
|> List.sum
// Reduce
nums 
|> List.reduce (fun acc item -> acc + if item % 2 = 1 then (item * item) else 0 )
// Fold
nums 
|> List.fold (fun acc item -> acc + if item % 2 = 1 then (item * item) else 0 ) 0
// Sum By
nums
|> List.sumBy (fun x -> 
    if x % 2 = 1 then (x * x) else 0 )

// FizzBuzz
let fizzBuzz input =
    [(3, "Fizz"); (5, "Buzz")]
    |> List.map (fun (value, message) -> if input % value = 0 then message else "" )
    |> List.reduce (fun acc item -> acc + item )
    |> fun value -> if value <> "" then value else string input 

fizzBuzz 1
fizzBuzz 3
fizzBuzz 15
fizzBuzz 5

[1..1_000_000] |> List.map fizzBuzz

// Convert
List.toArray
List.toSeq

Array.ofList
Seq.ofList
