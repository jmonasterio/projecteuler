// Learn more about F# at http://fsharp.net

#light

let MAX = 1500000L;

let rec gcd x y =
    if y = 0L then x
    else gcd y (x % y)

let coprime x y = 
    1L = gcd x y;


let maketriplesEuclid (max:int64) = 
    let SQRTMAX = int64(sqrt(float(max)))
    let sqrcnts : int array = Array.zeroCreate (int(max+1L));
    for n:int64 in [1L..2L..SQRTMAX] do
        for m:int64 in [2L..2L..(SQRTMAX-n)] do
            if (coprime m n) then
                let mm = m*m; // Euclid's formula for pythagorean triplets.
                let nn = n*n;
                let a = abs(mm-nn);
                let b = 2L*m*n;
                let c = mm+nn;
                let length = a+b+c;
                let mutable idx = int(length);

                // mark array, as well as all multiples of array.
                while( idx <= int(max)) do
                    sqrcnts.[idx] <- sqrcnts.[idx] + 1;
                    //let factor = int64(idx)/length;
                    //printfn "%A %A" [b*factor;a*factor;c*factor] idx;
                    idx <- idx + int(length);
    sqrcnts;
                    
// Fill array with counts
;

let cntOfOnes = maketriplesEuclid MAX |> Array.filter( fun x -> x = 1) |> Array.length;



printfn "Answer: %A" cntOfOnes;



let stop =1;