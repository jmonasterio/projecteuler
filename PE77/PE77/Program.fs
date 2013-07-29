
(*
It is possible to write ten as the sum of primes in exactly five different ways:

7 + 3
5 + 5
5 + 3 + 2
3 + 3 + 2 + 2
2 + 2 + 2 + 2 + 2

What is the first value which can be written as the sum of primes in over five thousand different ways?
*)

let MIN = 100;
let MAX = 100;

let mutable COUNT = 0L;


let primes max =
  let rec next potentialPrimes =
   match potentialPrimes with
   | [] -> []
   | n :: tail -> n :: next (List.filter (fun x -> x % n <> 0) tail)
  next [ 2 .. max]

// implement the coin change algorithm
let rec count n m (coins:int list) =
    if n = 0 then 1
    else if n < 0 then 0
    else if (m <= 0 && n >= 1) then 0
    else (count n (m-1) coins) + (count (n-coins.[m-1]) m coins)
 
//let answer = count 100 99 [1..99];
    
let plist = primes 10000;

for ii in [10..10000] do
    let c = count ii plist.Length plist;
    printfn "%A -> %A" ii c;
    if c > 5000 then
        printfn "STOP";
    