//namespace Pluralsight.FSharp.Jumpstart.Lib
#if INTERACTIVE
#else
module Module2
#endif

(*
    Module 2 - Values, Functions and Flow of Control
*)

// tuples
let position = 1.2, 2.4;;

let RandomPosition() =
    let r = new System.Random()
    r.NextDouble(), r.NextDouble()

// decompose the tuple into 2 variables - latitude and longitude
let latitude, longitude = RandomPosition()

let treasureLocation = RandomPosition()
let latitude2, longitude2 = treasureLocation;

// note that this is a variable, sice it's not finishing with ()
let RandomPositionVar =
    let r = new System.Random()
    r.NextDouble(), r.NextDouble()

// tupling the arguments is not reallz idiomatic practice to F#, but sure it is used for libs and .NET funcs
open System.IO
let files = Directory.EnumerateFiles(@"C:\tmp\", "*.txt")


// partial application:
let Area length height =
    length * height
// this is a partial application to the Aread function; 
// completely legit and won't throw error as someone might expect
let partial = Area 4
let final = partial 5
