using SerilogReaderApp.Models;
class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length < 2) //coz should be pattern and file where should we look throw
        {
            Console.WriteLine("Usage: <pattern> <file1> [<file2> ...]");
            return;
        }
        
        List<string> files = new List<string>(args[1..]);

        string regexPattern = KeyWords.Check(args[0]);
        var tasks = new List<Task>();

        foreach (var file in files)
        {
            if (File.Exists(file))
            {
                FileSearcher searcher = new();
                tasks.Add(Task.Run(async () => await searcher.SearchFile(file, regexPattern)));

            }
            else
                Console.WriteLine($"File not found: {file}");
        }
        await Task.WhenAll(tasks);
    }    
}
