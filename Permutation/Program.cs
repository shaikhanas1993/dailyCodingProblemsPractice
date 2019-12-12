using System;
using System.Linq;
using System.Collections.Generic;
namespace Permutaion
{
    class Program
    {
        //will work with only 3 elements
        public static void print(string element,string[] list)
        {
           for(int i = 0;i < list.Length ;i++)
           {
               Console.WriteLine( element + list[0] + list[1]);
               //swap
               string temp = list[0];
               list[0] = list[1];
               list[1] = temp;
           } 
        }
        public static void process(string input)
        {
            var elements = input.Split(",");

            for(int i = 0; i< elements.Length;i++)
            {
                string[] excludingElements = elements.Where(item => item != elements[i]).ToArray();
                print(elements[i],excludingElements);    
            }
        }

        public static void process1(string[] input)
        {
            
        }
        static void Main(string[] args)
        {
            string input = "A,B,C,D";
            var elements = input.Split(",");
           
            process1(elements);
        }
    }
}
