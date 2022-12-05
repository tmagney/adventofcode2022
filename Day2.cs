namespace AdventOfCode2022
{
    using System.IO;

    public class Day2
    {
        enum RPS : int
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3,
        }

        private string text = String.Empty;
        private IList<string> input = new List<string>();
        public Day2(bool isTest)
        {
            var filename = isTest ? "day2-test.txt" : "day2.txt";

            text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\inputs\" + filename);
        }

        public void printResult1()
        {
            var totalScore = 0;
            input = text.Split(Environment.NewLine);

            foreach(var game in input)
            {
                var them = getShot(game.Split(" ")[0]);
                var me = getShot(game.Split(" ")[1]);

                totalScore = totalScore + scoreShot(them, me);
            }

            Console.WriteLine(totalScore);
        }

        public void printResult2()
        {
            var totalScore = 0;
            input = text.Split(Environment.NewLine);

            foreach(var game in input)
            {
                var them = getShot(game.Split(" ")[0]);
                var me = getExpectedShot(them, game.Split(" ")[1]);

                totalScore = totalScore + scoreShot(them, me);
            }

            Console.WriteLine(totalScore);
        }

        private RPS getShot(string shot)
        {
            RPS rps = RPS.Rock;
            switch (shot)
            {
                case "B":
                case "Y":
                rps = RPS.Paper;
                break;

                case "C":
                case "Z":
                rps = RPS.Scissors;
                break;
            }
            return rps;
        }

        private RPS getExpectedShot(RPS them, String result)
        {
            RPS expected = them;

            if(result == "X") //loose
            {
                if(them == RPS.Rock)
                {
                    expected = RPS.Scissors;
                } else if (them == RPS.Paper) {
                    expected = RPS.Rock;
                } else {
                    expected = RPS.Paper;
                }
            } else if (result == "Z"){ //win
                if(them == RPS.Rock)
                {
                    expected = RPS.Paper;
                } else if (them == RPS.Paper) {
                    expected = RPS.Scissors;
                } else {
                    expected = RPS.Rock;
                }
            }

            return expected;
        }

        private int scoreShot(RPS them, RPS me) {
            
            int score = (int)me;
            if(them == me)
            {
                score = score + 3;
            } else if(
                them == RPS.Rock && me == RPS.Paper ||
                them == RPS.Paper && me == RPS.Scissors ||
                them == RPS.Scissors && me == RPS.Rock        
            ) {
                score = score + 6;
            }

            return score;
        }
    }
}
