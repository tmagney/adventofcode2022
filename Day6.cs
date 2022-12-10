namespace AdventOfCode2022
{
    using System.IO;

    public class Day6
    {
        private string text = String.Empty;
        private IList<string> input = new List<string>();
        
        public Day6(bool isTest)
        {
            var filename = isTest ? "day6-test.txt" : "day6.txt";

            text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\inputs\" + filename);

            //input = text.Split(Environment.NewLine);
        }

        public void printResult1()
        {
            for(int i = 4; i < text.Length; i++)
            {
                var sub = text.Substring(i - 3, 4);
                
                if(sub.ToList().Distinct().Count() == 4)
                {
                    Console.WriteLine(i + 1);
                    return;
                }
            }
        }

        public void printResult2()
        {
            for(int i = 13; i < text.Length; i++)
            {
                var sub = text.Substring(i - 13, 14);
                
                if(sub.ToList().Distinct().Count() == 14)
                {
                    Console.WriteLine(i + 1);
                    return;
                }
            }           
        }
    }
}
