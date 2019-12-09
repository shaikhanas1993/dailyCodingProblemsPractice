using System;
using System.Linq;
using System.Collections.Generic;

namespace Problem4
{
//This problem was asked by Google.

// Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.

// For example, given the following Node class

// class Node:
//     def __init__(self, val, left=None, right=None):
//         self.val = val
//         self.left = left
//         self.right = right
// The following test should pass:

// node = Node('root', Node('left', Node('left.left')), Node('right'))
// assert deserialize(serialize(node)).left.left.val == 'left.left'

    class Node<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;

        public Node(T data)
        {
            this.data = data;
        }
    }
    class BinaryTree<T>
    {
       public Node<T> root;

       public BinaryTree()
       {
           this.root = null;
       }
       public BinaryTree(Node<T> root)
       {
           this.root = root;
       }
    }

    static class Helper<T>
    {
        public static int getHeight(Node<T> root)
        {
            if(root == null)
            {
                return 0;
            }

            int leftPath = 0;
            int rightPath = 1;

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

        public static string print(Node<T> root,int level)
        {
            string result = "";
            if(root == null)
            {
                return result = result + "X" + ",";
            }

            if(level == 0)
            {
                result = result + root.data + ",";
            }else if(level > 0)
            {
               result = result +  print(root.left,level - 1);
               result = result +  print(root.right,level - 1);
            }
            return result;
        }
        public static string serializeTree(Node<T> root)
        {
            String result = "";
            //follow bfs approach to serialize the tree
            int height = getHeight(root);
            for(int i = 1 ; i<= height + 1;i++)
            {
                int level = i - 1;
                result = result + print(root,level);
            }

            return result;
        }
        
        public static Node<T> insertInBfs(T[] input,Node<T> root,int level)
        {
            if(level < input.Length)
            {
                
                
                Node<T> temp = new Node<T>(input[level]);
                root = temp;
                root.left = insertInBfs(input,root.left,2 * level + 1);
                root.right = insertInBfs(input,root.right,2 * level + 2);
            }   
            return root;
        }

        public static BinaryTree<T> deserializeTree(string s)
        {
            var elements = s.Split(",");
            T[] input = new T[elements.Length];
            for(int i = 0 ;i < elements.Length;i++)
            {
                input[i] = (T) Convert.ChangeType(elements[i],typeof(T));
            }

            

            Node<T> root = insertInBfs(input,null,0);    
            BinaryTree<T> tree = new BinaryTree<T>();
            tree.root = root;
            return tree;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
           var tree = new BinaryTree<string>();
           tree.root = new Node<string>("root");
           tree.root.left = new Node<string>("left");
           tree.root.right = new Node<string>("right");
           tree.root.left.left = new Node<string>("left.left");
           tree.root.right.left = new Node<string>("right.left");
           string result = Helper<string>.serializeTree(tree.root);
           var root = Helper<string>.deserializeTree(result);
           
        }
    }
}
