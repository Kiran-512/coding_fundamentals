using All.Design.Patterns.DSA.Tree.RootNode;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tree.Misc_Problems
{
    public class Misc
    {
        public static KeyValuePair<int, int> getMaxSum(TreeNode root)
        {
            if (root == null) return new KeyValuePair<int, int>(0, 0);
            var left = getMaxSum(root.left);
            var right = getMaxSum(root.right);

            //sum inlcuding the node
            var inSum = root.val + left.Value + right.Value;

            //sum excluding the node
            var exSum = Math.Max(left.Key, left.Value) + Math.Max(right.Key, right.Value);
            return new KeyValuePair<int, int>(inSum, exSum);
        }
    }
}
