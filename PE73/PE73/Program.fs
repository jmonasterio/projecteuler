open ProjectEuler;
// Learn more about F# at http://fsharp.net

// AND THE ANSWER IS:
// x = 428571/1000000
// x = 428570/999997 <-- This numerator.


let r:BigRational = (1N/3N); // Too slow


let min = 1
let max = 12000;

let range_min = 1.0/3.0;
let range_max = 1.0/2.0; 

// Find  highest fraction < 3/7 and greater than the best so far.
let filterFracs frac  =
    if (frac > range_min  && frac < range_max)  then
        true;
    else
        false;

let mymin x y =
    if x > y then
        y
    else
        x;
        



let total = {max .. -1 .. min} |> Seq.sumBy( fun n -> { (n+1)..(max)} |> Seq.filter( fun d -> filterFracs (float(n)/float(d)); ) |> Seq.filter( fun d -> coprime d n ) |> Seq.length ); // acc=bestfrac    

printfn "%A" total;



let y = 0;

