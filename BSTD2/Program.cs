using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTD2
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
        public static TreeNode constructBst(TreeNode root,int key)
        {
            if(root == null)
            {
                return root = new TreeNode(key);
            }

            if(key < root.val)
            {
                root.left = constructBst(root.left,key);
            }
            else
            {
                root.right = constructBst(root.right,key);
            }
            return root;
        }
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

                //find Inorder successor in the right subtree and replace root elemen with it and then delete Inorder Successor
                root.val = minValue(root.right);
                root.right = deleteNode(root.right,root.val);
            }

            if(key < root.val)
            {
                 root.left = deleteNode(root.left,key);
            }else
            {
                root.right = deleteNode(root.right,key);
            }
            return root;
        }

        public static int minValue(TreeNode node)
        {
            int minValue = node.val;
            while(node.left != null)
            {
                minValue = node.left.val;
                node = node.left;
            }
            return minValue;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node = null;
            IList<int> list = new List<int>();
            list.Add(50);
            list.Add(30);
            list.Add(20);
            list.Add(40);
            list.Add(70);
            list.Add(60);
            list.Add(80);
            foreach (var item in list)
            {
                node = Helper.constructBst(node,item);
            }
            node = Helper.deleteNode(node,50);
        }
    }
}
