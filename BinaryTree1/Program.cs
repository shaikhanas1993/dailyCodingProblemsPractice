﻿using System;

namespace BinaryTree1
{

    class Node<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;

        public Node(T data)
        {
            this.data = data;
            left = right = null;
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

    static class TreeHeightCalculate<T>
    {
        public static int calculateHeight(Node<T> root)
        {
            if(root == null)
            {
                return 0;
            }

            int leftPath = 0;
            int rightPath = 0;

            if(root.left != null)
            {
                leftPath =  1 + calculateHeight(root.left);
            }

            if(root.right != null)
            {
                rightPath = 1 + calculateHeight(root.right);
            }

            return rightPath > leftPath ? rightPath : leftPath;

        }
        
    }

    static class Printing<T>
    {
        public static void InorderPrint(Node<T> root)
        {
            
            //left root right
            if(root == null)
            {
                return;
            }
            
            InorderPrint(root.left);
            Console.Write(root.data + ",");
            InorderPrint(root.right);
        }

        public static void PreorderPrint(Node<T> root)
        {
            //Root left right
            
            if(root == null)
            {
                return;
            }
            
            Console.Write(root.data + ",");
            PreorderPrint(root.left);
            PreorderPrint(root.right);
        }

        public static void PostorderPrint(Node<T> root)
        {
            // left right root
            
            if(root == null)
            {
                return;
            }
            
            PostorderPrint(root.left);
            PostorderPrint(root.right);
            Console.Write(root.data + ",");
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
            tree.root.left.left = new Node<int>(4);
            int height = TreeHeightCalculate<int>.calculateHeight(tree.root);
            Console.WriteLine(height);
            // Printing<int>.InorderPrint(tree.root);

            // var tree1 = new BinaryTree<string>();
            // tree1.root = new Node<string>("anas");
            // tree1.root.left = new Node<string>("nabeela");
            // tree1.root.right = new Node<string>("jarrar");
            // Printing<string>.PostorderPrint(tree1.root);
        }
    }
}
