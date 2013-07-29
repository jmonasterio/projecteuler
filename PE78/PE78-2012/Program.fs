open System.Text
open System.Collections.Generic

(*
It is possible to write ten as the sum of primes in exactly five different ways:

7 + 3
5 + 5
5 + 3 + 2
3 + 3 + 2 + 2
2 + 2 + 2 + 2 + 2

What is the first value which can be written as the sum of primes in over five thousand different ways?
*)

(*
// the pentagonal numbers sequence, i.e. 1, 2, 5, 7, 12, 15, 22, ...
let pentagonalNumbers =
    Seq.unfold (fun state -> Some(state, state+1)) 1
    |> Seq.collect (fun n -> [n; -1*n])
   |> Seq.map (fun n -> int(0.5 * double(n) * double(3 * n - 1)))
 
// the coefficients sequence, i.e. +, +, -, -, +, +, -, -, ...
let pCoefficients =
    Seq.unfold (fun state -> Some(state, -1*state)) 1 |> Seq.collect (fun n -> [n; n])
 
// cache results to improve performance
let mutable cache = Array.init 100000 (fun n -> if n = 0 then 1I else 0I)
 
// define the function p using the pentagonal numbers
let rec p k =
    if cache.[k] <> 0I then cache.[k]
    else
        let pSeq =
            pentagonalNumbers
            |> Seq.map (fun n -> k - n)
            |> Seq.takeWhile (fun n -> n >= 0)
            |> Seq.map p
        let pk =
            pCoefficients
            |> Seq.zip pSeq
            |> Seq.sumBy (fun (pk, coe) -> pk * bigint(coe))
 
        cache.[k] <- pk
        pk
 
let answer =
    Seq.unfold (fun state -> Some(state, state+1)) 1
    |> Seq.filter (fun k -> (p k) % 1000000I = 0I)
    |> Seq.head

printfn "%A" answer;
printfn "done";
*)

// 55374
    
let MAX = 56000;

let generalizedPentagonalNumbers =
    seq {
        for n in [1 .. (MAX/2)] do
            if (n % 2 = 1) then
                yield ((3*n*n - n)/2);
                yield ((3*n*n + n)/2); 
            else
                yield (-(3*n*n - n)/2);
                yield (-(3*n*n + n)/2); 
    };


let plist = seq {1..(MAX/2)};


let parray : bigint array = Array.zeroCreate 60000

let rec p k (pents:int seq)  =
    
    if k <= 0 then
        bigint(0);
    elif k <= 1 then
        bigint(1);
    elif parray.[k] <> bigint(0) then
        parray.[k];
    else

        let kays = Seq.takeWhile (fun x -> k-abs(x) > 0) pents;
    
        let pp:bigint = Seq.fold( fun acc x -> acc + bigint(sign(x)) * (  p (k - abs(x)) kays)) (bigint(0)) kays;
        parray.[k] <- pp;
        pp;

let allpents = generalizedPentagonalNumbers;

for ii in [1 .. MAX] do
    let x = p ii allpents;
    if (x % (bigint ( 1000000))) = bigint(0) then
        printfn "%A %A" ii-1 x // Actually need to subtract one from this anser.
    else
        printfn "%A %A" ii-1 x;

//let answer = p 999 plist;
//printfn "%A" answer;
    

printfn "DONE";    

