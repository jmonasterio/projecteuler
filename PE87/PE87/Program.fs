module main
// Calculate the total number of triplets and subtract off the few near the end that exceed the max.

// Notation: X4 <- The four indicates that the value will be raised to the 4th power.

open System;

#if TEST
let t1 = Math.Pow( 50000000.0, (1.0/3.0))

let test = bigint(2)
let test2 = bigint(3)
let test3 = bigint(2)
#endif
let primePow (x4, y3, z2) = bigint.Pow( x4,4) + bigint.Pow(y3,3) + bigint.Pow(z2,2)

#if TEST
let x = primePow( test, test2, test3)
#endif

let primes max =
  let rec next potentialPrimes =
   match potentialPrimes with
   | [] -> []
   | n :: tail -> n :: next (List.filter (fun x -> x % n <> 0) tail)
  next [ 2 .. max]

#if TEST
let ps = primes 150
#endif

let last lst =
    List.head( List.rev lst)


// 50 -> 4
// 100 -> 9???
// 50000000 -> ????


let MAX = bigint(50000000)

let PRIMES2 = primes( int(Math.Floor(Math.Pow( float(MAX), (1.0/2.0)))))
let MAX2 = last( PRIMES2 )

let PRIMES3 = primes( int(Math.Floor(Math.Pow( float(MAX), (1.0/3.0)))))
let MAX3 = last( PRIMES3)

let PRIMES4 = primes( int(Math.Floor(Math.Pow( float(MAX), (1.0/4.0)))))
let MAX4 = last( PRIMES4)

let tripletPermutations = (List.length(PRIMES2))*(List.length(PRIMES3))*(List.length(PRIMES4))

let primePowCount2( p3, p2) =
    let chk = primePow( bigint(MAX4), p3, p2)
    if( chk < MAX ) then
        0
    else
        let lambda (x:int) = (if primePow(bigint(x),p3,p2) >= MAX then 1 else 0)
        List.fold ( fun acc (a4:int) -> (acc) + (lambda a4)) 0 PRIMES4

let primePowCount( p2) = 
    let chk = primePow( bigint(MAX4), bigint(MAX3), p2)
    if(  chk < MAX ) then
        0
    else
        List.fold ( fun acc (a3:int) -> (acc) + primePowCount2(bigint(a3), p2)) 0 PRIMES3


let countOfTripletsThatExceedMax = 
     List.fold ( fun acc (a2:int) -> (acc) + primePowCount(bigint(a2))) 0 PRIMES2

let ANSWER = tripletPermutations - countOfTripletsThatExceedMax
printf "%A" ANSWER
printf "Done\n";


(*
let distrib e L =
    let rec aux pre post = 
        seq {
            match post with
            | [] -> yield (L @ [e])
            | h::t -> yield (List.rev pre @ [e] @ post)
                      yield! aux (h::pre) t 
        }
    aux [] L

let rec perms = function 
    | [] -> Seq.singleton []
    | h::t -> Seq.collect (distrib h) (perms t)

let ds = distrib 10 [1;2;3] //--> [[10;1;2;3];[1;10;2;3];[1;2;10;3];[1;2;3;10]]


let p1 = perms [1;1;3] // = [[1;1;3]; [1;1;3]; [1;3;1]; [1;3;1]; [3;1;1]; [3;1;1]]


let rec factorial(n:int): bigint =  
     match n with  
     | 1 -> bigint(1)  
     | n -> bigint(n) * factorial(n - 1)  

let choose(n,k) = (factorial( n)) / (factorial(k) * factorial(n-k))
let xx = choose(908,3)


let rec combs( n, lst) = 
    match n, lst with
    | 0, _ -> seq [[]]
    | _, [] -> seq []
    | k, (x :: xs) -> Seq.append (Seq.map ((@) [x]) (combs( (k - 1), xs))) (combs( k, xs))


// Generates the cartesian outer product of a list of sequences LL
let rec outerProduct = function
    | [] -> Seq.singleton []
    | L::Ls -> L |> Seq.collect (fun x -> 
                outerProduct Ls |> Seq.map (fun L -> x::L))

// Generates all n-element combination from a list L
let getPermsWithRep2 n L = 
    List.replicate n L |> outerProduct  

let op = List.replicate 2 [1;2;3] |> outerProduct 
printf "%A" (Seq.toList op);

let MAX = 50000000I
let primeList = primes (int(Math.Sqrt(float(MAX))))
let primeCnt = List.length primeList
let total = choose ( primeCnt, 3)


let c1 = getPermsWithRep2 3 primeList 
let c1Cnt = Seq.length c1 // total = {124356956}

let filtered lst:seq<list<int>> = Seq.filter (fun sq -> primePow(bigint(sq.[0]), bigint(sq.[1]), bigint(sq.[2])) < MAX )  lst

let answer = filtered c1

let answerCnt = Seq.length answer
printf "%A" answerCnt // 1139575



    (*

        let current = inc current
    while true


    let temp = [| for i in 0..k-1 -> last.[i] |] // copy input to temp array
    let mutable x = k-1 // find "x" - right-most index to change
    while x > 0 && temp.[x] = n - k + x do 
      x <- x - 1
    temp.[x] <- temp.[x] + 1 // increment value at x
    for j = x to k-2 do // increment all values to the right of x
      temp.[j+1] <- temp.[j] + 1
    temp
    *)


let t2 = choose(5,2)

open System.IO;

//printf "Answer is: %A\n" findM
printf "Done\n";
*)