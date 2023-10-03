# FP: Lab 2. Working with lists

## Problem 1
Please, implement the following list processing function (chose one function according to your number in the list):

    1. Split list of integers into two other lists - with positive and negative elements. Ignore 0s.
    2. Merge two sorted lists in such a way that result is also sorted.
    3. Sort a list using bubble sort
    4. Multiply each element of a list by its position in a list, starting with 1
    5. Given two lists of equal length, one of arbitrary type, another one boolean, return masked list, consisting of elements from first list that correspond to True in the second list, eg. process([1,5,3],[True,False,True]) -> [1,3]
    6. Given a list of pairs sorted by first element of a pair, return a grouped list, eg. [(1,4),(1,6),(2,4),(4,2),(4,3)] -> [(1,[4,6]),(2,[4]),(4,[2,3])]

## Problem 2
Implement the following list processing function:

    1. Compute the sum of positive elements of a list
    2. Check if a list is sorted in ascending order
    3. Check if a list is an arithmetic progression
    4. Check if a list contains only positive elements
    5. Compute min and max element of a list

## Problem 3
You need to implement a database of students and their exam grades. Students can belong to different groups
(in our case, from 101 to 104), and they have a number of exam grades (numbers from 2 to 5) on different subjects.

Sample data is provided, please select the data representation according to your number in the group list using ((N-1) mod 4) + 1 formula:

    one.fsx - https://gist.github.com/shwars/05a1e381bc74c3dc26c59b0e6cb1210e
    two.fsx - https://gist.github.com/shwars/046e52a3139f4ecd6ddf0ce62bc6a790
    three.fsx - https://gist.github.com/shwars/4a46c102dce3fe89a57960c2ef3f381b
    four.fsx - https://gist.github.com/shwars/5c2e93476f08511b4f4f2d77ce984bdf

You need to implement ALL of the following queries:  
Q1. Print the table of groups and average grade for that group  
Q2. For each subject, print the number of students who failed the exam (grade=2)  
Q3. For each group, print the student with maximum total grade (any such student, if there are many)  
