namespace AdventOfCode2022
{
    using System.IO;

    public class Day7
    {
        private string text = String.Empty;
        private IList<string> input = new List<string>();

        private IList<int> sizes = new List<int>();

        private Dir root;

        public Day7(bool isTest)
        {
            var filename = isTest ? "day7-test.txt" : "day7.txt";

            text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\inputs\" + filename);

            input = text.Split(Environment.NewLine);
            input = input.Where(l => l != "$ cd /").ToList();
        
            root = new Dir("/");

            serialize();            
            setSizes(root);
            sizes = sizes.OrderBy(s => s).ToList();
        }

        public void printResult1()
        {
            Console.WriteLine(sizes.Where(s => s <= 100000).Sum());
        }

        public void printResult2()
        {
            int unused = 70000000 - root.getSize();
            int needed = 30000000 - unused; 

            Console.WriteLine(sizes.Where(s => s >= needed).First());
        }

        private void serialize(){
            var current = root;        
            
            int i = 0;
            foreach(string line in input)
            {
                i++;
 
                if(line.StartsWith("$ cd"))
                {
                    if(line == "$ cd ..")
                    {
                        current = current.Parent;
                    }
                    else{
                        var dir = new Dir(line);
                        dir.Parent = current;
                        current.Children.Add(dir);
                        current = current.Children.Last();
                    }
                    
                } else if(line.StartsWith("$ ls")){
                    //?
                }
                else if(line.StartsWith("dir")) {
                    //Skip. Add dir when we see cd command.
                } else { //must be a file
                    current.Files.Add(new Fl(line));    
                }
            }
        }

        private void setSizes(Dir dir)
        {
            var size = dir.getSize();
            sizes.Add(size);
            foreach(var d in dir.Children)
            {
                setSizes(d);
            }
        }

        internal class Fl {
            internal string Name;
            internal int Size;

            internal Fl(String name, int size){
                Name = name;
                Size = size;
            }

            internal Fl(string input)
            {
                Name = input.Split(" ").Last();
                Size = Int32.Parse(input.Split(" ").First());
            }
        }

        internal class Dir {
            
            internal string Name;

            internal bool CurrentDir = false;

            internal Dir Parent;

            internal IList<Dir> Children;
            internal IList<Fl> Files;

            internal Dir(string input)
            {
                Name = input.Split(" ").Last();
                Children = new List<Dir>();
                Files = new List<Fl>();
            }

            internal int getSize() => Children.Sum(d => d.getSize()) + Files.Sum(fl => fl.Size); 
        }
    }
}
