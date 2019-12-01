using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{

// Good morning! Here's your coding interview problem for today.

// This problem was recently asked by Google.

// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.

// For example, given [10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.

// Bonus: Can you do this in one pass?


    class Program
    {
        private  readonly  int[] _arrayOfNumbers;
        private  readonly int _k;

        public Program(int[] arrayOfNumbers,int k)
        {
            _arrayOfNumbers = arrayOfNumbers;
            _k =  k;
        }

        /// <summary>
        /// A simple sln with minimum space complexity as we deal the same array as the original
        /// </summary>
        /// <returns></returns>
        public bool checkWhetherTwoNumbersAddUpToK()
        {
            Console.WriteLine(DateTime.Now.Millisecond);
           
           
            bool doesTwoNumberAddUpToK = false;
            for (int i = 0; i < _arrayOfNumbers.Length; i++)
            {
                for (int j = i+1; j < _arrayOfNumbers.Length; j++)
                {
                     if((_arrayOfNumbers[i] + _arrayOfNumbers[j]) == _k)
                     {
                         doesTwoNumberAddUpToK = true;
                         Console.WriteLine("i ==" + i);
                         Console.WriteLine("j ==" + j);
                         return doesTwoNumberAddUpToK;
                     }
                }
            }
            Console.WriteLine(DateTime.Now.Millisecond);
            return doesTwoNumberAddUpToK;
        }

        /// <summary>
        /// This sln increases space complexity as we create a hashset excluding the current item in each iteration plux it increases time complexity as we are iterating twice first while converting array to set and then iterating set iteself
        /// </summary>
        /// <returns></returns>
        public bool anotherSlnProblem()
        {
            Console.WriteLine(DateTime.Now.Millisecond);
            bool doesTwoNumberAddUpToK = false;
            try
            {
                var hashSet = new HashSet<int>(_arrayOfNumbers);
                foreach (var item in hashSet)
                {
                    var remaining = _k - item;
                    if(remaining > 0)
                    {
                        var elements =  hashSet.Where(ele => ele != item).ToHashSet();
                        doesTwoNumberAddUpToK =  elements.Contains(remaining);
                        if(doesTwoNumberAddUpToK == true)
                        {
                            return doesTwoNumberAddUpToK;
                        }
                    }
                    
                }

            }
            catch (System.Exception)
            {
                Console.WriteLine(DateTime.Now.Millisecond);
                throw;
            }
            Console.WriteLine(DateTime.Now.Millisecond);
            return doesTwoNumberAddUpToK;
        }

        public bool Sln2()
        {
           Console.WriteLine(DateTime.Now.Millisecond);
            bool result = false;
            var set = new HashSet<int>();
            Array.ForEach(_arrayOfNumbers,element => {
                var remaining = _k - element;
                if(set.Contains(remaining))
                {
                     result = true;
                }
                set.Add(element);
            });
            Console.WriteLine(DateTime.Now.Millisecond);
            return result;
        }

        static void Main(string[] args)
        {
            int[] arrayOfNumbers = new int[] {10,15,3,7};
            int k = 30;
            Program program = new Program(arrayOfNumbers,k);
            // bool result = program.checkWhetherTwoNumbersAddUpToK();
            // Console.WriteLine(result);
            try
            {
                bool result = program.anotherSlnProblem();
                Console.WriteLine(result);
            }
            catch (System.Exception e)
            {
                
                Console.WriteLine(e);
            }

            //  try
            // {
            //     bool result = program.Sln2();
            //     Console.WriteLine(result);
            // }
            // catch (System.Exception e)
            // {
                
            //     Console.WriteLine(e);
            // }
            
        }
    }
}
