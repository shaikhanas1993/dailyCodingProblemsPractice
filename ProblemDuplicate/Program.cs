using System;
using System.Linq;
using System.Collections.Generic;

namespace ProblemDuplication
{
    class Program
    {
        public static int[] findDuplicates(int[] input)
        {
            int n = input.Length;
            List<int> list = new List<int>();
            if (n == 0)
            {
                return new int[0];
            }

            Array.Sort(input);
            int i = 0;

            while (i < n)
            {
                int counterToAdd = 0;
                for (int j = i + 1; j < n; j++)
                {
                    if (input[i] == input[j])
                    {
                        counterToAdd = counterToAdd + 1;
                    }
                }
                if (counterToAdd > 0)
                {
                    list.Add(input[i]);
                    i = i + counterToAdd;
                }
                else
                {
                    i = i + 1;
                }
            }

            return list.ToArray();

        }

        public static void printArray(int[] output)
        {
            for (int i = 0; i < output.Length; i++)
            {
                Console.WriteLine(output[i]);
            }
        }

        public static int[] segregate(int[] input)
        {
            int n = input.Length;
            for(int i = 0;i < n;i++)
            {
                for(int j = i + 1 ; j< n; j++)
                {
                    if(input[j] < 0)
                    {
                        int temp = input[i];
                        input[i] = input[j];
                        input[j] = temp; 
                    }
                }
            }
            return input;
        }

        
        static void Main(string[] args)
        {
            int[] input = { 1, 2, 3, 4, 5, -1, 1, -1, 2 };
          //  int[] output = findDuplicates(input);
            int[] output = segregate(input);
            printArray(output);
        }
    }
}
