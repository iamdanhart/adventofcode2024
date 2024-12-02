// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

string puzzleInput = ReadFile("input.txt");
if (string.IsNullOrEmpty(puzzleInput))
{
    Console.WriteLine("No puzzle input found");
    Environment.Exit(1);
}
Console.WriteLine(
    Part1(
        puzzleInput));

return 0;

int Part1(String input)
{
    string[] lines = input.Split('\n');
    List<String> left = new();
    List<String> right = new();
    
    
    foreach (string line in lines)
    {
        if (line.Length == 0)
        {
            continue;
        }
        var match = Regex.Match(
            line, 
            @"(\d+)\s*(\d+)");
        left.Add(match.Groups[1].Value);
        right.Add(match.Groups[2].Value);
    }
    
    left.Sort();
    right.Sort();
    
    int totalDistance = 0;
    for (int i = 0; i < left.Count; i++)
    {
        int i1 = Int32.Parse(left[i]);
        int i2 = Int32.Parse(right[i]);
        totalDistance += Math.Abs(i2 - i1);
    }

    return totalDistance;
}

string ReadFile(string name)
{
    try
    {
        // Open the text file using a stream reader.
        using StreamReader reader = new(name);

        // Read the stream as a string.
        string text = reader.ReadToEnd();

        return text;
    }
    catch (IOException e)
    {
        return "";
    }
}