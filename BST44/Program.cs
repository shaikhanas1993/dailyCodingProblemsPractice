using System;
using System.Collections.Generic;
namespace BST44
{

    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
            left = null;
            right = null;
        }
    }

    static class Helper
    {
        public static TreeNode deleteNode(TreeNode root,int key)
        {
                if(root == null)
                {
                    return null;
                }

                if(root.val == key)
                {
                    if(root.left == null && root.right == null)
                    {
                        return root = null;
                    }

                    if(root.left != null && root.right == null)
                    {
                        return root = root.left;
                    }

                    if(root.left == null && root.right != null)
                    {
                        return root = root.right;
                    }

                    if(root.left != null && root.right != null)
                    {
                       //findInorder successor to the root;
                       int InorderSuccessor = findInOrderSuccessor(root.right);
                       root.val = InorderSuccessor;
                       root.right = deleteNode(root.right,root.val); 
                    }
                }

                if(root.val < key)
                {
                    root.left = deleteNode(root.left,key);
                }
                else
                {
                    root.right = deleteNode(root.right,key);
                }
                return root;
        }

        private static int findInOrderSuccessor(TreeNode root)
        {
            int val = root.val;
            while(root.left != null)
            {
                val = root.left.val;
                root = root.left;
            }
            return val;
        }

        public static TreeNode constructBst(TreeNode root,int val)
        {
            if(root == null)
            {
                return root = new TreeNode(val);
            }

            if(root.val < val)
            {
                root.left = constructBst(root.left,val);
            }
            else
            {
                root.right = constructBst(root.right,val);
            }
            return root;
        }

        public static IList<int> InOrderTraversal(TreeNode root)
        {
            IList<int> list = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode currentElement = root;
            while(currentElement != null || stack.Count > 0)
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
            IList<int> list = new List<int>();
            list.Add(13);
            list.Add(10);
            list.Add(25);
            list.Add(8);
            list.Add(12);
            list.Add(17);
            list.Add(27);
            list.Add(16);
            list.Add(20);
            list.Add(15);
            list.Add(18);
            list.Add(19);
            list.Add(22);
            TreeNode root = null;
            foreach (var item in list)
            {
                root = Helper.constructBst(root,item);
            }

            var traversalElements = Helper.InOrderTraversal(root);
            foreach (var item in traversalElements)
            {
                Console.Write(item + ",");
            }

            root = Helper.deleteNode(root,17);
            traversalElements = Helper.InOrderTraversal(root);
            Console.WriteLine();
            foreach (var item in traversalElements)
            {
                Console.Write(item + ",");
            }
        }
    }
}
