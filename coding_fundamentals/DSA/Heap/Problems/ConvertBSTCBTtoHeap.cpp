#include <iostream>
#include <vector>
#include <queue>

using namespace std;

// Definition for a binary tree node.
struct TreeNode {
    int val;
    TreeNode* left;
    TreeNode* right;
    TreeNode(int x) : val(x), left(NULL), right(NULL) {}
};

// Function to perform inorder traversal and store the result in a vector
void inorderTraversal(TreeNode* root, vector<int>& inorder) {
    if (root == NULL) return;
    inorderTraversal(root->left, inorder);
    inorder.push_back(root->val);
    inorderTraversal(root->right, inorder);
}

// Function to convert the BST to a Max Heap
void convertToMaxHeap(TreeNode* root, vector<int>& inorder, int& index) {
    if (root == NULL) return;
    // root->val = inorder[index++]; --to be used, if inorder sorted in descending order
    convertToMaxHeap(root->left, inorder, index);
    convertToMaxHeap(root->right, inorder, index);
    root->val = inorder[index++];    
}

// Function to convert a BST to a Max Heap
void convertBSTToMaxHeap(TreeNode* root) {
    vector<int> inorder;
    inorderTraversal(root, inorder);
    //sort(inorder.begin(), inorder.end(), greater<int>()); --sorting descending order
    int index = 0;
    convertToMaxHeap(root, inorder, index);
}

// Function to print level order traversal of the tree
void printLevelOrder(TreeNode* root) {
    if (root == NULL) return;
    queue<TreeNode*> q;
    q.push(root);
    while (!q.empty()) {
        TreeNode* node = q.front();
        q.pop();
        cout << node->val << " ";
        if (node->left != NULL) q.push(node->left);
        if (node->right != NULL) q.push(node->right);
    }
    cout << endl;
}

int main() {
    // Creating a sample BST
    TreeNode* root = new TreeNode(4);
    root->left = new TreeNode(2);
    root->right = new TreeNode(6);
    root->left->left = new TreeNode(1);
    root->left->right = new TreeNode(3);
    root->right->left = new TreeNode(5);
    root->right->right = new TreeNode(7);

    cout << "Level order traversal of the original BST:" << endl;
    printLevelOrder(root);

    convertBSTToMaxHeap(root);

    cout << "Level order traversal of the converted Max Heap:" << endl;
    printLevelOrder(root);

    return 0;
}