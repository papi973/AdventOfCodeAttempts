public class DistanceFinder
{
    public static void getDistance(List<int> list1, List<int> list2)
    {
        // Sort both lists
        list1.Sort();
        list2.Sort();

        // Calculate the absolute differences between the paired elements (paired with Zip())
        int sum = list1.Zip(list2, (a,b) => Math.Abs(a - b)).Sum();

        // Print the sum of absolute differences
        Console.WriteLine(sum);
    }

    public static void Main(string[] args)
    {
        //Declare path where input is
        string file = "C:\\Users\\Papiso93503\\Documents\\PythonFiles\\Test\\input.txt";


        //Reading the file line by line and spliting it
        //Shecking if lines have exacly 2 values
        //Selecting each line and converting it to int with tuple
        var data = File.ReadLines(file)
            .Select(line => line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            .Where(parts => parts.Length == 2)
            .Select(parts => (int.Parse(parts[0]), int.Parse(parts[1])));

        //Seperating tuple into 2 initialised lists
        var list1 = data.Select(n => n.Item1).ToList();
        var list2 = data.Select(n => n.Item2).ToList();


        // Call the getDistance method
        getDistance(list1, list2);

    }
}
