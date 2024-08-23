'''
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
'''
