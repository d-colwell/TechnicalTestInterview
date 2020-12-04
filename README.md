# CorpCorp Box Decisioning Algoritm
## Our Objective
We here at Corpcorp are very concerned with Boxes. People often send us files, full of boxes and we are then responsible for chosing the best boxes out of this file.

## How do we choose the best boxes? 
Boxes come in files, with a single header record, 4 coordinates and one decimal value (between zero and 1) representing how much the customer likes the box. There many be an arbitrarily large number of boxes in the file.

The 4 coordinates are: Center X,Center Y,Width,Height, so an example of a box file would look like this:
|Center X | Center Y | Width | Height | Rank |
|----|----|----|----|----|
| 6 | 5 | 4 | 3 | 0.8 |
This would give a box that looks like this:


<img src="./Images/box-example.png" width="400px"/>

The problem is, that some of these boxes overlap.
We want to minimise the number of boxes by suppressing some of them. 
Each boxes has a Rank which denotes how important it is. 
Higher rank values supercede lower values.

In order to determine which rectangles will be suppressed, we will use a technique called the Jaquard Index.
The formula for the Jaqard index is (Intersecting area of the rectangles)/(Union of the area of the rectangles)

<img src="https://miro.medium.com/max/422/1*9vgYblWTjP0Np7q_PUmlrw.png" width="600px" />

If the Intersection over Union (Jaqard Index) is greater than a certain value (called the Jaqard index threshold), then the box with the lower Rank will be ignored. The jaqard index threshold is from zero to 1

In order to make our algorithm faster, we also have a Rank Threshold. Boxes below a certain Rank threshold will be ignored entirely! 

<img src="./Images/poof.gif" width="200px"/>

## What do we want you to do?
In this fictional situation, you will have 2 tasks. First, write a set of acceptance criteria for this algorithm, using whatever format you feel comfortable with.

Second we have written an algoritm, you can find it in the [Code](./Code) directory. We are not really sure that it is working very well. Your job is to write some *automated* tests for it, to determine if it is working correctly.

Please note:
1. Tests should be written in C#
2. Tests should be able to be run using a test framework such as NUnit, XUnit, MSTest, etc
3. There are bugs in the program, we want you to find them
4. There is an example file [Boxes.csv](./Code/boxes.csv) for you to use as a reference. Feel free to copy it and modify it, it is randomised data.

## How do i use the program?

You can call the command line by building the project and calling the output executable `InterviewBenchmark.exe "input file" "jaqard threshold" "rank threshold"`
Passing no values will result in defaults being passed. Read the code to find out what they are

Alternatively, you could use the `BoxSuppressor` class directly from coded component tests.

Happy testing!
