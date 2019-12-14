using System;
using System.Collections.Generic;
using System.Linq;

namespace MorrisTraversal
{

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val)
        {
            this.val = val;
        }
    }

    class Solution
    {
        public static IList<int> sln(TreeNode root)
        {
            IList<int> list = new List<int>();
            TreeNode current = root;
            TreeNode prev;
            while(current != null)
            {
                if(current.left == null)
                {
                    list.Add(current.val);
                    current = current.right;
                }
                else
                {
                    prev = current.left;
                    while(prev.right != null)
                    {
                        prev = prev.right;
                    }

                    prev.right = current;
                    TreeNode temp = current;
                    current = current.left;
                    temp.left = null;
                }
            }
            return list;
        }
    }
    class Program
    {
        public class Dog
        {
            public int a = 10;
        }
        static void Main(string[] args)
        {   
            Dog dog1 = new Dog();
            Dog dog2 = dog1;
            dog2.a = 20;
            dog2 = null;
            Console.WriteLine(dog2.a); 
        }
    }
}
