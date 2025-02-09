using All.Design.Patterns.DSA.Tree.RootNode;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tree.BST
{
    public class BST_to_DLL
    {
        public static void ConvertBSTtoDLL(TreeNode root, TreeNode head)
        {
            if (root == null) return;
            ConvertBSTtoDLL(root.right, head);
            root.right = head;
            if (head != null)
                head.left = root;
            head = root;
            ConvertBSTtoDLL(root.left, head);
        }
        public static TreeNode ConvertDLLtoBST(TreeNode head, int n)
        {
            if (head == null || n <= 0) return null;

            TreeNode leftSubtree = ConvertDLLtoBST(head, n / 2);

            TreeNode root = head;
            root.left = leftSubtree;
            head = head.right;

            TreeNode rightSubtree = ConvertDLLtoBST(root.left, n - n / 2 - 1);
            root.right = rightSubtree;
            return root;
        } 
    }
}
