using System;

namespace Problem2
{
// This problem was asked by Uber.

// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.

// For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].

// Follow-up: what if you can't use division?
    class Program
    {
        public void calculateProduct(int[] input)
        {
            int[] output = new int[input.Length];
            for(int i = 0;i < output.Length;i++)  // O(n)
            {
                int sum = 1;
                for(int j = 0 ; j < output.Length ;j++) //O(n)
                {
                        
                        if(i != j)
                        {
                           sum = sum * input[j]; 
                        }
                }

                output[i] = sum;
            }


            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
        static void Main(string[] args)
        {
            int[] arrayOfIntegers = new int[] {3,2,0};
            Program program = new Program();
            program.calculateProduct(arrayOfIntegers);
        }
    }
}
