using All.Design.Patterns.DSA.Tree.RootNode;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tree.BST
{
    public class BSTCreation
    {
        public static TreeNode InsertIntoBST(TreeNode root, int data)
        {
            if (root == null)
            {
                return new TreeNode(data);
            }
            if (data < root.val)
            {
                root.left = InsertIntoBST(root.left, data);
            }
            else
            {
                root.right = InsertIntoBST(root.right, data);
            }
            return root;
        }
        public static TreeNode Construct_Tree(TreeNode root)
        {
            Console.WriteLine("Enter data ");
            string data = Console.ReadLine();
            while (Convert.ToInt32(data) != -1)
            {
                InsertIntoBST(root, Convert.ToInt32(data));
                data = Console.ReadLine();
            }
            return root;
        }
        public static TreeNode Construct_BST_Inorder(List<int> inorder,int start,int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = start + (end - start) / 2;
            int element = inorder[mid];

            TreeNode root = new TreeNode(element);
            root.left = Construct_BST_Inorder(inorder, start, mid - 1);
            root.right = Construct_BST_Inorder(inorder, mid + 1, end);
            return root;

        }
        public static TreeNode MinValue(TreeNode root)
        {
            if (root == null) return null;
            TreeNode temp = root;
            while (temp.left != null)
            {
                temp = temp.left;
            }
            return temp;
        }
        public static TreeNode MaxValue(TreeNode root)
        {
            if (root == null) return null;
            TreeNode temp = root;
            while (temp.right != null)
            {
                temp = temp.right;
            }
            return temp;
        }
        public static TreeNode Search(TreeNode root, int target)
        {
            if (root == null) return null;
            if (target == root.val) return root;
            if (target > root.val)
                return Search(root.right, target);
            else
                return Search(root.left, target);
        }
    }
}
