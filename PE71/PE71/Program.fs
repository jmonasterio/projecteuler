// Learn more about F# at http://fsharp.net

// AND THE ANSWER IS:
// x = 428571/1000000
// x = 428570/999997 <-- This numerator.

open ProjectEuler;

let min = 1
let max = 1000000;

// Find  highest fraction < 3/7 and greater than the best so far.
let filterFracs n d (bestnum,bestden) =
    let frac : float = float(n)/float(d);
    if (frac < (3.0/7.0)) && (frac > (float(bestnum)/float(bestden))) then
        true;
    else
        false;

let mymin x y =
    if x > y then
        y
    else
        x;
        

let testrow num bestfrac =
    try
        let den:int = { (num+1)..(mymin (num*7/3+1) max)} |> Seq.filter( fun d -> filterFracs num d bestfrac; ) |> Seq.filter( fun d -> coprime d num ) |> Seq.maxBy( fun d -> (float(num)/float(d)) );
        printfn "x = %A/%A" num den;
        (num,den);
    with
        | ex -> bestfrac;

let maxFrac = {max .. -1 .. min} |> Seq.fold( fun bestfrac n -> testrow n bestfrac) (0,1); // acc=bestfrac    
// |> Seq.maxBy( fun frac -> (float(fst frac) / float(snd frac)

printfn "%A" maxFrac;



let y = 0;
