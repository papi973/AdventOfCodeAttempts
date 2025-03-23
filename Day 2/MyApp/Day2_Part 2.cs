using System;
using System.Linq;
using System.IO;

public class RedNoseReactor
{
    static void Main()
    {
        // Read input file line by line
        string filePath = "C:\\Users\\rezbe\\Downloads\\Avent of Code\\Day 2\\MyApp\\input.txt";
         // Adjust file path accordingly
        int[][] lists = File.ReadLines(filePath)
            .Select(line => line.Split(' ').Select(int.Parse).ToArray()) // Convert each line into an integer array
            .ToArray();

        // Count the number of reports that can be safe with at most one removal
        Console.WriteLine(lists.Count(IsSafeWithDampener));
    }

    // Function to check if a report is safe
    static bool IsSafe(int[] list)
    {
        if (list.Length <= 1) return true; // A single-element report is always safe

        // Calculate the difference between consecutive elements
        int[] differences = list.Skip(1).Zip(list, (curr, prev) => curr - prev).ToArray();

        // A report is safe if it is either strictly increasing (differences between 1 and 3)
        // or strictly decreasing (differences between -3 and -1)
        bool isAscending = differences.All(d => d >= 1 && d <= 3);
        bool isDescending = differences.All(d => d <= -1 && d >= -3);

        return isAscending || isDescending;
    }

    // Function to check if a report can be safe after removing at most one level
    static bool IsSafeWithDampener(int[] list)
    {
        if (IsSafe(list)) return true; // If already safe, return true

        // Try removing each element one by one and check if the modified report is safe
        return Enumerable.Range(0, list.Length)
            .Any(i => IsSafe(list.Where((_, index) => index != i).ToArray()));
    }
}
