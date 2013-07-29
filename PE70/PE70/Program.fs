// Learn more about F# at http://fsharp.net

/// Doc comment

module PE70

open System
open System.Diagnostics
open System.Collections.Generic 
open ProjectEuler
open Checked;
open System.Collections

open Microsoft.FSharp.Core

//module 
#light

let MAX = 10000000;

let primeNumbers = sieveOfAtkin MAX
let cache = new BitArray(       MAX+1)
primeNumbers |> List.iter (fun i -> cache.[i] <- true)

let isPrimeCache n = cache.[n]

// define function to find the prime denominators for a number n
let getPrimeFactors n =
    let rec getPrimeFactorsRec acc n =
        if n = 1 then acc
        elif isPrimeCache n then n :: acc
        else
            let pFact = primeNumbers |> List.find (fun n' -> n % n' = 0)
            getPrimeFactorsRec (pFact :: acc) (n / pFact)

    getPrimeFactorsRec [] n

let totient n =
    let primeFactors = getPrimeFactors n |> Seq.distinct
    (double n) * (double (primeFactors |> Seq.map (fun n' -> n'- 1) |> Seq.reduce (*))) / (double (primeFactors |> Seq.reduce (*)))
 

// Make a list of all combinations of pairs of elements in list.
let rec PairCombinations l1 =
    match l1 with
        | [] -> []
        | h :: t -> 
            match l1 with
                | [] -> []
                | head::tail -> (List.map( fun x -> (h,x)) (head::tail)) @ (PairCombinations ( tail))


// Return true, when PHI(X) is a permutation of (X).
let phi_equal_permut x =
    //printfn "%i" x;
    let phix = int( totient x);
    //printfn "%A" phix;
    if isPermutation x phix then
        printfn "IS PERMUT: %i %i" x phix
        true
    else
        false

let limit = MAX; //int( Math.Sqrt(float(MAX)))
printfn "LIMIT: %i" limit;

//let interestingPrimes = primeNumbers |> List.filter( fun x -> x>8000000 && x<MAX ) |> PairCombinations  |> List.map( fun x -> (fst x) * (snd x));

//printfn "COUNT OF PRIMES: {%i}" interestingPrimes.Length;

// Try all the numbers, were PHI(X) is a permutation of x., and find the min ratio of x/totient(x)
let r2 = [2 .. MAX] |> List.filter( fun x -> phi_equal_permut x) |> List.minBy( fun x -> float(x) / float(totient( int( x))) )
printfn "%A %A" r2 (int(totient r2));
printfn "DONE!";


