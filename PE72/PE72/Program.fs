open ProjectEuler;
open Checked;
open System.Collections

// Learn more about F# at http://fsharp.net

// AND THE ANSWER IS:
// x = 428571/1000000
// x = 428570/999997 <-- This numerator.

let MAX = 100;

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
 
//let answer = [2..1000000] |> List.maxBy (fun n -> double(n) / (totient n))
let answer : bigint = [2..MAX] |> List.sumBy (fun n -> bigint(totient n))


let min = 1;
let max = 1000000;

let testrow num cnt:bigint =
    try
        let newcnt =
            if (num< 3) || not (is_prime num) then
                let row = { (num+1)..(max)} |> Seq.filter( fun d ->  ( coprime d num ));
                row |>  Seq.length;
            else
                max-num-1;

       // printfn "NUM:%A -> %A" num newcnt
        cnt + bigint(newcnt);
    with
        | ex -> cnt;

let count: bigint = {min .. 1 .. max} |> Seq.fold( fun cnt n -> testrow n cnt) (bigint(0)); // acc=bestfrac    
// |> Seq.maxBy( fun frac -> (float(fst frac) / float(snd frac)

printfn "%A" count;



let y = 0;




