using System;

namespace BinaryTreeBFS
{

    class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }

    }

    class BinaryTree
    {
        public Node root;
        public BinaryTree()
        {
            root = null;
        }

        int maxDept(Node node)
        {
            if(node == null)
            {
                return 0;
            }

            int lHeight = maxDept(node.left);
            int rHeight = maxDept(node.right);
            if(lHeight > rHeight)
            {
                return lHeight + 1;
            }else
            {
                return rHeight + 1;
            }
        }

        void printTreeLevel(Node node,int level)
        {
            if(node == null)
            {
                return;
            }

            if(level == 1)
            {
                Console.Write(node.data + ",");
            }
            else if(level > 1)
            {
                printTreeLevel(node.left,level - 1);
                printTreeLevel(node.right,level - 1);
            }
        }

        public void  TraverseTree()
        {
            int height = maxDept(root);
            for(int i = 1 ; i<= height;i++)
            {
                printTreeLevel(root,i);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(4);
            tree.TraverseTree();
        }
    }
}
