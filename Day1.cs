namespace AdventOfCode2022
{
    using System.IO;

    public class Day1
    {
        private string text = String.Empty;
        private IList<string> input = new List<string>();
        public Day1(bool isTest)
        {
            var filename = isTest ? "day1-test.txt" : "day1.txt";

            text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\inputs\" + filename);
        }

        public void printResult1()
        {
            input = text.Split(Environment.NewLine);

            var maxCalories = 0;
            var currentCalories = 0;

            for(int i = 0; i < input.Count; i++)
            {
                var meal = input[i];

                if(meal != String.Empty)
                {
                    currentCalories = currentCalories + Int32.Parse(input[i]);
                }
                
                if(meal == String.Empty || i == input.Count - 1){
                    
                    if(currentCalories > maxCalories) {
                        maxCalories = currentCalories;
                    }
                    currentCalories = 0;
                }
            }

            Console.WriteLine(maxCalories);
        }

        public void printResult2()
        {
            input = text.Split(Environment.NewLine);

            var maxCalories = new List<int>();
            var currentCalories = 0;

            for(int i = 0; i < input.Count; i++)
            {
                var meal = input[i];

                if(meal != String.Empty)
                {
                    currentCalories = currentCalories + Int32.Parse(input[i]);
                }
                
                if(meal == String.Empty || i == input.Count - 1){
                    
                    Console.WriteLine("currentCalories: " + currentCalories);
                    maxCalories.Add(currentCalories);
                    currentCalories = 0;
                }
            }

            var max = maxCalories.OrderDescending().Take(3).Sum();
            Console.WriteLine(max);
        }

    }
}
