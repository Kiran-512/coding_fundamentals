using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coding_fundamentals.DSA.Tree.Misc_Problems
{
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode() : val(0), left(nullptr), right(nullptr) {}
 *     TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
 *     TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
 * };
 */
 class Info{
    public :
        long long int maxi;
        long long int mini;
        bool isBST;

        Info(long long int max,long long int min,bool isBST):maxi(max),mini(min),isBST(isBST){};
 };
class Solution {
public:
    Info* isValidBSTRecBottomUp(TreeNode* root) {
        if(!root) return new Info(-2147483649, 2147483649, true);//-infy,infy,T //LEFT SUBTREE MAX,RIGHT SUBTREE MIN,T/F
        Info* leftInfo = isValidBSTRecBottomUp(root->left);
        Info* rightInfo = isValidBSTRecBottomUp(root->right);
        bool isBst = false;
        if(leftInfo->isBST
        && rightInfo->isBST
        && root->val > leftInfo->maxi
        && root->val < rightInfo->mini)
        {
            isBst = true;
        }
        return new Info(root->val>rightInfo->maxi?root->val : rightInfo->maxi, root->val < leftInfo->mini?root->val:leftInfo->mini,isBst);
    }
    bool isValidBST(TreeNode* root) {
        return isValidBSTRecBottomUp(root)->isBST;
    }
};
}
