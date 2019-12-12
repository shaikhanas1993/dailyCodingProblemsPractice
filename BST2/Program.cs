using System;
using System.Collections.Generic;
using System.Linq;

//Inorder Traversal of bst produces a sorted array

namespace BST2
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

    static class BstHelper
    {
        public static TreeNode insertHelper(TreeNode root,int val)
        {
            if(root == null)
            {
                return root = new TreeNode(val);
            }

            if(val < root.val)
            {
                //traverse to leaf node
                //Insert at Left 
                root.left = insertHelper(root.left,val);
            }
            else
            {
                //travers to leaf node
                //Insert at right
                root.right = insertHelper(root.right,val);
            }
            return root;
        }

        public static IList<int> traverseHelper(TreeNode root)
        {
            IList<int> list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode currentElement = root;
            while(currentElement != null || stack.Count() > 0)
            {
                 while(currentElement != null)
                 {
                     stack.Push(currentElement);
                     currentElement = currentElement.left;
                 }

                 currentElement = stack.Pop();
                 list.Add(currentElement.val);
                 currentElement = currentElement.right;
            }
            return list;
        }
    }    

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = null;
            root = BstHelper.insertHelper(root,5);
            root = BstHelper.insertHelper(root,6);
            root = BstHelper.insertHelper(root,7);
            root = BstHelper.insertHelper(root,4);
            root = BstHelper.insertHelper(root,1);
            IList<int> list = BstHelper.traverseHelper(root);

        }
    }
}
