# Election-Run-Off-
A program to run election run off 
Welcome to the automatic run-off election system.
=================================================
This program is for administrators to enter the votes cast and calculate the winner.

SETUP - each question below will guide you through the program.
-----
1st question is: How many voters cast their ballots in this election? (Enter a numeral from 1 to 999999999.):
You can enter number of ballots you are going to enter.

2nd question is: How many choices did each voter get? (These will be ranked. For example, first choices will be worth more than second choices. Enter a numeral from 1 to 999999].)
You can enter number of choices allowed to each voter. If your voter numbers multiplied by choices exceeds 2,147,483,647(Int32 max value), you will be prompted to enter smaller numbers.   

3rd question: What is the minimum number of votes that each voter was able to cast? (Enter a numeral from 1 and 999999999.) 
You can allow voters to enter less than the choice numbers designated. For example you can list up to 4 candidates, but also you can only choose 2 if you set up the minimum number to 2 instead.
In that case, you enter 0.

4th question: Please enter the names of each candidate on the ballot. (Names can only include letters [A - Z, a - z], spaces, hyphens [-], and apostrophes ['].) Once all candidates have been entered, type 'OK' and hit Enter.
You can enter the names of candidates runnning for an election. 

ENTER VOTES - after you customize the system to meet your needs you can start entering individual votes.
-----------

You are asked to enter the choices in order from each voter. (Enter a numeral. For example, to vote for "1. John Doe", please type "1" and hit Enter.)
To enter ballots that submitted less than the maximum number of votes, type "0" and hit enter to finish voting. (For example, if a voter only chose 2 candidates out of a maximum of 3, type '0' as the third choice.)

Voter 1, Choice 1: 1
Voter 1, Choice 2: 0
Voter 2, Choice 1: 2
Voter 2, Choice 2: 3
Voter 3, Choice 1: 1
(etc.)

The program will return the winner if the run off process is succesful:
This election's winner is:
(winner's name) 

If no candidate gets the majority of votes by the lack of votes or too many votes are a tie, the program will show a message below:
No candidate got the majority of votes.
You need to re-do election or switch to plurality vote.
