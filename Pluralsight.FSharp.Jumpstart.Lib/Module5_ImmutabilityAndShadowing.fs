#if INTERACTIVE
#else
module Module5_Immutability
#endif

// 5. Immutability and Shadowing

(* Immutability
    - simpler code
    - assures that functions have no side effects (referential transparency)
    - safer multithreding

*)

let ImmutabilityDemo() = 
    let x = 42
    //x <- 43  // we can't mutate x!
    let x = 43 // we can do this due to shadowing!
    x

let ShadowingDemo() =
    let x = 42
    printfn "x: %i" x // 42
    if 1=1 then
        let x = x + 1
        printfn "x: %i" x //43
    printfn "x: %i" x //42


let ShadowingDemo2() =
    let x = 42
    printfn "x: %i" x // 42
    if 1=1 then
        let x' = x + 1
        printfn "x: %i x': %i" x x' // it is a rather good practice not to shadow a value, but to show that it's related to x with a ' ("x prime")
    printfn "x: %i" x //42

// mutable feature is available from F# 3.1
// if you are doing smth like it it's better to keep such value in local scope
let MutabilityDemo() = 
    let mutable x = 42
    printfn "x: %i" x
    x <- x + 1
    printfn "x: %i" x

// prior F# 3.1 - mutability by using reference cells
// http://stackoverflow.com/questions/3221200/f-let-mutable-vs-ref
let MutabilityDemoPre31() = 
    let x = ref 42
    x := 43
    printfn "x: %i" !x // ! here notes the explicit dereferencing

// where you will have to use reference cells as opposed to mutable keyword is in  sequence generator like such..
// This was suposed to fail in compile time with: the mutable variable is used in an invalid way. mutable variables cannot be captured by closures", BUT WORKS FOR ME! (new F# feature?)
let PrintLines() = 
    seq {
        let mutable finished = false
        while not finished  do 
            match System.Console.ReadLine() with
            | null -> finished <- true
            | s -> yield s 
    }

let PrintLinesRef() = 
    seq {
        let finished = ref false
        while not !finished  do 
            match System.Console.ReadLine() with
            | null -> finished := true
            | s -> yield s 
    }

