module ProjectEuler

open System.Collections.Generic 

// FROM: http://stackoverflow.com/questions/286427/calculating-permutations-in-f
let rec insertions x = function
    | []             -> [[x]]
    | (y :: ys) as l -> (x::l)::(List.map (fun x -> y::x) (insertions x ys))

let rec permutations = function
    | []      -> seq [ [] ]
    | x :: xs -> Seq.concat (Seq.map (insertions x) (permutations xs))

let generatePermutations (lst: 'a list) =
    let p = List.toArray lst
    let n = Array.length p
    let swap i j =
        let t = p.[i]
        p.[i] <- p.[j]
        p.[j] <- t
    let rec next() = seq {
        let l = ref (n-2)
        while (!l>=0 && p.[!l] > p.[!l+1]) do
            l := !l-1
        if !l>=0 then
            let r = ref (n-1)
            while (p.[!r] < p.[!l]) do
                r := !r-1
            swap !l !r
            r := n-1
            l := !l+1
            while !l < !r do
                swap !l !r
                l := !l+1
                r := !r-1
            yield (List.ofArray p)
            yield! next()
        }
    next()

    // FROM: http://en.wikibooks.org/wiki/F_Sharp_Programming/Recursion
let rec gcd x y =
    if y = 0 then x
    else gcd y (x % y)

let coprime x y = 
    1 = gcd x y;

let is_prime( x:int ) =
    let sr = sqrt( double x);
    let rec check( i) =
        double i > sr || (x % i <> 0 && check (i + 1))
    check 2

// http://blogs.msdn.com/b/dsyme/archive/2007/05/31/a-sample-of-the-memoization-pattern-in-f.aspx
let memoize f =
    let cache = Dictionary<_, _>()
    fun x ->
        if cache.ContainsKey(x) then cache.[x]
        else let res = f x
             cache.[x] <- res
             res

let not_divisible_by n =
    List.filter( fun m -> m%n = 0)

// Faster  0.12sec (for 1000)
let relprimes max  = 
        [1..max] |> List.filter( fun x -> (gcd max x) = 1);

let phi(x : int  ) =
    let limit = x - 1;
    if is_prime (x) then
        2; // Return x-1
    else
        let y = (relprimes x)
        //printf "%d %A\n" x y;
        y.Length+1;

// Returns tuple (index, value)
let n_over_phi_n( n: int) =
    let p = phi n;
    ( n, (float n) / (float p))


    //http://hamletdarcy.blogspot.com/2008/08/f-sieve-of-eratosthenes.html
let primes max =
  let rec next potentialPrimes =
   match potentialPrimes with
   | [] -> []
   | n :: tail -> n :: next (List.filter (fun x -> x % n <> 0) tail)
  next [ 2 .. max]

// define function to check if two numbers are permutations of each other
let isPermutation n1 n2 =
  let l1 = Seq.toList (n1.ToString());
  let l2 = Seq.toList (n2.ToString());
  (List.sort l1) = (List.sort l2);


// Generates a list of all primes below limit
let sieveOfAtkin limit =
    // initialize the sieve
    let sieve = Array.create (limit + 1) false
    // put in candidate primes: 
    // integers which have an odd number of
    // representations by certain quadratic forms
    let inline invCand n pred =
        if n < limit && pred then sieve.[n] <- not sieve.[n] 
    let sqrtLimit = int (sqrt (float limit))
    for x = 1 to sqrtLimit do
        for y = 1 to sqrtLimit do
            let xPow2 = x * x
            let yPow2 = y * y
            let n = 4 * xPow2 + yPow2 in invCand n (let m = n % 12 in m = 1 || m = 5)
            let n = 3 * xPow2 + yPow2 in invCand n (n % 12 = 7)
            let n = 3 * xPow2 - yPow2 in invCand n (x > y && n % 12 = 11)
    // eliminate composites by sieving
    let rec eliminate n =
        if n <= sqrtLimit 
        then if sieve.[n]
             then let nPow2 = n * n
                  for k in nPow2 .. nPow2 .. limit do
                      Array.set sieve k false
             eliminate (n + 2)
    eliminate 5
    // Generate list from the sieve (backwards)
    let rec generateList acc n =
        if n >= 5 then generateList (if sieve.[n] then n :: acc else acc) (n - 1)
        else acc
    2 :: 3 :: (generateList [] limit)




