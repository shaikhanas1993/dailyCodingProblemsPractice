using System;
using System.Linq;

namespace Problem3R1
{
    // this problem was asked by Stripe.

    // Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.

    // For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.

    // You can modify the input array in-place.
    
    class Program
    {
        public static int findMissingNo(int []input)
        {
            if(input.Length == 0)
            {
                return 0;
            }
            
            input = input.Where(element => element > 0).Distinct().ToArray();
            
            int maxElement = input.Max();
            int[] Elements = new int[maxElement];
            for(int i = 0; i<input.Length;i++)
            {
                 Elements[input[i] -1]  = 1;    
            }

            

            for(int i = 0 ; i< Elements.Length;i++)
            {
                if(Elements[i]!=1)
                {
                    return i+1;
                }
            }

            return maxElement + 1;
        }

        public static int findMissingNoInPlace(int []input)
        {
            if(input.Length == 0)
            {
                return 0;
            }
            
            input = input.Where(element => element > 0).Distinct().ToArray();
            
            int n = input.Length;

            for(int i = 0; i < n;i++)
            {
                int index = Math.Abs(input[i]) - 1;
                Console.WriteLine("index ::" + index);
                if(index < n)
                {
                   
                    input[index] = -1;
                }
            }

            for(int i = 0; i < n; i++)
            {
                if(input[i] > 0)
                {
                    return i + 1;
                }
            }

            return 1;
        }

        static void Main(string[] args)
        {
            int[] input = new int[]{-1,-2,1,3,5};
            int missingNo = findMissingNoInPlace(input);
            Console.WriteLine("missingNo ::" + missingNo);
            //Console.WriteLine("Hello World!");
        }
    }
}
