using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class RedNoseReactorWithProblemDampener
{
    public static bool getSafe(int[] list1)
    {
        int n = list1.Length;
        int sumOfDifference = 0;
        bool countSafe = false;
        int posCount = 0;
        int negCount = 0;
        int counting = 0;
        string[] condition = new string[n];


        // Calculate the absolute differences between the previous and next elements 
        // and storr them in list as safe or not
        for (int i = 0; i < n - 1; i++) {
            sumOfDifference = list1[i] - list1[i + 1];

            if(sumOfDifference > 0){
                posCount++;
            }else if(sumOfDifference < 0){
               negCount++;
            }

            if(Math.Abs(sumOfDifference) >= 1  && Math.Abs(sumOfDifference) <= 3)
            {
                condition[i] = "Safe";
            }
            else
            {
                condition[i] = "unSafe";
                countSafe = false;

            }
        }

        //Checks if there is not any unsafe condition and 
        //checks if all differences calculated are either all positive or all negative except for 1
        //if (!condition.Contains("unSafe") && (posCount == 0 || negCount == 0)){
            countSafe = true;
        //}

        //return no. of safe lines
        return posCount == 0 || negCount == 0;
    }

    public static int GetSafeCount(int[] list1)
    {
        if (getSafe(list1)) return 1; // Already safe

        // Try removing each level one by one and check if it becomes safe
        for (int i = 0; i < list1.Length; i++)
        {
            List<int> modifiedList = list1.ToList();
            modifiedList.RemoveAt(i);

            if (getSafe(modifiedList.ToArray()))
                return 1; // Becomes safe after removing one level
        }

        return 0; // Still unsafe
    }

    public static void Main(string[] args)
    {
        // Initialize the variables
        int[] numbers = new int[0];
        int FinalCount = 0;
  
        // Reading the file line by line
        foreach (var line in File.ReadLines("C:\\Users\\rezbe\\Downloads\\Avent of Code\\Day 2\\MyApp\\input.txt"))
        {
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // convert each line into array and add them to array 
            numbers = parts.Select(int.Parse).ToArray();

            //call the getDistance method and add result to final count. 
            FinalCount += GetSafeCount(numbers);
        }

        // Print the final count
        Console.WriteLine(FinalCount);
    }
}