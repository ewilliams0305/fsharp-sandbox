type Customer = {
    Id : int
    IsVip : bool
    Credit : decimal
}

let getPurchase(customer:Customer) : (Customer * decimal) =
    let purchases = if customer.Id % 2 = 0 then 120M else 80M
    (customer, purchases)

let tryPromoteToVip(purchases: (Customer * decimal)) : Customer =
    let (customer, ammount) = purchases
    if ammount > 100M then {customer with IsVip = true }
    else customer

let increaseCreditIfVip(customer:Customer) : Customer =
    match customer with 
    | {IsVip = true} -> {customer with Credit = customer.Credit + 100M}
    | _ -> customer

// Pipe operator
let (|>) value func = func value

let upgradeCustomer (customer:Customer) : Customer = 
    customer
    |> getPurchase
    |> tryPromoteToVip
    |> increaseCreditIfVip

let upgradeCustomerFun (customer:Customer) : Customer = 
    customer
    |> getPurchase
    |> fun (cust, purch) -> tryPromoteToVip (cust, purch)
    |> increaseCreditIfVip

let customer = {
    Id = 12
    IsVip = false
    Credit = 2000M
}

let upgradedCustomer = upgradeCustomer customer 
let purchases1 customer = (|>) customer getPurchase
let purchases2 customer =  customer |> getPurchase


// Functions as arguments.
let add x y = x + y
let multiply x y = x * y
let calculate f x y = f x y
let answer = calculate multiply 12 12