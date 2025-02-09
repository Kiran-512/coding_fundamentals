using All.Design.Patterns.DSA.Tree.RootNode;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tree.Construct_Tree
{
    public class Tree
    {
        public static TreeNode ConstructTree()
        {
            Console.WriteLine("Enter data ");
            var data = Console.ReadLine();
            if (Convert.ToInt32(data) == -1)
            {
                return null;
            }
            TreeNode root = new TreeNode(Convert.ToInt32(data));
            root.left = ConstructTree();
            root.right = ConstructTree();
            return root;
        }
    }
}
