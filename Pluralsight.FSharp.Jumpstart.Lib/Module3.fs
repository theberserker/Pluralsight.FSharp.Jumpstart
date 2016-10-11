//namespace Pluralsight.FSharp.Jumpstart.Lib
#if INTERACTIVE
#else
module Module3
#endif

(* 
    Module 3 - Arrays, Collections and Higher Order Functions 
*)

// *** Arrays ***

let arr = [|1; 2; 4|]

// multiline array instantiation
let fruits = 
    [|
        "apple"
        "orange"
        "pear"
    |]

let numbers = [|0.0 .. 0.1 .. 9.0|] // defaines array of numbers from 0.0 to 9.0 by a 0.1 step

let squares = [| for i in 0..99 do yield i*i |] // code that generates an array for given numbers in a for loop

let IsEven n = 
    n % 2 = 0 

let evenSquares = Array.filter (fun x -> IsEven x) squares
let evenSquarez = Array.filter IsEven squares // looks like we can do that :)

// Function that populates an array using a multiline function
let RandomFruits count =
    let r = System.Random()
    [|
        for i in 1..count do
            let index = r.Next(3)
            yield fruits.[index]
    |]

let RandomFruits2 count =
    let r = System.Random()
    Array.init count (fun _ -> // _ is the index we are creating in the moment
        let index = r.Next(3)
        fruits.[index]
    )

let LikeFruits fruits =
    for fruit in fruits do
        printfn "I like %s" fruit


let PrintLongWords (words: string[]) = 
    let longWords : string[] = Array.filter (fun w -> w.Length > 8) words
    let sortedLongWords = Array.sort longWords
    Array.iter (fun w -> printfn "%s" w) sortedLongWords

// solved with Forward Pipe Operator in order to get rid of unnecessary variable storings
let PrintLongWords2 (words: string[]) = 
    words
    |> Array.filter (fun w -> w.Length > 8)
    |> Array.sort
    |> Array.iter (fun w -> printfn "%s" w)



let PrintSquares min max = 
    let square n = 
        n*n
    for i in min..max do 
        printfn "%i" (square i)

let PrintSquares2 min max = 
    let square n = 
        n*n
    [|min..max|]
    |> Array.map square
    |> Array.iter (printfn "%i")

// Let's use lists instead of arrays
let PrintSquaresList min max = 
    let square n = 
        n*n
    [min..max]
    |> List.map square
    |> List.iter (printfn "%i")

// F# Lists are immutable by default, Arrays aren't!!
let list = [0..9]
//list.[2] <- 1000; // this results in error: Property 'Item' cannot be set!

let arr2 = [|0..9|]
arr2.[2] <- 1000;

// Sequences = implementors of .NET's IEnumerable 
let smallNumbers = {0..99};;
let smallNumbers2 = Seq.init 100 (fun i -> i)

open System.IO
let bigFiles = 
    Directory.EnumerateFiles(@"C:\windows")
    |> Seq.map (fun name -> FileInfo name)
    |> Seq.filter(fun fi -> fi.Length > 1000000L)
    |> Seq.map(fun fi -> fi.Name)
