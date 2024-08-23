'''public static List<string> OriginalCandidateList()
        {
            var nameList = new List<string>();
            var letterList = new List<string>();
            string joined;
            Console.WriteLine("Please type the candidates' name and press enter key to enter the next one.");
            Console.WriteLine("Please press 'OK' to finish.");
            Console.WriteLine();
            while (true)
            {
                Console.Write("Name: ");
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
                    if (joined.ToLower() != "ok" & joined.ToLower() != "o k")
                    {
                        if (!nameList.Contains(joined))
                        {
                            nameList.Add(joined);
                            letterList.Clear();
                        }
                    }
                    else
                        break;
            }
            Console.WriteLine();
            Console.WriteLine("The candidate list is: ");
            for (var i = 0; i < nameList.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, nameList[i]);
            }
            return nameList;
        }
        '''
