'''
public static string[,] VoteEntry(int voters, int ranks, List<string> candidateList)
        {
            var votesEntered = new List<string>();//final vote entry
            // create and fill selection list for ranking choices with user inputs           
            var voteArray = new string[voters, ranks];//2D array made from the list(votesEntered)
            var selection = new List<string>();//this list exists to get rid of duplicates from the same voter
            var minNum = 0;// administrator can decide minimum candidates number possibly less than ranks

            var joined = "";
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("The minimum number of candidates a voter should choose: ");
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
                        else if (Convert.ToInt32(joined) <= ranks)
                        {
                            break;
                        }
                        else if (Convert.ToInt32(joined) > ranks)
                            Console.WriteLine("Please enter smaller number.");
                        else
                            break;
                    }
                    else
                        Console.WriteLine("Please enter a number.");
                }
            }
            Console.WriteLine();
            minNum = Convert.ToInt32(joined);
            Console.WriteLine("Please choose up to {0} candidate(s) represented by numbers.", ranks);
            //a line for non administorator version
            //Console.WriteLine("You can enter {0} '0' if you do not have {1} candidates to list.", ranks - minNum, ranks);
            Console.WriteLine("(e.g. For 1.John Smith, you enter 1).");
            if (minNum < ranks)
            {
                Console.WriteLine("You can enter 0 if the voter did not choose all the preferences within the minimum you set up.");
            }
            Console.WriteLine("Please press 'enter key' once to move on to the next vote.");
            Console.WriteLine();
            var i = 0;
            while (i < voters)//i represents each voter
            {
                var choiceRanks = new List<string>();

                var j = 0;

                while (j < ranks)
                {
                    Console.Write("voter{0}: ", i + 1);
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
                                if (j != ranks - 1)
                                {
                                    Console.WriteLine("Please choose at least {0} candidates.", minNum);
                                }
                                else
                                {
                                    selection.Add(joined1);
                                    j++;
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
                                                //if statement to see if have enough values(j) stored for each voter(i)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
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
'''
