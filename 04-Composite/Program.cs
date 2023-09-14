namespace _04_Composite
{
    public class Program
    {
        static void Main(string[] args)
        {
            var root = new Composite.Directory("root",0);
            var topLevelFile = new Composite.File("topLevel.txt",4);
            var topLevelDirectory1 = new Composite.Directory("topLevelDirectory1s", 4);
            var topLevelDirectory2 = new Composite.Directory("topLevelDirectory2", 4);

            root.Add(topLevelFile);
            root.Add(topLevelDirectory1);
            root.Add(topLevelDirectory2);

            var subLevelFile1 = new Composite.File("subLevel1.txt", 200);
            var subLevelFile2 = new Composite.File("subLevel2.txt", 150);
            topLevelDirectory2.Add(subLevelFile1);
            topLevelDirectory2.Add(subLevelFile2);
            Console.WriteLine($"Size of topLevelDirectory1:{topLevelDirectory1.GetSize()}");
            Console.WriteLine($"Size of topLevelDirectory2:{topLevelDirectory2.GetSize()}");
            Console.WriteLine($"Size of root :{root.GetSize()}");
            Console.ReadKey();
        }
    }
}