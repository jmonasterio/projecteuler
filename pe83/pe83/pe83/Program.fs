// NOTES: This is neither efficient nor pretty F# code.
//  Takes about 5 minutes to run, which is not good.
// Only interesting thing is that I'm summing up the results as I go along: 
// I just add shortest routes from the new cuboids for each new M

open System;

let EPSILON = 0.0001

let isInteger( x:float) = 
    x = Math.Floor(x + EPSILON)

//let t1 = isSquare 81.0
//let t2 = isSquare 101.0

// Flatten out the cuboid and then draw staight line between corners.
//let shortest1( a,b,c) =
//    Math.Sqrt( float(((a+c)*(a+c))+(b*b)))
let shortest2( a,b,c) =
    Math.Sqrt( float(((b+c)*(b+c))+(a*a)))
let shortest3( a,b,c) =
    Math.Sqrt( float(((b+a)*(b+a))+(c*c)))

let isShortestAnInteger(a,b,c) =
    let shortest = Seq.min( [shortest2( a,b,c); shortest3( a,b,c )])
    isInteger( shortest )

let tup = (5,6,3)
//let t3 = shortest1(tup)
let t31 = shortest2(tup)
let t32 = shortest3(tup)
let t4 = isShortestAnInteger(tup)

let generateCuboidsDims( m:int) =
      seq {
        for h in 1..m do 
            for w in h..m do 
                for l in w..m do 
                    if h<=w && w<=l then yield (h,w,l) }

let generateCuboidsDims2( m:int, oldm:int) =
      seq {
        for len in oldm..m do 
            for w in 1..len do 
                for h in 1..w do
                    if (h>oldm || w>oldm || len >oldm) then yield (h,w,len) }

let generateCuboidsDims3( m:int, oldm:int) =
      seq {
        for len in oldm..m do 
            for w in 1..len do 
                if len<=oldm && w<=oldm then
                    for h in oldm..w do
                        yield (h,w,len)
                else
                    for h in 1..w do
                        yield (h,w,len) }

let mutable newCnt = 0


let FIND=1000000

for m in Seq.initInfinite( fun index -> 
    let n = index + 1
    n)
    do
        let generated = generateCuboidsDims2( m, m-1)
        let found = (Seq.length (Seq.filter isShortestAnInteger generated))
        let oldCnt = newCnt
        newCnt <- newCnt + found
        let ignore = 
            if( newCnt > FIND) then
                let stop = 1
                System.Diagnostics.Debugger.Break()
                stop
            else
                let stop = 0
                stop
        Console.WriteLine( "{0}: {1} : {2}", m, newCnt, newCnt-oldCnt)

let M = 3
//let data = generateCuboidsDims(M)
//let dataCnt = Seq.length data


let filteredCnt m = (Seq.length (Seq.filter isShortestAnInteger (generateCuboidsDims m) ) )

let cnt = filteredCnt M
Console.WriteLine( "cnt: {0}", cnt)




//let myMatch x a b = x<FIND && a<b

//let binarySearch (startx, endx, f, condition) =
//    let rec iter a b =
//        if a = b then None
//        else
//            let median:int = a + (b - a)/2
//            let cnt = (f median)
//            let below = (condition cnt a b)
//            Console.WriteLine( "{0}:{1}:{2}", median, cnt, below)
//            match cnt with
//            | value when a=b  -> Some median
//            | value when below -> iter (median + 1) b
//            | _                       -> iter a median
//    (iter startx endx)

//let findM = binarySearch( 500, 1000, filteredCnt, myMatch )

open System.IO;

//printf "Answer is: %A\n" findM
printf "Done\n";