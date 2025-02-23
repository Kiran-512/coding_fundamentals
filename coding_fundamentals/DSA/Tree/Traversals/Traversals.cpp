
#include <iostream>
#include <vector>
using namespace std;

struct TreeNode
{
    int val;
    TreeNode *left;
    TreeNode *right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

class TreeTraversals
{
public:
    void preOrder(TreeNode *root, vector<int> &result)
    {
        if (root == NULL)
            return;
        result.push_back(root->val);
        preOrder(root->left, result);
        preOrder(root->right, result);
    }

    // iterative
    void preOrder(TreeNode *root, vector<int> &result)
    {
        if (root == NULL)
            return;
        stack<TreeNode *> s;
        s.push(root);
        while (!s.empty())
        {
            TreeNode *node = s.top();
            s.pop();
            result.push_back(node->val);
            if (node->right)
                s.push(node->right);
            if (node->left)
                s.push(node->left);
        }
    }

    void inOrder(TreeNode *root, vector<int> &result)
    {
        if (root == NULL)
            return;
        inOrder(root->left, result);
        result.push_back(root->val);
        inOrder(root->right, result);
    }

    // iterative
    void inOrder(TreeNode *root, vector<int> &result)
    {
        if (root == NULL)
            return;
        stack<TreeNode *> s;
        TreeNode *curr = root;
        while (true)
        {
            while (curr)
            {
                s.push(curr);
                curr = curr->left;
            }
            if (s.empty())
                break;
            curr = s.top();
            s.pop();
            result.push_back(curr->val);
            curr = curr->right;
        }
    }

    // Morris Traversal for InOrder
    // Morris Traversal is an algorithm for traversing the tree without using any extra space.
    void inOrder(TreeNode *root, vector<int> &result)
    {
        TreeNode *curr = root;
        while (curr)
        {
            if (!curr->left)
            {
                result.push_back(curr->val);
                curr = curr->right;
            }
            else
            {
                TreeNode *pre = curr->left;
                while (pre->right && pre->right != curr) // Find the inorder predecessor of current
                {
                    pre = pre->right;
                }

                if (!pre->right)
                {
                    pre->right = curr;
                    curr = curr->left;
                }
                else
                {
                    pre->right = NULL;
                    result.push_back(curr->val);
                    curr = curr->right;
                }
            }
        }
    }

    void postOrder(TreeNode *root, vector<int> &result)
    {
        if (root == NULL)
            return;
        postOrder(root->left, result);
        postOrder(root->right, result);
        result.push_back(root->val);
    }

    // iterative
    void postOrder(TreeNode *root, vector<int> &result)
    {
        if (root == NULL)
            return;
        stack<TreeNode *> st;
        st.push(root);
        while (!st.empty())
        {
            TreeNode *node = st.top();
            st.pop();
            result.insert(node->val);
            if (node->left)
                st.push(node->left);
            if (node->right)
                st.push(node->right);
        }
        reverse(result.begin(), result.end());
    }

    void levelOrder(TreeNode *root)
    {
        if (root == NULL)
            return;
        queue<TreeNode *> q;
        q.push(root);
        q.push(NULL); // NULL is used to separate levels
        while (!q.empty())
        {
            TreeNode *node = q.front();
            q.pop();
            if (node)
            {
                if (node->left)
                    q.push(node->left);
                if (node->right)
                    q.push(node->right);
            }
            else
            {
                cout << " " << endl;
                q.push(NULL);
            }
        }
    }
};

int main()
{
    TreeNode *root = new TreeNode(1);
    root->left = new TreeNode(2);
    root->right = new TreeNode(3);
    root->left->left = new TreeNode(4);
    root->left->right = new TreeNode(5);
    root->right->left = new TreeNode(6);
    root->right->right = new TreeNode(7);

    TreeTraversals traversals;
    vector<int> preOrderResult, inOrderResult, postOrderResult;
    vector<vector<int>> levelOrderResult;

    traversals.preOrder(root, preOrderResult);
    traversals.inOrder(root, inOrderResult);
    traversals.postOrder(root, postOrderResult);
    traversals.levelOrder(root, levelOrderResult);

    cout << "PreOrder: ";
    for (int val : preOrderResult)
        cout << val << " ";
    cout << endl;

    cout << "InOrder: ";
    for (int val : inOrderResult)
        cout << val << " ";
    cout << endl;

    cout << "PostOrder: ";
    for (int val : postOrderResult)
        cout << val << " ";
    cout << endl;

    cout << "LevelOrder: ";
    for (const auto &level : levelOrderResult)
    {
        for (int val : level)
            cout << val << " ";
        cout << endl;
    }

    return 0;
}
