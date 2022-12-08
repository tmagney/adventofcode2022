namespace AdventOfCode2022
{
    using System.IO;

    public class Day4
    {
        private string text = String.Empty;
         private IList<string> input = new List<string>();

        public Day4(bool isTest)
        {
            var filename = isTest ? "day4-test.txt" : "day4.txt";

            text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\inputs\" + filename);
            input = text.Split(Environment.NewLine);            
        }

        public void printResult1()
        {
            var count = 0;
            foreach(var line in input)
            {
                var sections = line.Split(",");
                
                var elf1 = getRange(sections[0]);
                var elf2 = getRange(sections[1]);

                if(elf1.All(x => elf2.Contains(x)) ||
                    elf2.All(x=> elf1.Contains(x)))
                {
                    count++;
                }
            }

            Console.WriteLine(count);            
        }

        public void printResult2()
        {
            var count = 0;
            foreach(var line in input)
            {
                var sections = line.Split(",");
                
                var elf1 = getRange(sections[0]);
                var elf2 = getRange(sections[1]);

                if(elf1.Any(x => elf2.Contains(x)))
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        private IEnumerable<int> getRange(string range){
            var r = range.Split("-").Select(int.Parse);
            return Enumerable.Range(r.First(), r.Last() - r.First() + 1);
        }
    }
}
