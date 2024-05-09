
// Tuple Args
// int * int -> int
let addFun = fun ( x, y) -> x + y


// Curried Args
// int -> (int -> int)
let add x y = x + y
let addCurried (x:int) (y:int) :int = x + y

let m = add 12 12 
let c = addCurried 10 10        // Curried splits the args into functions.

let functionReturned = addCurried 10  // Since the second arg is not provided a function is returned, see the signature above
functionReturned 20                   // Invoked with the second argument.
