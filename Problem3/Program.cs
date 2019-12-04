using System;
using System.Linq;

namespace Problem3
{
// this problem was asked by Stripe.

// Given an array of integers, find the first missing positive integer in linear time and constant space. In other words, find the lowest positive integer that does not exist in the array. The array can contain duplicates and negative numbers as well.

// For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.

// You can modify the input array in-place.
    class Program
    {
        public static int[] process(int[] input)
        {
            input = input.Where(item => item >= 0).Distinct().ToArray();
            Array.Sort(input);
            return input;
        }
        public static int sln1(int[] input)
        {
            input = process(input);
            int n = input.Length;
            
            int missingValue = 0;
            for(int i = 1; i < n;i++)
            {
                int value = input[i-1] + 1;
                if(input[i] != value)
                {
                    missingValue = value;
                }
            }

            //check if missing value exists in input array
            if(Array.Exists(input,item => item.Equals(missingValue)) == true)
            {
                missingValue = input[n - 1] + 1;
            }
            return missingValue;
        }
        static void Main(string[] args)
        {
            int[] input = new int[] {3, 4, -1, 1};
            int missingValue = sln1(input);
            Console.WriteLine("missing value == " + missingValue);
        }
    }
}
