namespace coding_task;



class Program
{
    static bool[] Sieve(int size)
    {
        bool[] switches = Enumerable.Repeat(true, size+1).ToArray();
        // index corresponds to element
        // true -> index is prime
        switches[0] = false;
        switches[1] = false;
        for (int i = 2; (i * i) < switches.Length; i++)
            if (switches[i] == true)
                for (int j = 2*i; j < switches.Length; j += i)
                    switches[j] = false;

        return switches;
    }

    static List<int> Solution (List<int> A, List<int> B)
        {
            List<int> C = [];

            // find dictionary describing occurences of items in list B.
            var occurencesDictionary = B.GroupBy(i => i)
                .ToDictionary(g => g.Key, g => g.Count());
            
            // printing resulting dictionary to the console
            System.Console.WriteLine("Occurences in B:");
            System.Console.WriteLine("Item : Count");
            foreach (var kvp in occurencesDictionary)
            {  
                System.Console.WriteLine($"{kvp.Key}\t: {kvp.Value}");
            }
            System.Console.WriteLine();

            // Sieve 
            // size -> B.Count
            bool[] primes = Sieve(B.Count);

            foreach (int item in A)
            {
                if (!occurencesDictionary.TryGetValue(item, out int value))
                    C.Add(item);
                else
                    if (!primes[value])
                        C.Add(item);
            }
            return C;
        }

        static void Main(string[] args)
        {      
            List<int> A = [2, 3, 9, 2, 5, 1, 3, 7, 10];
            List<int> B = [2, 1, 3, 4, 3, 10, 6, 6, 1, 7, 10, 10, 10];
            // result -> C = [2, 9, 2, 5, 7, 10]
            
            List<int> result = Solution(A, B);

            // printing resulting sequence in the console
            System.Console.Write("[");
            System.Console.Write(string.Join(", ", result));
            System.Console.WriteLine("]");
        }
    }
