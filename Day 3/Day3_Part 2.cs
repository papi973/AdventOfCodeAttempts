using System;
using System.IO;
using System.Text.RegularExpressions;

public class CorruptedMemoryScanner
{
    /
    public static int Extract(string input)
    {
        int totalSum = 0;
        bool isEnabled = true;  // Initially, mul instructions are enabled

        string multiplicationPattern = @"mul\((\d+),(\d+)\)";  
        string controlPattern = @"do\(\)|don't\(\)"; 

        
        MatchCollection controlMatches = Regex.Matches(input, controlPattern);
        foreach (Match control in controlMatches)
        {
            if (control.Value == "don't()")
                isEnabled = false;  
            else if (control.Value == "do()")
                isEnabled = true;   
        }


        // Process multiplication operations only if isEnabled is true
        if (isEnabled)
        {
            MatchCollection matches = Regex.Matches(input, multiplicationPattern);
            foreach (Match match in matches)
            {
                int num1 = int.Parse(match.Groups[1].Value);
                int num2 = int.Parse(match.Groups[2].Value);
                totalSum += num1 * num2;  // Calculate and add product to sum
            }
        }

        return totalSum;
    }

    public static void Main(string[] args)
    {
        int finalSum = 0;
        string filePath = "C:\\Users\\rezbe\\Downloads\\Avent of Code\\Day 3\\MyApp\\input.txt";

        // Read and process each line from the input file
        foreach (var line in File.ReadLines(filePath))
        {
            finalSum += Extract(line);
        }

        // Output the final computed sum
        Console.WriteLine(finalSum);
    }
}