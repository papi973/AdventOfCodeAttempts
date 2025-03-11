﻿using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class DistanceFinder
{
    public static void getDistance(int[] list1, int[] list2)
    {
        int n = list1.Length;
        int[] sumList = new int[n];

        // Sort both lists
        Array.Sort(list1);
        Array.Sort(list2);

        // Calculate the absolute differences between the corresponding elements
        for (int i = 0; i < n; i++) {
            sumList[i] = Math.Abs(list1[i] - list2[i]);
        }

        // Print the sum of absolute differences
        Console.WriteLine(sumList.Sum());
    }

    public static void Main(string[] args)
    {
        // Initialize the lists for storing the numbers
        List<int> list1 = new List<int>();
        List<int> list2 = new List<int>();

        // Reading the file line by line
        foreach (var line in File.ReadLines("C:\\Users\\rezbe\\Downloads\\Day 1\\MyApp\\input.txt"))
        {
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Skip lines that don't have exactly two values
            if (parts.Length != 2)
                continue;

            // Parse the values and add them to the respective lists
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }

        // Convert the lists to arrays and call the getDistance method
        getDistance(list1.ToArray(), list2.ToArray());
    }
}