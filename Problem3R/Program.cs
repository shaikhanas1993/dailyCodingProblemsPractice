using System;
using System.Linq;

namespace Problem3R
{
    class Program
    {


        static void Main(string[] args)
        {
            // int[] input = {2,1,4};
            // int inputLength = input.Length;
            // int missingNo = 0;
            // bool  foundMissingNo = false;
            
            // for(int i = 0; i < inputLength;i++)
            // {
            //     int value = Math.Abs(input[i])-1;
            //     if( (value) < inputLength && input[value] > 0)
            //     {
            //         input[value] = -input[value]; 
            //     }
            // }

            // for(int i = 0; i< inputLength;i++)
            // {
            //     if(input[i] > 0)
            //     {
            //         missingNo =  i + 1;
            //         foundMissingNo = true;
            //         break;
            //     }
            // }

            // if(foundMissingNo == false)
            // {
            //     missingNo = inputLength + 1;
            // }

            // Console.WriteLine(missingNo);

            int missingNo = 0;
            bool foundMissingNo = false;
            int[] input = new int[] {100,2};
            int max = input.Max();    
            int[] newArr = new int[max];
            for(int i = 0;i < input.Length;i++)
            {
                newArr[input[i] - 1] = 1;
            }

            for(int i = 0; i<newArr.Length;i++)
            {
                if(newArr[i] != 1)
                {
                       missingNo = i + 1;
                       foundMissingNo = true; 
                       break;
                }
            }

            if(!foundMissingNo)
            {
                missingNo = newArr.Length + 1;
            }

            Console.WriteLine(missingNo);

        }
    }
}
