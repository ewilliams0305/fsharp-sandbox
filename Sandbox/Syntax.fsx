open System
open System.Linq


printf "What is your name:"
let name = Console.ReadLine()
printfn "Hello from %s" name


let x = 42

let add x y = x + y
add 12 32


let square x =
    x * 2 

square 10    


let double x = 
    let two : int = 2
    x * two

double 12

let squareAndDouble x =
    x 
    |> square 
    |> double 
    |> add 2

squareAndDouble 10

// LINQ
// PIPELINE

let arrary = [1..20]

arrary
|> List.map (fun x -> x * 2)
|> List.filter(fun x -> x <= 6)
|> List.map (fun x -> sprintf "x=%i" x)

// ADD FUNCTONS TO PIPELINE

let filterGreater x = 
    List.filter(fun y -> y <= x)

arrary
|> List.map (fun x -> x * 2)
|> filterGreater 20
|> List.map (fun x -> sprintf "x=%i" x)

let product aList =
    List.fold (*) 1 aList

let logToConsole input =
    printfn "input=%i" input

arrary
|> List.map (fun x -> x * 2)
|> filterGreater 20
|> product
|> logToConsole

(***********************************

SOLID (Open close pricipal)
IO work at the edges (integration tests test the whole work)
Business logic in the middle (Domain Logic, unit test these functions)
IO again at the edges.

************************************)
open System.Text.Json

let loadFromDb query = sprintf "[%s]" query
let saveToDb data =
    printfn "DATA SAVED: %s" data

let myImportantWorkflow query =
    query
    |> loadFromDb
    |> JsonSerializer.Deserialize
    |> List.map (fun x -> x * 2)
    |> List.filter (fun x -> x <= 6)
    |> JsonSerializer.Serialize
    |> saveToDb

myImportantWorkflow "1,2,3,4"

(***********************************

TYPE INFERENCE

************************************)

let add2 (x:int) : int = x + 2

let add3 x = x + 2

// val doSomething: f: (int -> string) -> x: int -> string
// F must be a function that take int and returns string
let doSomething f x =
    let y = f (x + 1) // if 1 was 1.0 x is infered as a double
    "hello" + y                // y must a string so f must be a func 