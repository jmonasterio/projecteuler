open System.IO;
open System;

(* FROM WIKIPEDIA

1. Assign to every node a tentative distance value: set it to zero for our initial node and to infinity for all other nodes.
2. Mark all nodes unvisited. Set the initial node as current. Create a set of the unvisited nodes called the unvisited set consisting of all the nodes except the initial node.
3. For the current node, consider all of its unvisited neighbors and calculate their tentative distances. For example, if the current node A is marked with a distance of 6, and the edge connecting it with a neighbor B has length 2, then the distance to B (through A) will be 6+2=8. If this distance is less than the previously recorded distance, then overwrite that distance. Even though a neighbor has been examined, it is not marked as visited at this time, and it remains in the unvisited set.
4. When we are done considering all of the neighbors of the current node, mark the current node as visited and remove it from the unvisited set. A visited node will never be checked again; its distance recorded now is final and minimal.
5. If the destination node has been marked visited (when planning a route between two specific nodes) or if the smallest tentative distance among the nodes in the unvisited set is infinity (when planning a complete traversal), then stop. The algorithm has finished.
6. Set the unvisited node marked with the smallest tentative distance as the next "current node" and go back to step 3.

*)

//let matrix = [| [| 131; 673; 234; 103; 18 |]; 
//                       [| 201; 96; 342; 965; 150 |];
//                       [| 630; 803; 746; 422; 111 |];
//                       [| 537; 699; 497; 121; 956 |];
//                       [| 805; 732; 524; 37; 331 |]; |];
//let MAX_COL = 5;
//let MAX_ROW = 5;

//let obtainNums (line:string) =
//    line.Split(",".ToCharArray()) |> Array.map( Int32.Parse);


// Using Dijkstra's algorithm from wikipedia.
let matrix = 
    File.ReadAllLines(@"Matrix.txt") |> Array.map( fun line -> line.Split(",".ToCharArray()) |> Array.map( Int32.Parse));  
    
    

type Coord = {
    row: int;
    col: int;
    }

type Node = {
    rc : Coord;
    distance : int;
    mutable unvisited : bool;
    mutable tentative_distance : int;
    }

let MAX_ROW = matrix.GetUpperBound(0)+1;
let MAX_COL = MAX_ROW;
let MAX_DISTANCE = Int32.MaxValue;

let neighborNodes (c:Node) (array:Node[,]) = [
    // Down
    if c.rc.row < MAX_ROW-1 then
        yield array.[c.rc.row+1,c.rc.col];
    // Right
    if c.rc.col < MAX_COL-1 then
        yield array.[c.rc.row, c.rc.col+1];
    // Up
    if c.rc.row > 0 then
       yield array.[c.rc.row-1, c.rc.col];
];
    

let unvisitedNodes  (arr: Node[,]) = [
    for ii in 0..(MAX_ROW-1) do
        for jj in 0..(MAX_COL-1) do
            if( arr.[ii,jj].unvisited) then
                yield arr.[ii,jj];
];

let nodeWithSmallestTentativeDistance (arr:Node[,]) = 
    unvisitedNodes arr |> List.minBy( fun x -> x.tentative_distance);

let flatten (A:'a[,]) = A |> Seq.cast<'a>;

let getColumn c (A:_[,]) =
    flatten A.[*,c..c] |> Seq.toArray

// Check all cells in rightmost column for visited.
let IsDestinationVisited (array:Node[,]) =  
    let AllUnvisited = Seq.exists (fun elem -> not elem.unvisited);
    let columnSlice = getColumn (MAX_ROW-1) array;
    let result = AllUnvisited columnSlice;
    result;
        
        
// Get tentative distance for the cell in rightmost column that is visited
let GetTentativeDistance (array:Node[,]) =
    let columnSlice = getColumn (MAX_ROW-1) array;
    let element = Array.find (fun elem -> not elem.unvisited) columnSlice;
    element.tentative_distance;

let mutable minDistance = 0;

for row in [0..MAX_ROW-1] do

    let array = Array2D.init MAX_ROW MAX_COL (fun i j -> { new Node with distance = matrix.[i].[j] and unvisited = true and tentative_distance = MAX_DISTANCE and rc = { row = i; col = j } } ); 
    let mutable CurrentNode = array.[row,0];
    CurrentNode.tentative_distance <- CurrentNode.distance;

    while false = (IsDestinationVisited array) do
        for n in (neighborNodes CurrentNode array) do
            //printf "%A\n" n.rc
            if n.unvisited then
                let tentativeDistance = CurrentNode.tentative_distance + n.distance;
                if tentativeDistance < n.tentative_distance then
                    n.tentative_distance <- tentativeDistance;
        CurrentNode.unvisited <- false;
 
        if IsDestinationVisited(array) = false then
            CurrentNode <- nodeWithSmallestTentativeDistance array;
    
    let currentAnswer = (GetTentativeDistance array);
    printf "An answer is: %A\n" currentAnswer;

    if currentAnswer < minDistance || minDistance = 0 then
        minDistance <- currentAnswer;

printf "The best answer is: %A\n" minDistance;
printf "Done\n";    
