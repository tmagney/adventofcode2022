namespace AdventOfCode2022
{
    using System.IO;

    public class Day3
    {
        private string text = String.Empty;
        private IList<string> input = new List<string>();
        public Day3(bool isTest)
        {
            var filename = isTest ? "day3-test.txt" : "day3.txt";

            text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\inputs\" + filename);
            input = text.Split(Environment.NewLine);            
        }

        public void printResult1()
        {
            var count = 0;
            foreach(var line in input)
            {
                var sub1 = line.Substring(0, line.Length/2);
                var sub2 = line.Substring(line.Length/2);

                count = count + getScore(sub1.Intersect(sub2).First());
            }        

            Console.WriteLine(count);
        }

        public void printResult2()
        {
            var count = 0;
            for(var i = 0; i < input.Count; i = i + 3)
            {
                var c = input[i].Intersect(input[i+1].Intersect(input[i+2])).First();
                count = count + getScore(c);
            }

            Console.WriteLine(count);
        }

        private int getScore(char c)
        {
            return (char.IsUpper(c) ? (int)c - 38 : (int)c - 96);
        }
    }
}
