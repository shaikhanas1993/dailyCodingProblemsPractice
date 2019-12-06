using System;

namespace BinaryTreeTraversal
{

    class Node
    {
        public int data;
        public Node left,right;
        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    class BinaryTree
    {
        public Node node;
        public BinaryTree()
        {
            this.node = null;
        }

        public void printInInorder(Node localNode)
        {
            if(localNode == null)
            {
                return;
            }

            printInInorder(localNode.left);
            Console.Write(localNode.data + ",");
            printInInorder(localNode.right);
        } 

        public void printPreorder(Node root)
        {
            if(root == null)
            {
                return;
            }
            Console.Write(root.data + ",");
            printPreorder(root.left);
            printPreorder(root.right);
        }     

        public void postOrder(Node root)
        {
            if(root == null)
            {
                return;
            }
            postOrder(root.left);
            postOrder(root.right);
            Console.Write(root.data + ",");
        } 
    }


    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.node = new Node(25);
            tree.node.left = new Node(15);
            tree.node.right = new Node(50);
            tree.node.left.left = new Node(10);
            tree.node.left.right = new Node(12);
            tree.node.left.left.left = new Node(4);
            tree.node.left.left.right = new Node(12);
            tree.node.left.right.left = new Node(18);
            tree.node.left.right.right = new Node(24);
            tree.node.right.left = new Node(35);
            tree.node.right.right = new Node(70);
            tree.node.right.left.left = new Node(31);
            tree.node.right.left.right = new Node(44);
            tree.node.right.right.left = new Node(60);
            tree.node.right.right.right = new Node(90);
            tree.postOrder(tree.node);
           // tree.printInInorder(tree.node);
            //tree.printPreorder(tree.node);
        }
    }
}
