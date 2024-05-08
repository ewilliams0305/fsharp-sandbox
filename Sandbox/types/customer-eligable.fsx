type Customer = 
    | Eligable of Id:string
    | Registered of Id:string
    | Unregistered of Name:string 

type Spend = decimal
type Total = decimal

type CalculateTotal = (Customer * Spend) -> Total

let calculateTotal (customer:Customer, spend:Spend) : Total =    
    let discount = 
        match customer with 
        | Eligable _ when spend >= 100m -> spend * 0.1m
        | Eligable _ -> 0m
        | Registered _  -> 0m
        | Unregistered _ -> 0m
    spend - discount

let john = Registered (Id = "John", IsEligable = true) 
let mary = Registered (Id = "Mary", IsEligable = true)
let richard = Registered (Id = "Richard", IsEligable = false)
let sarah = Unregistered (Name = "Sarah") 

let assertMary = calculateTotal(mary, 99m) = 99m
let assertJohn = calculateTotal(john, 100m) = 90m
let assertRichard = calculateTotal(richard, 100m) = 100m
let assertSarah = calculateTotal(sarah, 100m) = 100m

