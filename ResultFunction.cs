'''
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
'''
