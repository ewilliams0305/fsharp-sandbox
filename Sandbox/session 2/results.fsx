
/// <summary>
/// A customer represents a person whom uses our system and services.
/// </summary>
type Customer = {
    /// <summary>
    /// The customers ID is a one of a kind ID
    /// </summary>
    Id : int
    /// <summary>
    /// True when the customer is important,
    /// I know all customers are important, but not if this is false!
    /// </summary>
    IsVip : bool
    /// <summary>
    /// The ammount of credits they have stored on thier account.
    /// </summary>
    Credit : decimal
}

let getPurchase customer =
    try
        let purchases =
            if customer.Id % 2 = 0 then (customer, 120M)
            else (customer, 80M)

        Ok purchases
    with
    | ex -> Error ex

let tryPromoteToVip(purchases: (Customer * decimal)) : Customer =
    let (customer, ammount) = purchases
    if ammount > 100M then {customer with IsVip = true }
    else customer

let increaseCreditIfVip customer =
    try
        let increase =
            if customer.IsVip then 100.0M else 50.0M
        
        Ok {customer with Credit = customer.Credit + increase}
    with
    | ex -> Error ex


// Pipe operator
let (|>) value func = func value

let upgradeCustomer (customer:Customer) = 
    customer
    |> getPurchase
    |> fun value -> 
        match value with 
        | Ok x -> x |> tryPromoteToVip |> Ok
        | Error ex -> Error ex
    |> fun value ->
        match value with 
        | Ok x -> x |> increaseCreditIfVip 
        | Error ex -> Error ex

/// <summary>
/// Map takes a function that accepts an a and b
/// Map then maps the function to a value of a result
/// </summary>
/// <param name="f">the function of A and B</param>
/// <param name="value">the value and A and C</param>
/// <typeparam name="'a"></typeparam>
/// <typeparam name="'b"></typeparam>
/// <typeparam name="'c"></typeparam>
/// <returns>A result of B and C</returns>
let map f value =
    match value with 
    | Ok x -> x |> f |> Ok
    | Error ex -> Error ex

/// <summary></summary>
/// <param name="f"></param>
/// <param name="value"></param>
/// <typeparam name="'a"></typeparam>
/// <typeparam name="'b"></typeparam>
/// <typeparam name="'c"></typeparam>
/// <returns></returns>
let bind f value =
    match value with 
    | Ok x -> x |> f 
    | Error ex -> Error ex

let log (error: exn) =
    printfn $"ERROR: {error.Message}"
    error

let logError value =
     match value with 
        | Ok value -> Ok value
        | Error ex -> Error log 

let upgradeCustomerMapAndBind (customer:Customer) = 
    customer
    |> getPurchase
    |> fun value -> map tryPromoteToVip value
    |> fun value -> bind increaseCreditIfVip value

let upgradeCustomerBuildInResult (customer:Customer) = 
    customer
    |> getPurchase
    |> Result.map tryPromoteToVip 
    |> Result.bind increaseCreditIfVip
    |> fun value ->
        match value with 
        | Ok value -> Ok value
        | Error ex -> Error log 

let customer = {
    Id = 12
    IsVip = false
    Credit = 2000M
}

let upgradedCustomer = upgradeCustomer customer