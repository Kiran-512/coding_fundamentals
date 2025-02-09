using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tree.RootNode
{
    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public TreeNode(int val)
        {
            this.val = val;
            left = null;
            right = null;
        }
    }
}
