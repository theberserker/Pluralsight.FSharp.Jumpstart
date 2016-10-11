//namespace Pluralsight.FSharp.Jumpstart.Lib
#if INTERACTIVE
#else
module Module4_DiscriminatedUnionsAndPatternMatching
#endif

(* Discriminated unions and Pattern matching
    - Option types are actually a specific implementation of discriminated unions and pattern matching*)

// let's say we are representing a drawing, that consists of varieties of shapes
// this is a discriminated union (DU) that represents it (object hirearchy is not required)
type Shape = 
    | Square of float
    | Rectangle of float * float
    | Circle of float

let s = Square 3.4
let r = Rectangle(2.2, 1.9)
let c = Circle(1.0)
// all these are of same type, so we can put them into same array!
let drawing = [| s; r; c; |]

let Area (shape: Shape) = 
    match shape with
    | Square x -> x*x
    | Rectangle(h,w) -> h*w
    | Circle r -> System.Math.PI * r * r

let total = drawing |> Array.sumBy(fun s -> Area s)
let total2 = drawing |> Array.sumBy Area


(* 
    match 
        - if you don't cover all the cases, you get a compiler warning!
        - e.g. great when you add a value to Shape, e.g. Triangle we'll get a compiler warning!
*)

// let's match the array by the number of containing items!
let one = [|50|]
let two = [|60; 61|]
let many = [|0..99|]

let Describe arr = 
    match arr with 
    | [|x|] -> sprintf "One element: %i " x
    | [|x; y;|] -> sprintf "Two elements %i %i" x y
    | x -> sprintf "A longer array"; // will match any other

let desc1 = Describe one
let desc2 = Describe two
let desc3 = Describe many
