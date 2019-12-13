using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTSwap
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
        public static TreeNode constructBst(TreeNode root,int val)
        {
            if(root == null)
            {
                root = new TreeNode(val);
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

        public static TreeNode swapNode(TreeNode root,int leftTreeNode,int rightTreeNode)
        {
            if(root == null)
            {
                return null;
            }

            if(root.val == leftTreeNode)
            {
                 root.val = rightTreeNode;
                 return root; 
            }

            if(root.val == rightTreeNode)
            {
                root.val = leftTreeNode; 
                return root;
            }

            root.left = swapNode(root.left,leftTreeNode,rightTreeNode);
            root.right = swapNode(root.right,leftTreeNode,rightTreeNode);
            return root;
        }

        public static IList<int> getInorderTraversal(TreeNode root)
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
            TreeNode node= new TreeNode(10);
            node.left = new TreeNode(5);
            node.right = new TreeNode(8);
            node.left.left = new TreeNode(2);
            node.left.right = new TreeNode(20);
            IList<int> list = Helper.getInorderTraversal(node);
            IList<int> incorrectNodes = new List<int>();
            int n =  list.Count();
            //only see 2 nodes 
            for(int i = 0 ; i< n ; i++)
            {   
                    if(i == 0)
                    {
                        if(list.ElementAt(i) > list.ElementAt(i + 1))
                        {
                            incorrectNodes.Add(list.ElementAt(i));
                        }
                    }

                    if(i > 0 && i < n-2)
                    {
                        int j = i - 0;
                        int k = i + 1;
                        if(list.ElementAt(i) < list.ElementAt(j) || list.ElementAt(i) >   list.ElementAt(k) )
                        {
                            incorrectNodes.Add(list.ElementAt(i));
                        }
                        
                    }

                    if(i == n-1)
                    {
                        if(list.ElementAt(i) < list.ElementAt(i - 1))
                        {
                            incorrectNodes.Add(list.ElementAt(i));
                        }
                    }
            }     

            int leftSubtreeNode = incorrectNodes.OrderBy(item => item).FirstOrDefault();
            int rightSubtreeNode = incorrectNodes.OrderByDescending(item => item).FirstOrDefault();
            var newNode = Helper.swapNode(node,leftSubtreeNode,rightSubtreeNode);
        }
    }
}
