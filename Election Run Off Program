'''
static void Main(string[] args)
        {
            //Intro for the program
            Console.WriteLine("Welcome to the automatic run-off election system.");
            var divider = new StringBuilder();
            divider.Append('=', 30);
            Console.WriteLine(divider);
            Console.WriteLine("This program is for administrators to enter the votes cast and calculate the winner.");
            Console.WriteLine();
            Console.WriteLine("SET UP");
            var smallDivider = new StringBuilder();
            smallDivider.Append('-', 5);
            Console.WriteLine(smallDivider);

            //getting user input on the number of voters and allocated ranking 
            int voters = 0;
            int ranks = 0;
            var masterCandidateList = new List<string>();
            var votesOriginal = new int[voters, ranks];

            while (true)//while loop will validate voters and ranks
            {
                Console.WriteLine("How many voters cast their ballots in this election? (Enter a numeral from 1 to 999999999.): ");
                voters = NumberValidation();
                Console.WriteLine();
                Console.WriteLine("How many choices did each voter get? (These will be ranked. For example, first choices will be worth more than second choices. Enter a numeral from 1 to 999999999].): ");
                ranks = NumberValidation();

                if (voters >= 2 && ranks > 0)
                {
                    if((voters/ranks) >= (Int32.MaxValue/ranks))
                    {
                        Console.WriteLine("The choices exceed the maximum value.");
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }                    
                }
                else
                {
                    Console.WriteLine("You need more voters and/or ranks.");
                    Console.WriteLine();
                }                    
            }
            //list names of candidates
            masterCandidateList = OriginalCandidateList();
            Console.WriteLine();
            //Result function will take in votes and calculate
            var finalResult = Result(voters, ranks, masterCandidateList);
            if(!String.IsNullOrWhiteSpace(finalResult))
            {
                Console.WriteLine();
                Console.WriteLine("This election's winner is: ");
                Console.WriteLine(masterCandidateList[Convert.ToInt32(finalResult) - 1]);
            }
            
        }
        public static int NumberValidation()
        {
            var validatedNumber = 0;
            while (true)
            {
                Console.Write("Enter a number: ");
                var temp = Console.ReadLine();
                var choiceRanks = new List<string>();
                var joined = "";

                if (!String.IsNullOrWhiteSpace(temp))
                {
                    //while (d < temp.Length) breaks down string to char to make sure each char is valid
                    var d = 0;
                    while (d < temp.Length)
                    {
                        //skip any white space from the user input
                        if (Char.IsWhiteSpace(temp[d]))
                            d++;
                        //any valid number will be stored to a list (choiceRank)
                        else if (Char.IsDigit(temp[d]))
                        {
                            choiceRanks.Add(temp[d].ToString());
                            d++;
                        }
                        else// cover non digit inputs
                            d++;
                    }
                    //put each char into one string to cover any number bigger than 9
                    joined = String.Join("", choiceRanks.ToArray());
                    choiceRanks.Clear();
                    if (!String.IsNullOrWhiteSpace(joined))
                    {
                        if (joined.Length > 9)// allow user enter up 999,999,999 votes
                        {
                            Console.WriteLine("The number you entered exceeds the limit.");
                        }
                        else
                        {
                            validatedNumber = Convert.ToInt32(joined);
                        }
                        break;
                    }
                    else
                        Console.WriteLine("Please enter a number.");
                }
            }
            return validatedNumber;
        }
        public static List<string> OriginalCandidateList()
        {
            var nameList = new List<string>();
            var letterList = new List<string>();
            string joined;
            Console.WriteLine();
            Console.WriteLine("Please enter the names of each candidate on the ballot. (Names can only include letters [A - Z, a - z], spaces, hyphens [-], and apostrophes ['].) Once all candidates have been entered, type 'OK' and hit Enter.");
            Console.WriteLine();
            var candidateCounter = 1;
            while (true)
            {
                Console.Write("Name of Candidate {0}: ", candidateCounter);              
                var firstTemp = Console.ReadLine();
                var d = 0;
                if (!String.IsNullOrWhiteSpace(firstTemp))
                {
                    var temp = firstTemp.Trim();//trim the beginning and end of white space

                    while (d < temp.Length)
                    {
                        if (Char.IsLetter(temp[d]))
                        {
                            letterList.Add(temp[d].ToString());
                            d++;
                        }
                        else if (temp[d] == '-' || temp[d] == '\'')//some names have hyphene and apostrophy
                        {
                            letterList.Add(temp[d].ToString());
                            d++;
                        }
                        //skip any white space from the user input unless it is only one space
                        else if (temp[d] == ' ')
                            if (!Char.IsWhiteSpace(Convert.ToChar(letterList[letterList.Count - 1])))
                            {
                                letterList.Add(temp[d].ToString());
                            }
                            else
                                d++;

                        else//covers non letter, excludes hyphens and apostrophies                    
                            d++;
                    }
                }
                else
                    continue;

                joined = String.Join("", letterList.ToArray());

                if (!String.IsNullOrWhiteSpace(joined))
                {
                    if (joined.ToLower() != "ok" & joined.ToLower() != "o k")
                    {
                        if (!nameList.Contains(joined))
                        {
                            nameList.Add(joined);
                            letterList.Clear();
                            candidateCounter++;
                        }
                    }
                    else
                        break;
                }                    
            }
            Console.WriteLine();
            Console.WriteLine("The candidates for this election are: ");
            for (var i = 0; i < nameList.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, nameList[i]);
            }
            return nameList;
        }
        public static string[,] VoteEntry(int voters, int ranks, List<string> candidateList)
        {
            var votesEntered = new List<string>();//final vote entry
            // create and fill selection list for ranking choices with user inputs           
            var voteArray = new string[voters, ranks];//2D array made from the list(votesEntered)
            var selection = new List<string>();//this list exists to get rid of duplicates from the same voter
            var minNum = 0;// administrator can decide minimum candidates number possibly less than ranks
            var joined = "";
            Console.WriteLine("ENTER VOTES");
            var smallDivider = new StringBuilder();
            smallDivider.Append('-', 5);
            Console.WriteLine(smallDivider);

            while (true)
            {
                Console.WriteLine();
                Console.Write("What is the minimum number of votes that each voter was able to cast? (Enter a numeral from 1 and 999999999.): ");
                var temp = Console.ReadLine();
                var choiceRanks = new List<string>();

                if (!String.IsNullOrWhiteSpace(temp))
                {
                    //while (d < temp.Length) breaks down string to char to make sure each char is valid
                    var d = 0;
                    while (d < temp.Length)
                    {
                        //skip any white space from the user input
                        if (Char.IsWhiteSpace(temp[d]))
                            d++;
                        //any valid number will be stored to a list (choiceRank)
                        else if (Char.IsDigit(temp[d]))
                        {
                            choiceRanks.Add(temp[d].ToString());
                            d++;
                        }
                        else// cover non digit inputs
                            d++;
                    }
                    //put each char into one string to cover any number bigger than 9
                    joined = String.Join("", choiceRanks.ToArray());
                    choiceRanks.Clear();
                    if (!String.IsNullOrWhiteSpace(joined))
                    {
                        if (joined.Length > 9)// allow user enter up 999,999,999 votes
                        {
                            Console.WriteLine("The number you entered exceeds the limit.");
                        }
                        else if(voters / Convert.ToInt32(joined) > Int32.MaxValue/ Convert.ToInt32(joined))
                        {
                            Console.WriteLine("The minimum cannot exceed the maximum value.");
                        }
                        else if (Convert.ToInt32(joined) == 0)
                            Console.WriteLine("The minimum numbre cannot be zero. ");
                        
                        else if (Convert.ToInt32(joined) > ranks)
                            Console.WriteLine("Please enter smaller number.");
                        else if (Convert.ToInt32(joined) <= ranks)
                        {
                            if(Convert.ToInt32(joined) <= candidateList.Count)
                            {
                                break;
                            }
                            Console.WriteLine("The minimum cannot exceed the number of candidates.");
                        }
                        else
                            break;
                    }
                    else
                        Console.WriteLine("Please enter a number.");
                }
            }
            Console.WriteLine();
            minNum = Convert.ToInt32(joined);
            Console.WriteLine("Please enter the {0} choices in order from each voter. Enter a numeral (For example, to vote for \"1.John Doe\", please type \"1\" and hit Enter).To enter ballots that submitted less than the maximum number of votes, type \"0\" and hit enter to finish voting. (For example, if a voter only chose 2 candidates out of a maximum of 3, type '0' as the third choice.)", ranks);
       
            Console.WriteLine();
            var i = 0;
            while (i < voters)//i represents each voter
            {
                var choiceRanks = new List<string>();
                var zeroCounter = 0;
                var j = 0;
                var choiceCount = 1;
                while (j < ranks)
                {                   
                    Console.Write("Voter{0}, Choice {1}: ", i + 1, choiceCount);
                    var temp = Console.ReadLine();

                    if (!String.IsNullOrWhiteSpace(temp))
                    {
                        //while (d < temp.Length) breaks down string to char to make sure each char is valid
                        var d = 0;
                        while (d < temp.Length)
                        {
                            //skip any white space from the user input
                            if (Char.IsWhiteSpace(temp[d]))
                                d++;
                            //any valid number will be stored to a list (choiceRank)
                            else if (Char.IsDigit(temp[d]))
                            {
                                choiceRanks.Add(temp[d].ToString());
                                d++;
                            }
                            else// cover non digit inputs
                                d++;
                        }
                        //put each char into one string to cover any number bigger than 9
                        var joined1 = String.Join("", choiceRanks.ToArray());
                        choiceRanks.Clear();
                        
  
                        if (!String.IsNullOrWhiteSpace(joined1))
                        {
                            if (joined1 == "0")
                            {
                                if(j != 0)
                                {
                                    if (zeroCounter > ranks - minNum)
                                    {
                                        Console.WriteLine("Please choose at least {0} candidates.", minNum);
                                    }
                                    else
                                    {
                                        selection.Add(joined1);
                                        j++;
                                        zeroCounter++;
                                        choiceCount++;
                                    }
                                }                                
                            }
                            else
                            {
                                string a = "The number you entered exceeds the limit.";
                                if (joined1.Length > 10)
                                {
                                    Console.WriteLine(a);
                                }
                                else if (Convert.ToInt32(joined1) > Int32.MaxValue)
                                {
                                    Console.WriteLine(a);
                                }
                                else
                                {
                                    for (var k = 0; k < candidateList.Count; k++)
                                    {
                                        if (Convert.ToInt32(joined1) == k + 1)
                                        {
                                            //the final step to add each value to a list 
                                            if (!selection.Contains(joined1))
                                            {
                                                selection.Add(joined1);
                                                j++;
                                                choiceCount++;
                                                //if statement to see if have enough values(j) stored for each voter(i)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a candidate.");
                            choiceCount--;
                        }                           
                    }
                    else
                        Console.WriteLine("Please enter a candidate.");
                }
                //move the values from voter(i) to votesEntered => use it for vote counting 
                foreach (var choice in selection)
                    votesEntered.Add(choice);
                //clear selection list, so it can store next voter(i)'s values 
                selection.Clear();
                //increment i to end while (j < ranks)
                i++;
            }
            //put original vote list to 2Darray(voteArray)
            for (var l = 0; l < voters; l++)
            {
                var rankReversed = ranks;
                for (var m = 0; m < ranks; m++)
                {
                    voteArray[l, m] = votesEntered[(l + 1) * ranks - rankReversed].ToString();
                    rankReversed--;
                }
            }
            return voteArray;
        }
        public static string Result(int voters, int ranks, List<string> candidateList)
        {
            var lostList = new List<string>();
            string[,] voteArray = new string[voters, ranks];
            var newVotes = new List<string>();
            var winner = "";
            //create dictionary for counting
            var dict = new Dictionary<string, int>();
            voteArray = VoteEntry(voters, ranks, candidateList);

            while (true)
            {
                //create function take the [0] vote and make a string
                newVotes = ReCounting(voters, ranks, lostList, voteArray);
                if (newVotes.Count == 0)
                {
                    Console.WriteLine("No candidate got the majority of votes. ");
                    Console.WriteLine("You need to re-do election or switch to plurality vote.");
                    break;
                }
                //take all the votes in and sort by value
                foreach (var value in newVotes)
                {
                    if (dict.ContainsKey(value))
                        dict[value]++;
                    else
                        dict[value] = 1;
                }
                var listValue = new List<int>();
                var listKey = new List<string>();
                foreach (KeyValuePair<string, int> candidates in dict.OrderByDescending(key => key.Value))
                {
                    listValue.Add(candidates.Value);
                    listKey.Add(candidates.Key);
                }

                var topVoteKey = listKey[0];//get the fist key
                var topVoteValue = listValue[0];

                //if the top vote gets a majority, he or she is a winner: if not, runn off procedure begins
                if (Convert.ToInt32(topVoteValue) > voters * 1 / 2)
                {
                    //Console.WriteLine("The winner is:{0} ", topVoteKey);
                    winner = topVoteKey;
                    break;
                }
                else
                {
                    //delete the candidate(s) who got the least votse and add their names to the lostList               
                    foreach (KeyValuePair<string, int> entry in dict)
                    {
                        if (entry.Value == listValue[listValue.Count - 1])
                        {
                            lostList.Add(entry.Key);
                        }
                    }
                }
                dict.Clear();
                newVotes.Clear();//start recounting again
                listValue.Clear();
                listKey.Clear();
            }
            return winner;

        }
        public static List<string> ReCounting(int voters, int ranks, List<string> lostList, string[,] voteArray)
        {
            //Recounting votes while eliminating lost candidates' votes
            var newVotes = new List<string>();
            var lostCount = 0;
            for (var i = 0; i < voters; i++)
            {
                lostCount = 0;
                for (var j = 0; j < ranks; j++)
                {
                    if (lostList.Count != 0)//add [i,0] to the newVotes
                    {
                        if (!lostList.Contains(voteArray[i, j]))
                        {
                            if (lostCount != 0 && lostCount < ranks)
                            {
                                if (voteArray[i, j] != "0")
                                {
                                    newVotes.Add(voteArray[i, j]);
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                newVotes.Add(voteArray[i, j]);
                                break;
                            }
                        }
                        else
                        {
                            lostCount++;
                        }
                    }
                    else//this code covers first round
                    {
                        newVotes.Add(voteArray[i, j]);
                        break;
                    }

                }
            }
            return newVotes;
        }
    }
}
'''
