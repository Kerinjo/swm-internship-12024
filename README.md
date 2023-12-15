I used Sieve of Eratosthenes algorithm to find the prime numbers.

b is size of sequence B.
a is size of sequence A.

The part with Sieve algorithm has complexity O(bloglogb) 
Making dictionary out of element occurences in B is O(b), since GroupBy() as well as ToDictionary() are O(n).
Finally, going through each element of A to check if it belongs in C is O(a).

Combining these, the overall complexity is dominated by the Sieve algorithm, making it:
 O(b\*loglogb),
or if sequence A is significantly larger than B:
 O(b\*loglogb) + O(a). 


Written in C#