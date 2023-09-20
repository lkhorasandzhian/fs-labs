(*
Khorasandzhian Levon, group 218, variant 8.
*)

// Print a table of a given function f, computed by taylor series

// function to compute
let f = fun x -> 1./(2.*x - 5.)

let a = 0.0
let b = 2.0
let n = 10


(*
TAYLOR NAIVE METHOD
*)


// Custom 'for' declaration.
let rec my_for f i a b =
    if a <= b then f a (my_for f i (a+1) b)
    else i

// Custom 'pow' declaration.
let pow x n = my_for (fun _ acc -> acc*x) 1. 1 n

// Const 'eps' function.
let eps = pow 0.1 9

// Taylor i-element.
let i_element x n = (-1.)*(pow 2 (n-1))*(pow x (n-1))/(pow 5 n)

// Naive 'while' declaration.
let rec while_naive x sum n =
    let current_elem = i_element x n
    if abs(current_elem) > eps then while_naive x (sum + current_elem) (n + 1)
    else (sum, n)

// Pair tools.
let fst (a, _) = a
let snd (_, b) = b

// Define a function to compute f using naive taylor series method.
let taylor_naive x = while_naive x 0. 1


(*
TAYLOR SMART METHOD
*)


let taylor_multiplier x elem_i = 0.4 * x * elem_i

let rec while_smart x elem_i sum n =
    if abs(elem_i) > eps then while_smart x (taylor_multiplier x elem_i) (sum + elem_i) (n + 1)
    else (sum, n)

// Define a function to do the same in a more efficient way.
let taylor_smart x = while_smart x (i_element x 1) 0. 1


(*
OUTPUT TABLE
*)


let main =
    printfn "--------------------------------------------------------------------------"
    printfn "|  x  |    f(x)    |   Naive    |    Iters    |   Smart    |    Iters    |"
    printfn "--------------------------------------------------------------------------"
    for i=0 to n do
      let x = a+(float i)/(float n)*(b-a)
      let res_naive = taylor_naive x
      let res_smart = taylor_smart x
      printfn "|%5.2f|  %10.6f|  %10.6f|   %10d|  %10.6f|   %10d|" x (f x) (fst res_naive) (snd res_naive) (fst res_smart) (snd res_smart)
    printfn "--------------------------------------------------------------------------"

main
