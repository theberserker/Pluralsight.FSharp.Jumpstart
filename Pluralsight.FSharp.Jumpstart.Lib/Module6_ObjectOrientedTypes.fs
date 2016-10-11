#if INTERACTIVE
#else
module Module6_ObjectOrientedTypes
#endif

type Person (firstname: string, lastname: string) = // constructor
    member this.FirstName = firstname
    member __.LastName = lastname       // anything goes here for the selfreference (this, __, etc)

let p1 = Person("Anders", "Spilak")
let p2 = Person(firstname="John", lastname="Doe")

// Immutable - you can't be Ivan
//p2.FirstName <- "Ivan" 

type MutablePerson(firstname: string, lastname: string) =
    let mutable _firstname = firstname
    let mutable _lastname = lastname
    
    // with getters and setters
    member this.FirstName
        with get () = _firstname
        and set value = _firstname <- value

    member this.LastName
        with get () = _lastname
        and set v = _lastname <- v

let p3 = MutablePerson(firstname="John", lastname="Doe")
// Now you can be Ivan
p3.FirstName <- "Ivan" 

// Autoproperties with using 'val'
type MutablePerson2(firstname: string, lastname: string) =
    member val FirstName = firstname with get, set
    member val LastName = lastname with get, set

let p4 = MutablePerson2(firstname="John", lastname="Doe")
p4.FirstName <- "Ivan" 

// some constructor validation logic (note, this is stil mutable object cuz has get; set;)
open System
type SafePerson(firstname: string, lastname: string) =
    let validateString str = 
        if String.IsNullOrWhiteSpace str then
            raise (ArgumentException "Argument should have value")
    do 
        validateString firstname
        validateString lastname
    member val FirstName = firstname with get, set
    member val LastName = lastname with get, set    

let p5 = SafePerson("A", "Spilak")
p5.FirstName <- "Ivan" 
let p6 = SafePerson("", "Spilak") // raises the exception

// introducing backing fields and validating them at setters - it is geting a bit cumbersome code once you want to validate them
open System
type SafePerson2(firstname: string, lastname: string) =
    let mutable _firstname = firstname
    let mutable _lastname = lastname

    let validateString str = 
        if String.IsNullOrWhiteSpace str then
            raise (ArgumentException "Argument should have value")
    do 
        validateString firstname
        validateString lastname
    
    member this.FirstName 
        with get() = _firstname
        and set value = 
            validateString value
            _firstname <- value

    member this.LastName 
        with get() = _lastname
        and set value = 
            validateString value
            _lastname <- value

let p7 = SafePerson2("Ivan", "Janxa")
p7.FirstName <- "" // you can't clear value now, since we validate it in setter (so have to stay Ivan, bwahahaha!)


// interfaces!
type IPerson = 
    abstract member FirstName : string 
    abstract member LastName : string 
    abstract member FullName : string

// type that implements an interface
type PersonFromInterface(firstname: string, lastname: string) =
    let validateString str = 
        if String.IsNullOrWhiteSpace str then
            raise (ArgumentException "Argument should have value")
    do 
        validateString firstname
        validateString lastname

    interface IPerson with
        member __.FirstName = firstname
        member __.LastName = lastname
        member __.FullName = sprintf "%s %s" firstname lastname

let p8 = PersonFromInterface("A", "S")
// accessign the property like this will throw an exception !!
// p8.LastName 
// in order to access the value behind interface we have to UPCAST (:>) to IPerson
// the desing justification of this is to make it clear wether we are calling method of a type or an interface that type implements
// if we'd call that from C# we'd have to do the cast as well!!!!
//(p8:>IPerson).FullName

// TODO: Inheritance!

(* 
    Discriminated union we'll try to test from C#....
    1. Contact DU that will serve us as as a preferredContact member in ContactPerson
    2. In ContactPerson we have PreferredContact member (not as a part of interface, for sake of simplicity)
    3. We cover that code in unit tests in C#.
*)
type Contact =
    | PhoneNumber of AreaCode: string * Number: string
    | EmailAddress of string


type ContactPerson(firstname: string, lastname: string, preferredContact: Contact) =
    let validateString str = 
        if String.IsNullOrWhiteSpace str then
            raise (ArgumentException "Argument should have value")
    do 
        validateString firstname
        validateString lastname

    member __.PreferredContact = preferredContact

    interface IPerson with
        member __.FirstName = firstname
        member __.LastName = lastname
        member __.FullName = sprintf "%s %s" firstname lastname