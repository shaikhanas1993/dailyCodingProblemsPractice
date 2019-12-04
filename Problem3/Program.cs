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
            input = input.Where(item => item > 0).Distinct().ToArray();
            Array.Sort(input);
            return input;
        }
        public static int sln1(int[] input)
        {
            input = process(input);
            int n = input.Length;
            

            //Since 1 is the lowest positive value check if it exists
            int missingValue = 1;
            //check if 1 exists in Array
            if(Array.Exists(input,item => item.Equals(missingValue)) == false)
            {
                return missingValue;
            }

            bool foundMissingValue = false;

            for(int i = 1; i < n;i++)
            {
                int value = input[i-1] + 1;
                if(input[i] != value)
                {
                    missingValue = value;
                    foundMissingValue = true;
                    break;
                }
            }

            if(foundMissingValue == true)
            {
                return missingValue;
            }
            else
            {
               return missingValue = input[n - 1] + 1;
            }

            // Console.WriteLine(missingValue);

            // //check if missing value exists in input array
            // if(Array.Exists(input,item => item.Equals(missingValue)) == true)
            // {
            //     missingValue = input[n - 1] + 1;
            // }
            // return missingValue;
        }


// and return count of such numbers 
	static int segregate(int[] arr, int size) 
	{ 
		int j = 0, i; 
		for (i = 0; i < size; i++) { 
			if (arr[i] <= 0) { 
				int temp; 
				temp = arr[i]; 
				arr[i] = arr[j]; 
				arr[j] = temp; 

				// increment count of non-positive 
				// integers 
				j++; 
			} 
		} 

		return j; 
	} 

	// Find the smallest positive missing 
	// number in an array that contains 
	// all positive integers 
	static int findMissingPositive(int[] arr, int size) 
	{ 
		int i; 

		// Mark arr[i] as visited by making 
		// arr[arr[i] - 1] negative. Note that 
		// 1 is subtracted as index start from 
		// 0 and positive numbers start from 1 
		for (i = 0; i < size; i++) { 
			if (Math.Abs(arr[i]) - 1 < size && arr[ Math.Abs(arr[i]) - 1] > 0) 
				arr[ Math.Abs(arr[i]) - 1] = -arr[ Math.Abs(arr[i]) - 1]; 
		} 

		// Return the first index value at 
		// which is positive 
		for (i = 0; i < size; i++) 
			if (arr[i] > 0) 
				return i + 1; 

		// 1 is added becuase indexes 
		// start from 0 
		return size + 1; 
	} 

       // Find the smallest positive 
	// missing number in array that 
	// contains both positive and 
	// negative integers 
	static int findMissing(int[] arr, int size) 
	{ 

		// First separate positive and 
		// negative numbers 
		int shift = segregate(arr, size); 
		int[] arr2 = new int[size - shift]; 
		int j = 0; 

		for (int i = shift; i < size; i++) { 
			arr2[j] = arr[i]; 
			j++; 
		} 

		// Shift the array and call 
		// findMissingPositive for 
		// positive part 
		return findMissingPositive(arr2, j); 
	} 
        static void Main(string[] args)
        {
           //int[] input = new int[] {3, 4, -1, 1};
         //  int[] input = new int[] {3, 4, -1, 2};
        //  int[] input = new int[] {1, 1, 0, -1, -2};
        //     //int missingValue = sln1(input);
        //     int missingValue = sln2(input);
        //     Console.WriteLine("missing value == " + missingValue);
        int[] arr = { 2,4,3,6}; 
		int arr_size = arr.Length; 
		int missing = findMissing(arr, arr_size); 
		Console.WriteLine("The smallest positive missing number is " + missing); 
        }
    }
}
