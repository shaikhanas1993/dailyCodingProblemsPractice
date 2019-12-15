using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTSWAP1
{
    class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    class Helper
    {
        TreeNode firstStartingPoint;
        TreeNode lastStartingPoint;
        TreeNode prev;

        public void findSegments(TreeNode root)
        {
            if(root == null)
            {
                return;
            }

            findSegments(root.left);
            if(prev != null)
            {
                if(prev.data > root.data)
                {
                    if(firstStartingPoint == null)
                    {
                        firstStartingPoint = prev;
                    }
                    lastStartingPoint = root;
                }
            }
            prev = root;
            findSegments(root.right);
        }

        public void recoverTree(TreeNode root)
        {
            findSegments(root);
            int x = firstStartingPoint.data;
            firstStartingPoint.data = lastStartingPoint.data;
            lastStartingPoint.data = x;
        }

        public static IList<int> InOrderTraversal(TreeNode root)
        {
            
            IList<int> list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode curr = root;
            while(curr != null || stack.Count() > 0)
            {
                while(curr != null)
                {
                    stack.Push(curr);
                    curr = curr.left;
                }

                curr = stack.Pop();
                list.Add(curr.data);
                curr = curr.right;
            }
            return list;
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10);
            TreeNode n1   = new TreeNode(15);
            TreeNode n2   = new TreeNode(5);
            TreeNode n3   = new TreeNode(4);
            TreeNode n4   = new TreeNode(7);
            TreeNode n5   = new TreeNode(14);
            TreeNode n6   = new TreeNode(17);
                
            root.left  = n1;
            root.right = n2;
                
            n1.left  = n3;
            n1.right = n4;
                
            n2.left  = n5;
            n2.right = n6;

            IList<int> elements = Helper.InOrderTraversal(root);
            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------");
            Helper helper = new Helper();
            helper.recoverTree(root);
            elements = Helper.InOrderTraversal(root);
            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }


        }
    }
}
