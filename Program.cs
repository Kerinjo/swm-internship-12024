namespace coding_task;



class Program
{
    static bool IsPrime(int n)
    {
        return false;   
    }

    // A function that receives two sequences: A and B of integers
    // Do I want to modify this collection?
    
    // return one sequence C
    // Sequence C contains all elements from sequence A (maintaining order)
    // except those, that are present in sequence B p times.
    // p - prime number

    // Ex:
    // A = [2, 3, 9, 2, 5, 1, 3, 7, 10] -> not ordered
    // B = [2, 1, 3, 4, 3, 10, 6, 6, 1, 7, 10, 10, 10] -> not ordered

    // C = [2, 9, 2, 5, 7, 10]
    // additional space complexity
    // another sequence not_in_C, to store what's already checked.
    // not_in_C = [3, 1]
    // go through A list once
    // element from list A, that is not in list B or just once in list B,
    // it goes straight to C.
    // is the element from A already in C? if so, no need to check again

    static List<int> Solution (IEnumerable<int> A, IEnumerable<int> B)
    {
        List<int> C = new List<int>();
        List<int> not_in_C = new List<int>();

        // we can have a hash table!!
        // new task:

        // find hash table of occurences of items in list B.
        var occurencesDictionary = B.GroupBy(i => i)
            .ToDictionary(g => g.Key, g => g.Count());
        
        System.Console.WriteLine("Occurences in B:");
        System.Console.WriteLine("Item : Count");
        foreach (var kvp in occurencesDictionary)
        {  
            System.Console.WriteLine($"{kvp.Key}\t: {kvp.Value}");
        }
        // foreach (int item in A)
        // {
        //     System.Console.Write($"{item}, ");
        // }

        System.Console.WriteLine();
        foreach (int item in A)
        {
            if (!occurencesDictionary.ContainsKey(item))
                C.Add(item);
            else
                if (occurencesDictionary[item] == 1)
                    C.Add(item);
                else
                    System.Console.WriteLine($"{item}: Primality test required.");
                    //check parity and decide
        }

        return C;
    }

    static void Main(string[] args)
    {      
        IEnumerable<int> A = new List<int> { 2, 3, 9, 2, 5, 1, 3, 7, 10 };
        IEnumerable<int> B = new List<int> { 2, 1, 3, 4, 3, 10, 6, 6, 1, 7, 10, 10, 10 };
        IEnumerable<int> result = Solution(A, B);


        System.Console.Write("[ ");
        foreach (int item in result)
        {
            System.Console.Write($"{item}, ");
        }
        System.Console.WriteLine("]");

    }
}
