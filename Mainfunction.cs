'''
      static void Main(string[] args)
        {
            //getting user input on the number of voters and allocated ranking 
            int voters = 0;
            int ranks = 0;
            var masterCandidateList = new List<string>();
            var votesOriginal = new int[voters, ranks];

            while (true)//while loop will validate voters and ranks
            {
                Console.Write("How many voters?: ");
                voters = NumberValidation();

                Console.Write("How many ranks(choices)?: ");
                ranks = NumberValidation();

                if (voters >= 2 && voters > ranks)
                {
                    break;
                }
                else
                    Console.WriteLine("You need more voters and/or ranks.");
            }
            //list names of candidates
            masterCandidateList = OriginalCandidateList();

            //Result function will take in votes and calculate
            var finalResult = Result(voters, ranks, masterCandidateList);

            Console.WriteLine();
            Console.WriteLine("The elected candidate is: ");
            Console.WriteLine(masterCandidateList[Convert.ToInt32(finalResult) - 1]);
        }
