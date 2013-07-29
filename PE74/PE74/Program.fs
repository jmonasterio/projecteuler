// Learn more about F# at http://fsharp.net

let x = 491;

let digits x = 
    let rec loop x lst = 
        if x = 0 then 
            lst 
        else 
            loop (x/10) (List.Cons (( x % 10), lst));
    loop x [];

let factorial x =
    let rec fac x =
        if x = 1 then
            x
        else
            x * fac (x-1);
    fac x;

let factorials = [| 1; 1; 2; 6; 24; 120; 720; 5040; 40320; 362880 |];

printfn "%A" (factorial(int(3)));

let sumFactorialDigits (x:int) = digits(x) |> List.map( fun x -> int(factorials.[x])) |> List.reduce(+);

printfn "%A" (sumFactorialDigits 145);

let makeNonRepeatingChain x =
    let rec makelist x lst =
        if List.exists( fun y -> x = y) lst then
            lst @ (-x :: []); // Add matching element to end as negative.
        else
            makelist (sumFactorialDigits(x)) ( lst @ (x :: []));
    makelist x []; 

printfn "%A" (makeNonRepeatingChain 69);      
printfn "%A" (makeNonRepeatingChain 78);      
printfn "%A" (makeNonRepeatingChain 145);      

let MAX = 1000000;
let count = [ 1 .. MAX ] |> List.map( fun x -> makeNonRepeatingChain x) |> List.filter( fun chain -> (chain.Length-1) = 60) |> List.length;
printfn "ANSWER: %A" count;

// NOTE: Could memoize makeNonRepeatingChain to avoid recalculating chains I already know.

let stop = 0;