namespace AdventOfCode2022
{
    using System.IO;

    public class Day5
    {
        private string text = String.Empty;
        private IList<string> input = new List<string>();
        private IList<List<string>> stacks;
        private IList<string> commands;

        public Day5(bool isTest)
        {
            var filename = isTest ? "day5-test.txt" : "day5.txt";

            text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\inputs\" + filename);
            input = text.Split(Environment.NewLine + Environment.NewLine);
            initStacks(input[0].Split(Environment.NewLine));
            commands = input[1].Split(Environment.NewLine);            
        }

        public void printResult1()
        {
            foreach(var command in commands)
            {
                var number = Int32.Parse(command.Split("move ")[1].Split(" ").First());
                var source = Int32.Parse(command.Split("from ")[1].Split(" ").First()) - 1;
                var destination = Int32.Parse(command.Split("to ")[1].Split(" ").First()) - 1;

                moveCrates(number, source, destination);
            }

            printStacks();
        }

        public void printResult2()
        {
            foreach(var command in commands)
            {
                var number = Int32.Parse(command.Split("move ")[1].Split(" ").First());
                var source = Int32.Parse(command.Split("from ")[1].Split(" ").First()) - 1;
                var destination = Int32.Parse(command.Split("to ")[1].Split(" ").First()) - 1;

                moveCratesInOrder(number, source, destination);
            }

            printStacks();
        }

        private void printStacks()
        {
            string answer = String.Empty;
            foreach(var stack in stacks)
            {
                answer += stack.First();
            }

            Console.WriteLine(answer);
        }

        private void moveCrates(int number, int source, int destination)
        {
            for(int i = 0; i < number; i++)
            {
                var crate = stacks[source][0];
                stacks[source].RemoveAt(0);
                stacks[destination].Insert(0, crate);
            }
        }

        private void moveCratesInOrder(int number, int source, int destination)
        {
            var crates = stacks[source].GetRange(0, number);

            stacks[source].RemoveRange(0, number);
            stacks[destination].InsertRange(0,crates);
        }

        private void initStacks(IList<string> lines) {
            
            var count = Int32.Parse(lines.Where(l => !l.Contains("[")).First().Split(" ").Where(c => c != "").Last());
            var width = lines[0].Split("").First().Count();

            stacks = new List<List<string>>();
            for(int i = 0; i < count; i++){                               
                stacks.Add(new List<string>());
            }

            for(int i = lines.Count() - 2; i >= 0; i--)
            {
                for(int j = 0; j < width; j += 4){
                    if(lines[i][j].ToString() == "[" )
                    {
                        var stackNumber = j/4;
                        stacks[stackNumber].Insert(0, lines[i][j+1].ToString());
                    }
                }
            }
        }
    }
}
