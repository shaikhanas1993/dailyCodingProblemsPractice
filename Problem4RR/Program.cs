using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4RR
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

        public String Serialize(TreeNode node)
        {
            if(node == null)
            {
                return NULL_SYMBOL + DELIMITER;
            }

            String leftSerializableString =  Serialize(node.left);
            String rightSerializableString = Serialize(node.right);
            return node.data + DELIMITER + leftSerializableString + rightSerializableString; 
        }

        TreeNode DeserializeHelper(Queue<string> queue)
        {
            string value = queue.Dequeue();
            if(value.Equals("X"))
            {
                return null;
            }

            TreeNode node = new TreeNode(Int32.Parse(value));
            node.left = DeserializeHelper(queue);
            node.right = DeserializeHelper(queue);
            return node;
        }
        public TreeNode Deserialize(String input)
        {
            var elements = input.Split(DELIMITER);
            Queue<string> nodesLeftToMaterialize = new Queue<string>();
            for(int i = 0; i < elements.Length;i++)
            {
                nodesLeftToMaterialize.Enqueue(elements[i]);
            }

            return DeserializeHelper(nodesLeftToMaterialize);
        }


    }

    class BfsHelper
    {
        public static readonly string DELIMITER = ",";
        public static readonly string NULL_SYMBOL = "X";

        public int getHeight(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            int leftPath = 0;
            int rightPath = 0;

            if(root.left != null)
            {
                leftPath = 1 + getHeight(root.left);
            }

            if(root.right != null)
            {
                rightPath = 1 + getHeight(root.right);
            }

            return leftPath > rightPath ? leftPath : rightPath;
        }

        
    }


    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node = new TreeNode(1);
            node.left = new TreeNode(2);
            node.right = new TreeNode(3);
            node.left.left = new TreeNode(4);
            node.left.right = new TreeNode(5);
            Helper helper = new Helper();
            String result = helper.Serialize(node);
            Console.WriteLine(result);
            var node1 = helper.Deserialize(result);
        }
    }
}
