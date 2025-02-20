using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_fundamentals.DSA.Tree.Misc_Problems
{
    /**
     * Definition for a binary tree node.
     */
    //struct TreeNode
    //{
    //    int val;
    //    TreeNode* left;
    //    TreeNode* right;
    //    TreeNode() : val(0), left(nullptr), right(nullptr) { }
    //    TreeNode(int x) : val(x), left(nullptr), right(nullptr) { }
    //    TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) { }
    //};
    class Solution
    {
        public:
        bool isSameTree(TreeNode* p, TreeNode* q)
        {
            if (!p && !q) return true;
            if (!p) return false;
            if (!q) return false;
            if (p->val == q->val)
            {
                bool ans1 = isSameTree(p->left, q->left);
                bool ans2 = isSameTree(p->right, q->right);
                return ans1 && ans2;
            }
            else
                return false;
        }
    };
}
