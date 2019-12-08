using System;

namespace BinaryTreeR1
{

    class Node<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;

        public Node(T data)
        {
            this.data = data;
            left  = null;
            right = null;
        }
    }


    class BinaryTree<T>
    {
        public Node<T> root;
        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(Node<T> root)
        {
            this.root = root;
        }
    }

    static class BinaryTreeHelperMethods<T>
    {
        public static void printInOrder(Node<T> node)
        {
            if(node == null)
            {
                return;
            }

            printInOrder(node.left);
            Console.WriteLine(node.data + ",");
            printInOrder(node.right);    
            
        }

        public static void printPostOrder(Node<T> node)
        {
            if(node == null)
            {
                return;
            }
            printPostOrder(node.left);
            printPostOrder(node.right);
            Console.WriteLine(node.data + ",");
        }

        public static void printPreOrder(Node<T> node)
        {
            if(node == null)
            {
                return;
            }

            Console.WriteLine(node.data + ",");
            printPreOrder(node.left);
            printPreOrder(node.right);
        }

        public static int getTreeHeight(Node<T> root)
        {
            if(root == null)
            {
                return 0;
            }

            int leftPath = 0;
            int rightPath = 0;
            
            if(root.left != null)
            {
                leftPath = 1 + getTreeHeight(root.left);
            }

            if(root.right != null)
            {
                rightPath = 1 + getTreeHeight(root.right);
            }

            return leftPath > rightPath ? leftPath : rightPath;
        }

        public static void print(Node<T> node,int level)
        {
            if(node == null)
            {
                return;
            }

            if(level == 0)
            {
                Console.WriteLine(node.data + ",");
            }
            else if(level > 0)
            {
                print(node.left,level - 1);
                print(node.right,level - 1);
            }
        }

        public static void levelOrderPrinting(Node<T> root,int height)
        {
            if(root == null)
            {
                return;
            }

            for(int i = 1; i <= height + 1;i++)
            {
                int level = i - 1;
                print(root,level);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree<int>();
            tree.root = new Node<int>(1);
            tree.root.left = new Node<int>(2);
            tree.root.right = new Node<int>(3);
            tree.root.right.right = new Node<int>(4);
            tree.root.right.right.left = new Node<int>(5);
            tree.root.right.right.right = new Node<int>(6);
            int height = BinaryTreeHelperMethods<int>.getTreeHeight(tree.root);
            BinaryTreeHelperMethods<int>.levelOrderPrinting(tree.root,height);
        }
    }
}
