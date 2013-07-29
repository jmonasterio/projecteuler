// Project Euler #80.

let DECIMAL_DIGITS = 100;

// Return square root of x as a big rational, with digits of accuracy
let sr x digits =

    let mutable mean = x/2N;

    let limit = pown (10N/1N) digits;
    while abs(x-mean*mean) > (1N/limit) do
        let guess = mean
        let s = x/guess;
        mean <- (s+guess) / 2N

    mean;

// Returns a list of values resulting from division like: 1 . 4 1 4 2 1 3 5 
//  The first value is special because may not be a single digit
let longdiv lst (x:bigint) (y:bigint) (digits:int) =
    let rec ld lst x y digits = 
        let div = bigint.Divide (x, y);
        //printfn "%A %A" div rem;
        if digits>0 then
            ld (div::lst) ((x-div*y)*10I) y (digits-1);
        else
            lst;
    let rlst = ld lst x y digits;
    // make sure we only have 100 items.
    assert (rlst.Length = DECIMAL_DIGITS);

    // Revers ethe order, so list is in the right order.
    List.rev rlst;


let digitalsum (lst:bigint list) =
    List.sum lst;


let sums = 
    [
    for ii in [2N..99N] do
        let v = sr ii DECIMAL_DIGITS;
        let digits = longdiv [] v.Numerator v.Denominator DECIMAL_DIGITS;
        //printfn "%A" digits100;
        yield digitalsum ( digits );
    ];

// Ignore the perfect squares (sum=1)
let noperfectsquares = List.filter (fun x -> x > 9I) sums; // Like [3;0;0;0;0;0]


printfn "%A" (List.sum ( noperfectsquares));
    

printfn "DONE";