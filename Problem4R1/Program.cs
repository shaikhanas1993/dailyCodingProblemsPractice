using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem4R1
{
    class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }

    class Helper
    {
        public static readonly string NULL_SYMBOL = "X";
        public static readonly string DELIMITER = ",";

        public String SerializeFunc(TreeNode root)
        {
            if(root == null)
            {
                return NULL_SYMBOL + DELIMITER;
            }

            String leftSerializeString = SerializeFunc(root.left);
            String rightSerializeString = SerializeFunc(root.right);

            return root.value + DELIMITER + leftSerializeString + rightSerializeString;
        }

        public TreeNode insertHelper(Queue<String> queue)
        {
            string value = queue.Dequeue();
            if(value.Equals("X"))
            {
                return null;
            }

            TreeNode node = new TreeNode(Int32.Parse(value));
            node.left = insertHelper(queue);
            node.right = insertHelper(queue);
            return node;
        }
        public TreeNode DeserializeFunc(String input)
        {
            if(input.Length == 0)
            {
                return null;
            }

            Queue<String> nodesLeftToMaterialize = new Queue<string>();
            var elements = input.Split(DELIMITER);

            for(int i = 0 ;i<elements.Length;i++)
            {
                nodesLeftToMaterialize.Enqueue(elements[i]);
            }

            return insertHelper(nodesLeftToMaterialize);
        }

        public void printPreOrder(TreeNode root)
        {
            if(root == null)
            {
                Console.WriteLine("X");
                return ;
            }

            Console.WriteLine(root.value);
            printPreOrder(root.left);
            printPreOrder(root.right);
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root  = new TreeNode(1);
            root.left  = new TreeNode(2);
            root.left.right  = new TreeNode(2);

            Helper helper = new Helper();
            String result = helper.SerializeFunc(root);
            Console.WriteLine(result);
            var node = helper.DeserializeFunc(result);
            helper.printPreOrder(node);

        }
    }
}
