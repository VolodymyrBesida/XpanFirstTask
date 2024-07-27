using System.Text.RegularExpressions;
namespace SerilogReaderApp.Models;
public class FileSearcher
{
    public FileSearcher()
    {

    }
    public async Task SearchFile(string filePath, string regexPattern)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            Regex regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (regex.IsMatch(line))
                {
                    Console.WriteLine($"File: {filePath}");
                    Console.WriteLine($"Match: {line}");
                }
            }
        }
    }
}