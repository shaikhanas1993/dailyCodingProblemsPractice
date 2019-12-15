using System;

namespace IncorrectBST1
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val)
        {
            this.val = val;
            left = null;
            right = null;
        }
    }

    class RecoverBst
    {
        public TreeNode firstStartingPoint;
        public TreeNode lastStartingPoint;
        public TreeNode prev;

        public void findSegment(TreeNode root)
        {
            if(root == null)
            {
                return;
            }

            findSegment(root.left);
            if(prev != null)
            {
                if(prev.val > root.val)
                {
                    if(firstStartingPoint == null)
                    {
                        firstStartingPoint = prev;
                    }
                    lastStartingPoint = root;
                }
            }
            prev = root;
            findSegment(root.right);
        }

        public TreeNode findTree(TreeNode root,int left,int right)
        {
                if(root == null)
                {
                    return null;
                }
              
                if(root.val == left)
                {
                    root.val = right;
                    return root;
                }
                
                if(root.val == right)
                {
                    root.val = left;
                    return root;
                }
                root.left = findTree(root.left,left,right);    
                root.right = findTree(root.right,left,right);
                return root;
        }
        public TreeNode recoverTreeFunc(TreeNode root)
        {
            findSegment(root);
            // int x = firstStartingPoint.val;
            // firstStartingPoint.val = lastStartingPoint.val;
            // lastStartingPoint.val = x;
            TreeNode newNode = findTree(root,firstStartingPoint.val,lastStartingPoint.val);
            return newNode;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(10);
            TreeNode n1   = new TreeNode(15);
            TreeNode n2   = new TreeNode(5);
            TreeNode n3   = new TreeNode(4);
            TreeNode n4   = new TreeNode(7);
            TreeNode n5   = new TreeNode(14);
            TreeNode n6   = new TreeNode(17);
                
            root.left  = n1;
            root.right = n2;
                
            n1.left  = n3;
            n1.right = n4;
                
            n2.left  = n5;
            n2.right = n6;

            RecoverBst obj = new RecoverBst();
            root = obj.recoverTreeFunc(root);
        }
    }
}
