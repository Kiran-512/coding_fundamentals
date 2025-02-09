using All.Design.Patterns.DSA.Tree.RootNode;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tree.Views
{
    public static class TreeViews
    {
        public static void TopView(TreeNode root, int level, ref int[] topView)
        {
            if (root == null) return;

            Dictionary<int, int> map = new Dictionary<int, int>();
            Queue<KeyValuePair<int, TreeNode>> q = new Queue<KeyValuePair<int, TreeNode>>();
            q.Enqueue(new KeyValuePair<int, TreeNode>(0, root));
            while (q.Count != 0)
            {
                var front = q.Dequeue();
                if (front.Value != null)
                {
                    if (map.TryGetValue(front.Key, out _))
                    {
                        map[level] = front.Value.val;
                    }
                    if (front.Value.left != null)
                    {
                        q.Enqueue(new KeyValuePair<int, TreeNode>(front.Key - 1, front.Value.left));
                    }
                    if (front.Value.right != null)
                    {
                        q.Enqueue(new KeyValuePair<int, TreeNode>(front.Key + 1, front.Value.right));
                    }
                }
            }

            topView = new int[map.Keys.Count];
            int index = 0;
            foreach (var item in map)
            {
                topView[index++] = item.Key;
            }
        }
        public static void BottomView(TreeNode root, int level, ref int[] topView)
        {
            if (root == null) return;

            Dictionary<int, int> map = new Dictionary<int, int>();
            Queue<KeyValuePair<int, TreeNode>> q = new Queue<KeyValuePair<int, TreeNode>>();
            q.Enqueue(new KeyValuePair<int, TreeNode>(0, root));
            while (q.Count != 0)
            {
                var front = q.Dequeue();
                if (front.Value != null)
                {
                    //overwrite the values for a key!
                    map[front.Key] = front.Value.val;
                    if (front.Value.left != null)
                    {
                        q.Enqueue(new KeyValuePair<int, TreeNode>(front.Key - 1, front.Value.left));
                    }
                    if (front.Value.right != null)
                    {
                        q.Enqueue(new KeyValuePair<int, TreeNode>(front.Key + 1, front.Value.right));
                    }
                }
            }

            topView = new int[map.Keys.Count];
            int index = 0;
            foreach (var item in map)
            {
                topView[index++] = item.Key;
            }
        }
        public static void LeftView(TreeNode root, int level, List<int> leftView)
        {
            if (root == null) return;
            if (level == leftView.Count)
            {
                leftView.Add(root.val);
            }
            LeftView(root.left, level + 1, leftView);
            LeftView(root.right, level + 1, leftView);
        }
        public static void RightView(TreeNode root, int level, List<int> rightView)
        {
            if (root == null) return;
            if (level == rightView.Count)
            {
                rightView.Add(root.val);
            }
            RightView(root.right, level + 1, rightView);
            RightView(root.left, level + 1, rightView);
        }
        public static void printLeftView(TreeNode root)
        {
            if (root == null) return;
            if (root.left == null && root.right == null) return;
            Console.WriteLine(root.val);
            if (root.left != null)
            {
                printLeftView(root.left);
            }
            else
                printLeftView(root.right);
        }
        public static void printLeafNodes(TreeNode root)
        {
            if (root == null) return;
            if (root.left == null && root.right == null) Console.WriteLine(root.val);
            printLeafNodes(root.left);
            printLeafNodes(root.right);
        }
        public static void printRightView(TreeNode root)
        {
            if (root == null) return;
            if (root.left == null && root.right == null) return;
            Console.WriteLine(root.val);
            if (root.right != null)
            {
                printLeftView(root.right);
            }
            else
                printLeftView(root.right);
        }
        public static void BoundryTraversal(TreeNode root)
        {
            //print left view
            printLeftView(root);
            //print leaf nodes
            printLeafNodes(root);
            //print right view
            if (root.right != null)
                printLeafNodes(root.right);
            else
                printLeafNodes(root.left);
        }
    }
}
