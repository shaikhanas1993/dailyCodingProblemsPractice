using System;

namespace Problem2
{
// This problem was asked by Uber.

// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.

// For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].

// Follow-up: what if you can't use division?
    class Program
    {

        //Time Complexity of this sln is O(n)

        public  static void calculateProduct2(int[] input)
        {
            int n = input.Length;
            
            if(n == 1)
            {
                return;
            }

            int[] left = new int[n];
            int[] right = new int[n];
            int[] product = new int[n];


            left[0] = 1;
            right[n - 1] = 1;

            for (int i = 1; i < n; i++)
            {
                left[i] = input[i - 1] * left[i - 1];
            }

            for (int j = n - 2; j >= 0; j--)
            {
                right[j] = input[j + 1] * right[j + 1];
            }

            for (int i = 0; i < n; i++)
            {
                product[i] = left[i] * right[i];
            }


        }


          //Time Complexity of this sln is O(n^2)
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


        public  static void process(int[] input)
        {
            int n = input.Length;
            if(n == 1)
            {
                return ;
            }

            int[] product = new int[n];
            int[] left = new int[n];
            int[] right = new int[n];

            left[0] = 1;
            for(int i = 1; i < n; i++)
            {
                left[i] = input[i - 1] * left[i - 1];
            }

            right[n - 1] = 1;
            for(int j = n - 2 ; j >= 0; j--)
            {
                right[j] = input[j + 1] * right[j + 1];
            }

            for(int k = 0 ; k < n; k++)
            {
                product[k] = left[k] * right[k];
            }



        }

        public static void process2(int[] input)
        {
            int n = input.Length;
            int[] product = new int[n];
            for(int i = 0; i < n; i++ )
            {
                product[i] = 1;
            }


            int temp = 1;
            for(int i = 0; i< n ;i++)
            {
                product[i] = temp;
                temp = temp * input[i];
            }
            temp = 1;
            for(int i = n-1 ; i >= 0 ;i--)
            {
                product[i] =  product[i] * temp;
                temp = temp * input[i];
            }

            for(int i = 0 ;i < n;i++)
            {
                Console.WriteLine(product[i]);
            }
        }


        public static void novice(int[] input)
        {
            int n = input.Length;
            if(n == 1)
            {
                return;
            }

            int[] output = new int[n];

            for (int i = 0; i < n; i++)
            {
                int product = 1;
                for (int j = 0; j < n; j++)
                {
                    if(i != j)
                    {
                        product = product * input[j];
                    }
                }

                output[i] = product;
            }

            for(int j = 0; j < n; j++)
            {
                Console.WriteLine(output[j]);
            }
        }

        public static void divideAndconquerSln1(int[] input)
        {
            int n = input.Length;
            if(n == 1)
            {
                return;
            }

            int[] output = new int[n];
            int[] left = new int[n];
            int[] right = new int[n];

            left[0] = 1;
            for(int i = 1;i < n;i++)
            {
                left[i] = input[i - 1] * left[i - 1];
            }

            right[n - 1] = 1;
            for(int j = n - 2; j >= 0; j--)
            {
                right[j] = input[j + 1] * right[j + 1];
            }

            for(int i = 0; i < n; i++)
            {
                output[i] = left[i] * right[i];
            }

            printOutput(output);
            
        }

        public static void printOutput(int[] output)
        {
            for (int i = 0; i < output.Length; i++)
            {   
                Console.WriteLine(output[i]);
            }
        }

        
        static void Main(string[] args)
        {
            int[] arrayOfIntegers = new int[] {1,2,3,4,5};
            Program program = new Program();
            //novice(arrayOfIntegers);
            divideAndconquerSln1(arrayOfIntegers);
           // calculateProduct2(arrayOfIntegers);
          // process2(arrayOfIntegers);
        }
    }
}
