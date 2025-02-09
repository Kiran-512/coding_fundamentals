using All.Design.Patterns.DSA.Tree.RootNode;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tree.BST
{
    public class Misc
    {
        public static TreeNode InOrderSuccessor(TreeNode root, TreeNode X)
        {
            if (root == null) return root;
            TreeNode succ = null;
            TreeNode it = root;
            while (it != null)
            {
                if (it.val > X.val)
                {
                    succ = it;
                    it = it.left;//Minimise the value here by going in the left
                    //in left subtree, next greater element will always be on the left side
                    //but on the side side the moment we get the next greater element than the curr Node value, then we go left to dig down for lower value than the curr node value!
                    //as right side subtree will always have higher value!
                }
                else
                    it = it.right;
            }
            return succ;
        }
        public static TreeNode InOrderPredecessor(TreeNode root, TreeNode X)
        {
            if (root == null) return root;
            TreeNode pred = null;
            TreeNode it = root;
            while (it != null)
            {
                if (it.val < X.val)
                {//check if the curr value is less than the X val then store as this could be the predecessor and go to the right to maximise the value
                    pred = it;
                    it = it.right;
                }
                else
                    it = it.left;
            }
            return pred;
        }
        public static List<List<int>> TwoSumList(TreeNode root1, TreeNode root2, int X)
        {
            List<List<int>> ans = new List<List<int>>();
            Stack<TreeNode> st1 = new Stack<TreeNode>();
            Stack<TreeNode> st2 = new Stack<TreeNode>();
            TreeNode a = root1, b = root2;
            while (true)
            {
                while (a != null)
                {
                    st1.Push(a);
                    a = a.left;
                }
                while (b != null)
                {
                    st1.Push(b);
                    b = b.left;
                }

                if (st1.Count == 0 || st2.Count == 0)
                {
                    break;
                }
                TreeNode atop = st1.Peek();
                TreeNode btop = st2.Peek();
                int sum = atop.val + btop.val;
                if (sum == X)
                {
                    ans.Add(new List<int>() { atop.val, btop.val });
                    st1.Pop();
                    st2.Pop();
                }
                else if (sum < X)
                {
                    st1.Pop();
                    a = atop.right;
                }
                else
                {
                    st2.Pop();
                    b = btop.left;
                }
            }
            return ans;
        }

        public static List<int> GetInorder(TreeNode root)
        {
            if (root == null) return null;
            List<int> inorder = new List<int>();
            Stack<TreeNode> st = new Stack<TreeNode>();
            TreeNode it = root;
            while (true)
            {
                while (it != null)
                {
                    st.Push(it);
                    it = it.left;
                }

                if (st.Count == 0) break;

                TreeNode temp = st.Pop();
                inorder.Add(temp.val);
                it = temp.right;
            }
            return inorder;
        }
        public static TreeNode buildBBST(List<int> inorder, int start, int end)
        {
            if (start > end) return null;
            int mid = start + (end - start) / 2;
            TreeNode root = new TreeNode(inorder[mid]);
            root.left = buildBBST(inorder, start, mid - 1);
            root.right = buildBBST(inorder, mid + 1, end);
            return root;
        }
        //Balance a Binary Search Tree
        public static TreeNode BalanceABST(TreeNode root)
        {
            List<int> inorder = GetInorder(root);
            return buildBBST(inorder, 0, inorder.Count - 1);
        }
    }
}
