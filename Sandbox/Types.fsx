open System

(***********************************

RECORD TYPE AKA "AND" TYPES

************************************)

// DEFINITION
type Thing = { Id: int; Description:string }

// CONSTRUCT
let aThing = { Id=12; Description="This is a thing" }

// COPY and Update, imutable. 
let antoherThing = { aThing with Id=13 }


// DEFINITION Puts the thing on a stack
[<Struct>]
type ThingStruct = { Id: int; Description:string }

// CONSTRUCT
let aThingStruct = { Id=12; Description="This is a thing" }

// COPY and Update, imutable. 
let antoherThingStruct = { aThing with Id=13 }

// Ananymous record add |||
let contact = {| Id=int; Email="ewilliams@thing.com" |}


(***********************************

CHOICE TYPES or DISCRIMATED UNIONS

************************************)

type PrimaryColor = Red | Green | Blue
let aColor = Red

// Unions can have data, NOT an Enum

type RgbColor = {R:int; G:int; B:int}

type Color =
    | Primary of PrimaryColor
    | RGB of RgbColor
    | Named of string

// Model domain types and models

type EmailAddress = string
type CardType = Visa | MasterCard
type CardNumber = string

type CreditCardinfo = {
    CardType: CardType
    CardNumber: CardNumber
}

type PaymentMethod =
    | Cash 
    | Paypal of EmailAddress
    | Card of CreditCardinfo



(***********************************

PLAYGROUND

************************************)
type Customer = { Id:int; Name:string; Email:string }

let validateName name:string = 
    

let createCustomer