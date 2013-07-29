// Learn more about F# at http://fsharp.net

/// Doc comment

//namespace TEST99
//module 

#light
open System
open System.Diagnostics
open System.Collections.Generic 

open Microsoft.FSharp.Core

let isPermut l1 l2 =
  (List.sort l1) = (List.sort l2);;

isPermut (List.ofSeq "jorge") (List.ofSeq "egroj");

(* Answer is 510510 

This program found the answer, but took forever. I looked at data and found next number in sequence:

2: 2.000000
6: 3.000000
30: 3.750000
210: 4.375000
2310: 4.812500
30030: 5.213542


6 = 2 * 3
30 = 6 * 5
210 = 30 * 7
2310 = 210 * 11
30030 = 2310 * 13
510510 = 30030 * 17 (notice all primes at the end)

*)


let stopWatch = Stopwatch.StartNew()
(*
let hasDivisor(n) =
    let upperBound = bigint(sqrt(double(n)))
    [2I..upperBound] |> Seq.exists (fun x -> n % x = 0I)
 
let isPrime(n) = if n = 1I then false else not(hasDivisor(n))
 
// define the sequence of prime numbers
let primeSeq =
    Seq.unfold (fun state -> if state >= 3I then Some(state, state+2I) else Some(state, state+1I)) 1I
    |> Seq.filter isPrime
    |> Seq.cache
 
// define function to find the prime denominators for a number n
let getPrimeFactors n =
    let rec getPrimeFactorsRec denominators n =
        if n = 1I then denominators
        else
            let denominator = primeSeq |> Seq.filter (fun x -> n % x = 0I) |> Seq.head
            getPrimeFactorsRec (denominators @ [denominator]) (n/denominator)
    getPrimeFactorsRec [] n
 
let totient n =
    let primeFactors = getPrimeFactors n |> Seq.distinct
    n * (primeFactors |> Seq.map (fun n' -> n'-1I) |> Seq.reduce (*)) / (primeFactors |> Seq.reduce (*))
 
let answer = [2I..1000000I] |> List.maxBy (fun n -> double(n) / double(totient n))


stopWatch.Stop()
printfn "%f" stopWatch.Elapsed.TotalSeconds
*)

// FROM: http://en.wikibooks.org/wiki/F_Sharp_Programming/Recursion
let rec gcd x y =
    if y = 0 then x
    else gcd y (x % y)

let is_prime( x:int ) =
    let sr = sqrt( double x);
    let rec check( i) =
        double i > sr || (x % i <> 0 && check (i + 1))
    check 2

// http://blogs.msdn.com/b/dsyme/archive/2007/05/31/a-sample-of-the-memoization-pattern-in-f.aspx
let memoize f =
    let cache = Dictionary<_, _>()
    fun x ->
        if cache.ContainsKey(x) then cache.[x]
        else let res = f x
             cache.[x] <- res
             res

let coprime x y = 
    1 = gcd x y;

let not_divisible_by n =
    List.filter( fun m -> m % n <> 0)

// Faster  0.12sec (for 1000)
let relprimes max  =
        let limit = max - 1;
        let rec sieve_aux = function
            | [] -> []
            | x :: xs as lst -> if (x * 2 > max) || (max % x <> 0) then lst else sieve_aux (not_divisible_by x xs);
        sieve_aux [2 .. max] 

let yy = relprimes 22;            
printf "SEIVE(22): %A\n" yy;

let phi(x : int  ) =
    let limit = x - 1;
    if is_prime (x) then
        limit; // Return x-1
    else
        let y = (relprimes x)
        //printf "%d %A\n" x y;
        y.Length+1;

// From wikipedia.
// Found on wikipedia: http://upload.wikimedia.org/wikipedia/en/math/e/9/e/e9e15c0f6a86ec0fbfc1b5cd17c749a8.png
// phi(36) = phi( 2^2 * 3^2) = 36 ( 1-1/2)(1-1/3) = 36 * (1/2) * (2/3) = 12
//let gcdlist x = [];

//let phi2 x = x * fold( fun x -> 1 - x)

// Returns tuple (index, value)
let n_over_phi_n( n: int) =
    let p = phi n;
    ( n, (float n) / (float p))

// Find max n/phi across all range of date (returns first item w/ that max if more than one)
// returns tuple (index, max(n/phi))

let r3 = [ 2 .. 1000000 ] |> List.map n_over_phi_n |> List.maxBy (fun x -> (snd x) ); 

// List.fold accumulate (0,0.0);

printf "%i: %f\n" (fst r3) (snd r3);



stopWatch.Stop()
printfn "%f" stopWatch.Elapsed.TotalSeconds




System.Console.ReadKey(true);

//let isPermut l1 l2 =
//  (List.sort l1) = (List.sort l2);;

//http://hamletdarcy.blogspot.com/2008/08/f-sieve-of-eratosthenes.html
let primes max =
  let rec next potentialPrimes =
   match potentialPrimes with
  | [] -> []
  | n :: tail -> n :: next (List.filter (fun x -> x % n <> 0) tail)

  next [ 2 .. max]

printfn "%A" (primes 100)


  (* 
let cnt = phi(5)                
let cnt2 = n_over_phi_n( 7)               

System.Console.WriteLine( "RELATIVE COUNT: {0}", cnt2);
 
let big_number_factors( n) =
    let factors = seq {
        let limit = n / 2L
        for i in 2L .. limit do
            if n % i = 0L && is_prime i then yield i }
    Seq.max factors

// Both of these work
//let xx : int64 = 9L; // Say type of xx
let xx = int64( 9); // cast 9 to int64

System.Console.WriteLine( "{0}", is_prime( xx));


let addNumbers (a,b) = a+b;

let num1 : int = 5;
let num2 : int = 3;
let result = addNumbers(num1,4);

System.Console.WriteLine( "The result: {0}", result);

//let con = System.Console.WriteLine( string, obj);

//let printxx = con( "{0}", "DOG");

*)

(* phi(70) = phi(7) * phi(10)
phi(70) = 6 * phi(5) * phi(2)
phi(70) = 6 * 4 * 1
phi(70) = 24

/*
 * the even less naive totient function
 *
 * written by: tooboku
 * created: 26/03/2010
 * last modified: 26/03/2010
 * 
 * n is the number of possible relatively prime candidates
 * d is a counter decrementing from root n
 */
long ec_phi(long n, long d) {
     if(isPrime(n)) return --n;      // took this out of the error checker and placed it here

     if(!(n % d))                         
          if(isPrime(d)) {              // if d is prime than any quotient to get n is co-prime with it :D
               long q = n / d;          // get the quotient
               return (d - 1) * ec_phi(q, sqrt_l(q) + 1); // happy happy joy joy
          }
     return ec_phi(n, --d); // d|n was no satisfied, decrement d
}
*)