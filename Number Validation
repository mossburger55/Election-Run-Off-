'''public static int NumberValidation()
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
        '''
