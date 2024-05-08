type Customer = {
    Name:string;
    IsRegistered:bool;
    IsEligable:bool;
}
type Spend = decimal
type Total = decimal

type CalculateTotal = (Customer * Spend) -> Total

let john = { Name = "John"; IsRegistered = true; IsEligable = true }
let mary = { Name = "Mary"; IsRegistered = true; IsEligable = false }
let richard = { Name = "Richard"; IsRegistered = true; IsEligable = true }
let sarah = { Name = "Sarah"; IsRegistered = true; IsEligable = true }

let calculateTotal (customer:Customer, spend:Spend) : Total =
    
    let discount = 
        if customer.IsRegistered && customer.IsEligable && spend >= 100m then spend * 0.1m else 0m
    spend - discount

let assertMary = calculateTotal(mary, 99m) = 99m
let assertJohn = calculateTotal(john, 100m) = 90m
let assertRichard = calculateTotal(richard, 100m) = 100m
let assertSarah = calculateTotal(sarah, 100m) = 100m

