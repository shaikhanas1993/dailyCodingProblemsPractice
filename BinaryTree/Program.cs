using System;

namespace BinaryTree
{

    public class Node
    {
        public int data;
        public Node left,right;
        public Node(int item)
        {
            this.data = item;
            left = right = null;
        }
    }

    public class BinTree
    {
        public Node node;
        public BinTree()
        {
            node = null;
        }

        public BinTree(int key) 
        { 
            node = new Node(key); 
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
           BinTree tree = new BinTree();
           tree.node = new Node(1);
           tree.node.left = new Node(2);
           tree.node.right = new Node(3);
           tree.node.left.left = new Node(4);
        }
    }
}
