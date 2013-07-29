// Learn more about F# at http://fsharp.net


(*
It is possible to write five as a sum in exactly six different ways:

4 + 1
3 + 2
3 + 1 + 1
2 + 2 + 1
2 + 1 + 1 + 1
1 + 1 + 1 + 1 + 1

How many different ways can one hundred be written as a sum of at least two positive integers?
*)

(*

1 -> 1
2 -> 1 + 1 = 1 
3 -> 2 + 1, 1 + 1 + 1 = 2 
4 -> 3 + 1, 2 + 2, 2 + 1 + 1, 1 + 1 + 1 + 1 = 4
5 -> 4 + 1, 3 + 2, 3 + 1 + 1, 2 + 2 + 1, 2+1+1+1, 1+1+1+1+1 = 6  
6 -> 5 + 1, 4 + 2, 3 + 3, 2 + 2 + 2, 2 + 2 + 1 + 1, 1+1+1+1+1+1

n = (n-1)+1, (n-2)+2, (n-3)+3 ..
*)

(*
1 = 0
2 = 1+1 = 1
3 = 2+1 1+1+1 = 2
4 = 3+1 (2+2 2+1+1) 1+1+1+1 = 4
5 = 4+1 (3+2 3+1+1) (2+2+1 2+1+1+1+1) 1+1+1+1+1 = 6
6 = 5+1 (4+2 4+1+1) (3+3 3+2+1 3+1+1+1) (2+2+2 2+2+1+1 2+1+1+1+1) 1+1+1+1+1+1 = 10
7 = 6+1 (5+2 5+1+1) (4+3 4+2+1 4+1+1+1) (3+3+1 3+2+1+1 3+1+1+1+1) (2+2+2+1 2+2+1+1 2+1+1+1+1) (1+1+1+1+1+1+1) = 13
8 = 7+1 (6+2 6+1+1) (5+3 5+2+1 5+1+1+1) (4+4 4+3+1 4+2+2 4+2+1+1 4+1+1+1+1) (3+3+2 3+3+1+1 3+2+2+1 3+2+1+1+1 3+1+1+1+1+1) (2+2+2+2 2+2+2+1+1 2+2+1+1+1+1 2+1+1+1+1+1+1) (1+1+1+1+1+1+1+1+1) = 21
*)

let MIN = 100;
let MAX = 100;

let mutable COUNT = 0L;

// implement the coin change algorithm
let rec count n m (coins:int list) =
    if n = 0 then 1
    else if n < 0 then 0
    else if (m <= 0 && n >= 1) then 0
    else (count n (m-1) coins) + (count (n-coins.[m-1]) m coins)
 
//let answer = count 100 99 [1..99];
    
for i in [MIN..MAX] do
    let c = count i (i-1) [1..(i-1)];
    printfn "%A -> %A" i c;
    



    
