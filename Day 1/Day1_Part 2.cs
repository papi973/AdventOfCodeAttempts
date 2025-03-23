public class DistanceFinder2
{
    public static void getDistance(List<int> list1, List<int> list2)
    {

        // Calculate the similarity score between the corresponding element 
        // for the left list in the right list after counting
        var count = list1.Select(num1 => Math.Abs(list2.Count(c => c == num1))* num1);

        // Print the sum of array count equation
        Console.WriteLine(count.Sum());
    }

    public static void Main(string[] args)
    {
        // Initialize the lists for storing the numbers
        string file = "C:\\Users\\rezbe\\Downloads\\Day 1\\MyApp\\input.txt";

        // Reading the file line by line
        // Skip lines that don't have exactly two values
        // Parse the values and add them using tuple
        var data = File.ReadLines(file)
            .Select(line => line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            .Where(parts => parts.Length == 2)
            .Select(parts => (int.Parse(parts[0]), int.Parse(parts[1])));

        //Delare 2 seperate lists using Tuple
        var list1 = data.Select(n => n.Item1).ToList();
        var list2 = data.Select(n => n.Item2).ToList();

        // Convert the lists to arrays and call the getDistance method
        getDistance(list1, list2);
    }
}