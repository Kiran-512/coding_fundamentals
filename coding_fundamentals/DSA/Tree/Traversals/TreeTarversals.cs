﻿using All.Design.Patterns.DSA.Tree.RootNode;
using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Tree.Construct_Tree.Traversals
{
    public static class TreeTarversals
    {
        public static void LevelOrderTraversal(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            q.Enqueue(null);

            while (q.Count > 1)
            {
                var front = q.Dequeue();
                if (front != null)
                {
                    Console.Write(front.val);
                    if (front.left != null)
                    {
                        q.Enqueue(front.left);
                    }
                    if (front.right != null)
                    {
                        q.Enqueue(front.right);
                    }
                }
                else
                {
                    Console.WriteLine("");
                    q.Enqueue(null);
                }
            }
        }
        public static List<int> MorriesTraversal(TreeNode root)
        {
            //space complexity O(1), setting up the link between the extreem inorder preedecessor to the root(curr) node
            TreeNode curr = root;
            List<int> vector = new List<int>();
            while (curr != null)
            {
                if (curr.left == null)
                {//if left is null then visit the current node and go right
                    vector.Add(curr.val);
                    curr = curr.right;
                }
                else
                {
                    //find inorder predecessor
                    TreeNode predecessor = curr.left;
                    while (predecessor.right != curr && predecessor.right != null)
                    {
                        predecessor = predecessor.right;
                    }

                    //if right node is null then predecessor node is our inorder predecessor for curr node,
                    //set up link here to curr node from right predecessor
                    //and go left and continue for hunt of the next node
                    if (predecessor.right == null)
                    {
                        predecessor.right = curr;
                        curr = curr.left;
                    }
                    else//left is already visited,go right after visiting curr node
                    {
                        predecessor.right = null;
                        vector.Add(curr.val);
                        curr = curr.right;
                    }
                }
            }
            return vector;
        }
        public static void DiagonalTraversal(TreeNode root)
        {
            if (root != null) return;
            List<int> diagonal = new List<int>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode front = q.Dequeue();

                while (front != null)
                {
                    diagonal.Add(front.val);
                    if (front.left != null)
                    {
                        q.Enqueue(front);
                    }
                    front = front.right;
                }
            }
        }
        public static void VerticalTraversal(TreeNode root)
        {
        }
    }
}
