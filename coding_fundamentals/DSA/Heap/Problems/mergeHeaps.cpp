#include <iostream>
#include <vector>
#include <queue>

using namespace std;

// Function to merge two heaps using priority queue
vector<int> mergeHeaps(vector<int>& heap1, vector<int>& heap2) {
    // Step 1: Create a max priority queue
    priority_queue<int> pq;

    // Step 2: Insert all elements from both heaps into the priority queue
    for (int val : heap1) {
        pq.push(val);
    }
    for (int val : heap2) {
        pq.push(val);
    }
    // Step 3: Extract elements from the priority queue to form the merged heap
    vector<int> mergedHeap;
    while (!pq.empty()) {
        mergedHeap.push_back(pq.top());
        pq.pop();
    }

    return mergedHeap;
}

// Function to print the elements of a vector
void printVector(const vector<int>& vec) {
    for (int val : vec) {
        cout << val << " ";
    }
    cout << endl;
}

int main() {
    vector<int> heap1 = {10, 5, 6, 2};
    vector<int> heap2 = {12, 7, 9};

    vector<int> mergedHeap = mergeHeaps(heap1, heap2);

    cout << "Merged Heap: ";
    printVector(mergedHeap);

    return 0;
}
