module Module4_Records

(* 
    Module 4 - Records, Option Types, Discriminated Unions & Pattern Matching 
*)

// Records
// - "Let you build super lightweight containers for small groups of values"
// - Have no constructors or such
type Person = {
    FirstName: string
    LastName: string
};

let person = { FirstName="Andrej"; LastName = "Spilak" }

printfn "%s %s" person.FirstName person.LastName

// since they are immutable, we do not cange value, but create a new one, wich can be based on previous
let person2 = {person with FirstName="spilak"}

// structural equality
let person3 = { FirstName="Andrej"; LastName = "Spilak" }
let areEqual = person = person3 // retuns true, since both records are the same