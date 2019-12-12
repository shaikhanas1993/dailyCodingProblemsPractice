using System;

namespace Problem4R2
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
        public static readonly string NULL_SYMBOL   = "X";
        public static readonly string DELIMITER = ",";

        
        public int getHeight(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            int leftPath = 1 + getHeight(root.left);
            int rightPath = 1 + getHeight(root.right);
            return leftPath > rightPath ? leftPath : rightPath;
        }
        
        public String SerializeHelper(TreeNode root,int level)
        {
            String result = "";
            if(root == null)
            {
                return result = result +  NULL_SYMBOL + DELIMITER;
            }
            
            if(level == 0)
            {
               result = result +  root.value + DELIMITER;
            }else if(level > 0)
            {
               result = result + SerializeHelper(root.left,level-1);
               result = result +  SerializeHelper(root.right,level-1);
            }
            return result;
        }
        public String Serialize(TreeNode root)
        {
            String result = "";

            int height = getHeight(root);
            
            for(int i = 1; i < height + 1 ; i++)
            {
                int level = i - 1;
                result = result + SerializeHelper(root,level);
            }

            return result;
        }

        public TreeNode insertInBfs(string[] input,TreeNode node,int level)
        {
            if(level < input.Length)
            {
                TreeNode temp = input[level].Equals("X") ? null : new TreeNode(Int32.Parse(input[level]));
                if(temp == null)
                {
                    return null;
                }
                node = temp;

                node.left = insertInBfs(input,node.left,2 * level + 1);
                node.right = insertInBfs(input,node.right,2 * level + 2);
            }
            return node;
        }
        public TreeNode DeserializeFunc(string input)
        {
            var element = input.Split(DELIMITER);
            return insertInBfs(element,null,0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode node = new TreeNode(1);
            node.left = new TreeNode(2);
            node.right = new TreeNode(3);
            node.right.left = new TreeNode(4);
            Helper helper = new Helper();
            var result = helper.Serialize(node);
            var node1 = helper.DeserializeFunc(result);
        }
    }
}
