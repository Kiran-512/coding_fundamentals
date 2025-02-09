using All.Design.Patterns.DSA.Tree.RootNode;
using System;
using System.Collections.Generic;
using System.Text;
using All.Design.Patterns.DSA.Tree.Construct_Tree.Traversals;

namespace All.Design.Patterns.DSA.Tree.Construct_Tree
{
    public static class PreOrder_Inorder
    {
        public static int findInorderIndex(int[] inorder, int target)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }
        public static TreeNode Construct_Tree(int[] preOrder, int[] inorder, ref int preIndex, int inIndexStart, int inIndexEnd)
        {
            if (preIndex > preOrder.Length || inIndexStart > inIndexEnd)
            {
                return null;
            }
            int element = preOrder[preIndex++];
            TreeNode root = new TreeNode(element);

            var inOrderIndex = findInorderIndex(inorder, element);

            root.left = Construct_Tree(preOrder, inorder, ref preIndex, inIndexStart, inOrderIndex - 1);
            root.right = Construct_Tree(preOrder, inorder, ref preIndex, inOrderIndex + 1, inIndexEnd);
            return root;
        }
        public static void Main1()
        {
            int[] preorder = { 3, 9, 20, 15, 7 };//PLR
            int[] inorder = { 9, 3, 15, 20, 7 };//LPR
            int preIndex = 0;
            int inIndexStart = 0;
            int inIndexEnd = inorder.Length - 1;
            TreeNode root = Construct_Tree(preorder, inorder, ref preIndex, inIndexStart, inIndexEnd);
            TreeTarversals.LevelOrderTraversal(root);
        }
    }
}
