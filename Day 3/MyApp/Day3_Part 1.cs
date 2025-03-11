using System;
using System.IO;
using System.Text.RegularExpressions;

public class CorruptedMemoryScanner
{
    public static int Extract(string input)
    {
        int totalSum = 0;
        string pattern = @"mul\((\d+),(\d+)\)"; // Regex to match valid mul(X,Y) patterns
        
        MatchCollection matches = Regex.Matches(input, pattern);
        
        foreach (Match match in matches)
        {
            int num1 = int.Parse(match.Groups[1].Value);
            int num2 = int.Parse(match.Groups[2].Value);
            totalSum += num1 * num2;
        }
        
        return totalSum;
    }

    public static void Main(string[] args)
    {
        int finalSum = 0;
        string file = "C:\\Users\\rezbe\\Downloads\\Avent of Code\\Day 3\\MyApp\\input.txt";
        
        foreach (var line in File.ReadLines(file))
        {
            finalSum += Extract(line);
        }
        
        Console.WriteLine(finalSum);
    }
}
