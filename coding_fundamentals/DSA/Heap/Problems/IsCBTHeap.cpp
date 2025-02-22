
// Structure of node
/*struct Node {
    int data;
    Node *left;
    Node *right;

    Node(int val) {
        data = val;
        left = right = NULL;
    }
};*/
class Info
{
  public :
    bool isHeap;
    int maxValue;
    Info()
    {
        isHeap = true;
        maxValue = INT_MIN;
    }
};

class Solution {
  public:
    Info* isHeapRec(struct Node* tree) {
        // code here
        if(tree == NULL)
        {
            return new Info(); 
        }
        Info* leftKaAns = isHeapRec(tree->left);
        Info* rightKaAns = isHeapRec(tree->right);
        Info* currentNodeKaAns = new Info();
        if(leftKaAns->isHeap && rightKaAns->isHeap && tree->data > rightKaAns->maxValue && tree->data > leftKaAns->maxValue)
        {
            currentNodeKaAns->maxValue = tree->data;
        }
        else
            currentNodeKaAns->isHeap = false;
        return currentNodeKaAns;
    }
    bool isHeap(struct Node* tree) {
        return isHeapRec(tree)->isHeap;
    }
};