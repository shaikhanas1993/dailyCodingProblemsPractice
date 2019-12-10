using System;
using System.Linq;
using System.Collections.Generic;

//Serialize and deserialize a binary tree

namespace Problem4R
{

    class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int data)
        {
            this.data = data;
        }
    }



    class Helper
    {
        public static readonly string NULL_SYMBOL = "X";
        public static readonly string DELIMITER = ",";

        //doing preorder traversal
        public String SerializeFunc(TreeNode root)
        {
            if(root == null)
            {
                return NULL_SYMBOL + DELIMITER;
            }

            String leftSerializedString = SerializeFunc(root.left);
            String rightSerializedString = SerializeFunc(root.right);
            return root.data + DELIMITER + leftSerializedString + rightSerializedString;
        }

        TreeNode insertHelper(Queue<string> nodesLeftToMaterialize)
        {
            String value = nodesLeftToMaterialize.Dequeue();
            if(value.Equals(NULL_SYMBOL))
            {
                return null;
            }

            TreeNode node = new TreeNode(Int32.Parse(value));
            node.left = insertHelper(nodesLeftToMaterialize);
            node.right = insertHelper(nodesLeftToMaterialize);
            return node;
        }
        public TreeNode DeserializeFunc(String input)
        {
            Queue<string> nodesLeftToMaterialize = new Queue<string>();
            var elements = input.Split(DELIMITER);
            for(int i = 0 ; i < elements.Length;i++)
            {
                nodesLeftToMaterialize.Enqueue(elements[i]);
            }

            return insertHelper(nodesLeftToMaterialize);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.right = new TreeNode(6);
            Helper helper = new Helper();
            String result = helper.SerializeFunc(root);
            var node = helper.DeserializeFunc(result);
        }
    }
}
