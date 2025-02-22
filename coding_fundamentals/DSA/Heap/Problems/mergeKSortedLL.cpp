#include <iostream>
#include <vector>
#include <queue>

// Definition for singly-linked list.
struct ListNode {
    int val;
    ListNode* next;
    ListNode(int x) : val(x), next(nullptr) {}
};

// Comparator to be used in the priority queue
struct compare {
    bool operator()(ListNode* a, ListNode* b) {
        return a->val > b->val; // Min-heap based on node values
    }
};

// Function to merge k sorted linked lists
ListNode* mergeKSortedLists(std::vector<ListNode*>& lists) {
    // Priority queue to store the nodes of the linked lists
    std::priority_queue<ListNode*, std::vector<ListNode*>, compare> pq;
    
    // Push the head of each list into the priority queue
    for (ListNode* list : lists) {
        if (list) {
            pq.push(list);
        }
    }
    
    // Dummy node to help with the merged list
    ListNode* dummy = new ListNode(0);
    ListNode* current = dummy;
    
    // Process the priority queue until it's empty
    while (!pq.empty()) {
        // Get the node with the smallest value
        ListNode* top = pq.top();
        pq.pop();
        
        // Add this node to the merged list
        current->next = top;
        current = current->next;
        
        // If there are more nodes in the current list, push the next node into the queue
        if (top->next) {
            pq.push(top->next);
        }
    }
    
    // Return the merged list, which starts from dummy->next
    return dummy->next;
}

int main() {
    // Example usage
    // Create some linked lists and add them to the vector `lists`
    // Call mergeKSortedLists(lists) and print the merged list

    return 0;
}