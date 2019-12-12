using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTDEL
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

    class Helper
    {
        public static TreeNode constructBst(TreeNode root,int val)
        {
            if(root == null)
            {
                return root = new TreeNode(val);
            }

            if(val < root.val)
            {
                root.left = constructBst(root.left,val);
            }
            else
            {
                root.right = constructBst(root.right,val);
            }
            return root;
        } 

        public static IList<int> traverse(TreeNode root)
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
        public static TreeNode deleteNode(TreeNode root,int val)
        {
            if(root == null)
            {
                return null;
            }

            if(root.val == val)
            {
                if(root.left == null && root.right == null)
                {
                    return root = null;
                }
                else if(root.right == null && root.left != null)
                {
                    return root = root.left;
                }
                else
                {
                    IList<int> elements = traverse(root);
                    elements = elements.Where(item => item != root.val).ToList();
                    TreeNode newNode = null;
                    foreach (var item in elements)
                    {
                        newNode = constructBst(newNode,item);
                    }

                    return root = newNode;
                }
            }

            if(val < root.val)
            {
                 root.left =  deleteNode(root.left,val);
            }
            else
            {
                 root.right = deleteNode(root.right,val);
            }
            return root;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> input = new List<int>();
            input.Add(3);
            input.Add(2);
            input.Add(1);
             input.Add(6);
             input.Add(7);
            input.Add(4);
            input.Add(5);
            TreeNode node = null;
            foreach (var item in input)
            {
                node = Helper.constructBst(node,item);
            } 

            node = Helper.deleteNode(node,6);
        }
    }
}
