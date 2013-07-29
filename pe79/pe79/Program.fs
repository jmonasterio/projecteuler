// Learn more about F# at http://fsharp.net

let keys = [ 319;
    680;
    180;
    690;
    129;
    620;
    762;
    689;
    762;
    318;
    368;
    710;
    720;
    710;
    629;
    168;
    160;
    689;
    716;
    731;
    736;
    729;
    316;
    729;
    729;
    710;
    769;
    290;
    719;
    680;
    318;
    389;
    162;
    289;
    162;
    718;
    729;
    319;
    790;
    680;
    890;
    362;
    319;
    760;
    316;
    729;
    380;
    319;
    728;
    716;
];

let findIndexNoEx k arr =
    try
        Array.findIndex (fun x -> x = k) arr;
    with
        | _ -> -1;
        
let mutable curr = [||];

let makepass keys = 

   let digkeys = List.map (fun k -> [k/100; (k/10)%10; k%10]) keys;

   let swap (idx1:int) (idx2:int) (curr:int array) :unit =
        let tmp = curr.[idx1];
        curr.[idx1] <- curr.[idx2]
        curr.[idx2] <- tmp;
        

   let mapper (lst:int list) = 
        let k1 = (lst.Item 0);
        let k2 = (lst.Item 1);
        let k3 = (lst.Item 2);
        let mutable k1idx = findIndexNoEx k1 curr;
        let mutable k2idx = findIndexNoEx k2 curr;
        let mutable k3idx = findIndexNoEx k3 curr;
        // printfn "%A %A %A" k1idx k2idx k3idx;

        if k1idx = -1 then
            k1idx <- (Array.length curr);
            curr <- Array.append curr [|k1|];
        if k2idx = -1 then
            k2idx <- (Array.length curr);
            curr <- Array.append curr [|k2|];
        if k3idx = -1 then
            k3idx <- (Array.length curr);
            curr <- Array.append curr [|k3|];

        if k1idx <> -1 && k2idx <> -1 then
            if k1idx > k2idx then
                swap k1idx k2idx curr;    

        if k2idx <> -1 && k3idx <> -1 then
            if k2idx > k3idx then
                swap k2idx k3idx curr;

        printfn "%A" curr;
        0;

   let xxx = digkeys |> List.map( fun lst -> mapper lst);

   0;
    
let x = makepass keys;

printfn "DONE";