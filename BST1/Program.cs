using System;

namespace BST1
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val)
        {
            this.val = val;
        }
    }

    class Helper
    {
        public  TreeNode insertHelper(TreeNode root,int val)
        {
            if(root == null)
            {
                  return  root = new TreeNode(val);
            }

            if(val > root.val)
            {
                //Traverse right
                root.right = insertHelper(root.right,val);
            }
            else
            {
                //Traverse left
                root.left = insertHelper(root.left,val);
            }
            return root;
        }
        // public TreeNode insert(int val)
        // {
        //     return insertHelper(null,val);
        // }
    }

    class BinaryTree
    {
        public TreeNode root;
        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(TreeNode node)
        {
            root = node;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            Helper helper = new Helper();
           tree.root =  helper.insertHelper(tree.root,8);
          tree.root =  helper.insertHelper(tree.root,4); 
          tree.root =   helper.insertHelper(tree.root,6);
          tree.root =  helper.insertHelper(tree.root,10);

        }
    }
}
