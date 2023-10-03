(*
Khorasandzhian Levon, group 218.
*)

// Task 1 - variant 6.
// Given a list of pairs sorted by first element of a pair,
// return a grouped list,
// eg. [(1,4); (1,6); (2,4); (4,2); (4,3)] -> [(1, [4; 6]); (2, [4]); (4, [2; 3])]

// Recoursion.
let groupPairsByFirstElement1 =
    let rec groupPairs currentGroup = function
     | [] -> [currentGroup]
     | (x, y)::restPairs when x = fst currentGroup ->
         groupPairs (x, snd currentGroup@[y]) restPairs
     | (x, y)::restPairs ->
         currentGroup::groupPairs (x, [y]) restPairs

    function
     | [] -> []
     | (x, y)::restPairs -> groupPairs (x, [y]) restPairs

groupPairsByFirstElement1 [(1,4); (1,6); (2,4); (4,2); (4,3)]

// Tail recoursion.
let groupPairsByFirstElement2 =
    let rec groupPairs acc currentGroup = function
     | [] -> acc@[currentGroup]
     | (x, y)::restPairs when x = fst currentGroup ->
         groupPairs acc (x, snd currentGroup@[y]) restPairs
     | (x, y)::restPairs ->
         groupPairs (acc@[currentGroup]) (x, [y]) restPairs

    function
     | [] -> []
     | (x, y)::restPairs -> groupPairs [] (x, [y]) restPairs

groupPairsByFirstElement2 [(1,4); (1,6); (2,4); (4,2); (4,3)]

// Library functions.
let groupPairsByFirstElement3 L =
    List.groupBy(fun (x, _) -> x) L |>
    List.map(fun (x, L') -> (x, snd(List.unzip L')))

groupPairsByFirstElement3 [(1,4); (1,6); (2,4); (4,2); (4,3)]


// Task 2 - variant 1.
// Compute the sum of positive elements of a list.

// Recoursion.
let SumOfPositiveElems1 =
    let boolToInt = function
     | true -> 1
     | false -> 0
    let rec customSum = function
     | [] -> 0
     | h::t -> h * boolToInt(h > 0) + customSum(t)
    customSum

SumOfPositiveElems1 [-7; 9; -2; 3; 8; -6; -10; 4; -1; -4; 7; -9; 10; -3; -8; 5; -5; 6; -7; 2]

// Tail recoursion.
let SumOfPositiveElems2 =
    let boolToInt = function
     | true -> 1
     | false -> 0
    let rec customSum acc = function
     | [] -> acc
     | h::t -> customSum (acc + h * boolToInt(h > 0)) t
    customSum 0

SumOfPositiveElems2 [-7; 9; -2; 3; 8; -6; -10; 4; -1; -4; 7; -9; 10; -3; -8; 5; -5; 6; -7; 2]

// Library functions.
let SumOfPositiveElems3 L = List.filter((<) 0) L |> List.sum

SumOfPositiveElems3 [-7; 9; -2; 3; 8; -6; -10; 4; -1; -4; 7; -9; 10; -3; -8; 5; -5; 6; -7; 2]


// Task 3 - variant 4.
// You need to implement ALL of the following queries:
// Q1. Print the table of groups and average grade for that group
// Q2. For each subject, print the number of students who failed the exam (grade=2)
// Q3. For each group, print the student with maximum total grade (any such student, if there are many)
// eg. four.fsx - https://gist.github.com/shwars/5c2e93476f08511b4f4f2d77ce984bdf

#load "four.fsx"
open FourthDatabase

let firstTrio (a, _, _) = a
let secondTrio (_, b, _) = b
let thirdTrio (_, _, c) = c

let printQ1 =
    query {
        for groupNumber, students in List.sort(List.groupBy(firstTrio) studs) do
            select (groupNumber,
                    List.averageBy(
                        fun (_, _, grades) ->
                            (List.sumBy(snd) grades |> float) / (List.length grades |> float)
                    ) students
            )
    } |> Seq.iter(fun (num, avg) -> printfn "|%d | %f|" num avg)

printQ1

let printQ2 =
    query {
        for abbr, fullName in subjs do
            select(fullName, 
                   List.filter(
                       fun (_, _, grades) ->
                            List.exists(fun (curAbbr, grade) -> curAbbr = abbr && grade = 2) grades
                   ) studs |> List.length
            )
    } |> Seq.iter(fun (courseName, failCount) -> printfn "|%s — %d|" courseName failCount)

printQ2

let printQ3 =
    query {
        for groupNumber, students in List.sort(List.groupBy(firstTrio) studs) do
            select (groupNumber,
                    List.maxBy(
                        fun (_, _, grades) -> List.maxBy(snd) grades
                    ) students |> secondTrio
            )
    } |> Seq.iter(fun (num, name) -> printfn "|%d | %s|" num name)

printQ3
