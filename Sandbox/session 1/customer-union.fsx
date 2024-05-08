type CustomerType = 
    | Registered of IsEligable:bool
    | Unregistered

type Customer = {
    Name: string;
    Type: CustomerType;
}

type Spend = decimal
type Total = decimal

type CalculateTotal = (Customer * Spend) -> Total

let calculateTotal (customer:Customer, spend:Spend) : Total =    
    let discount = 
        match customer.Type with 
        | Registered (IsEligable= true) when spend >= 100m -> spend * 0.1m
        | Registered _ -> 0m
        | Unregistered -> 0m
    spend - discount

let john = { Name = "John"; Type = Registered (IsEligable=true) }
let mary = { Name = "Mary"; Type = Registered (IsEligable=true) }
let richard = { Name = "Richard"; Type = Registered (IsEligable=false) }
let sarah = { Name = "Sarah";  Type = Unregistered }

let assertMary = calculateTotal(mary, 99m) = 99m
let assertJohn = calculateTotal(john, 100m) = 90m
let assertRichard = calculateTotal(richard, 100m) = 100m
let assertSarah = calculateTotal(sarah, 100m) = 100m

