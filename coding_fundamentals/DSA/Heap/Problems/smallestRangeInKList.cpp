#include <iostream>
#include <vector>
#include <queue>
#include <climits>

using namespace std;

class Info {
public:
    int value;
    int row;
    int col;
    
    Info(int v, int r, int c) : value(v), row(r), col(c) {}
};

struct compare {
    bool operator()(Info const& a, Info const& b) {
        return a.value > b.value;
    }
};

pair<int, int> smallestRange(vector<vector<int>>& nums) {
    priority_queue<Info, vector<Info>, compare> minHeap;
    int maxElement = INT_MIN;
    int rangeStart = 0, rangeEnd = INT_MAX;

    // Initialize the heap with the first element of each list
    for (int i = 0; i < nums.size(); i++) {
        minHeap.push(Info(nums[i][0], i, 0));
        maxElement = max(maxElement, nums[i][0]);
    }

    while (true) {
        Info minElement = minHeap.top();
        minHeap.pop();

        // Update the range if the current range is smaller
        if (maxElement - minElement.value < rangeEnd - rangeStart) {
            rangeStart = minElement.value;
            rangeEnd = maxElement;
        }

        // If we have reached the end of one of the lists, break
        if (minElement.col + 1 == nums[minElement.row].size()) {
            break;
        }

        // Add the next element of the current list to the heap
        int nextValue = nums[minElement.row][minElement.col + 1];
        minHeap.push(Info(nextValue, minElement.row, minElement.col + 1));
        maxElement = max(maxElement, nextValue);//this works as list is sorted!!
    }

    return {rangeStart, rangeEnd};
}

int main() {
    vector<vector<int>> nums = {
        {4, 10, 15, 24, 26},
        {0, 9, 12, 20},
        {5, 18, 22, 30}
    };

    pair<int, int> result = smallestRange(nums);
    cout << "The smallest range is [" << result.first << ", " << result.second << "]" << endl;

    return 0;
}