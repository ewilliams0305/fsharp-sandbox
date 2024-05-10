open System

// Reference Type
let nullObj : string = null

// Nullable Tye
let nullPri = Nullable<int>()


// From .NET to F#
// Null exists DONT Use it

let fromNullObj = Option.ofObj nullObj
let fromNullPri = Option.ofNullable nullPri

let toNullObj= Option.toObj fromNullObj
let toNullPri = Option.toNullable fromNullPri