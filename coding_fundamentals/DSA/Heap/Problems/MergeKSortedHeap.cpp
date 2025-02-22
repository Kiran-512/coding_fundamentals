#include <iostream>
#include <vector>
#include <queue>

class Info
{
public:
    int value;
    int row;
    int col;
    Info(int v, int r, int c) : value(v), row(r), col(c) {}
};

struct Compare
{
    bool operator()(Info const &a, Info const &b)
    { // This comparator returns true if a > b, meaning b should come before a.
        return a.value > b.value;
    }
};

std::vector<int> mergeKSortedArrays(std::vector<std::vector<int>> &arrays)
{
    std::priority_queue<Info, std::vector<Info>, Compare> minHeap;
    std::vector<int> result;

    // Initialize the heap with the first element of each array
    for (int i = 0; i < arrays.size(); ++i)
    {
        if (!arrays[i].empty())
        {
            minHeap.push(Info(arrays[i][0], i, 0));
        }
    }

    // Extract the minimum element from the heap and add the next element from the same array to the heap
    while (!minHeap.empty())
    {
        Info current = minHeap.top();
        minHeap.pop();
        result.push_back(current.value);

        if (current.col + 1 < arrays[current.row].size())
        {
            minHeap.push(Info(arrays[current.row][current.col + 1], current.row, current.col + 1));
        }
    }

    return result;
}

int main()
{
    std::vector<std::vector<int>> arrays = {
        {1, 4, 7},
        {2, 5, 8},
        {3, 6, 9}};

    std::vector<int> result = mergeKSortedArrays(arrays);

    for (int num : result)
    {
        std::cout << num << " ";
    }

    return 0;
}
/*
// Comparator for Min-Heap (smallest val on top)
struct MinHeapCompare {
    bool operator()(const Info& a, const Info& b) {
        return a.val > b.val;  // Min-Heap: smaller val comes first
    }
};

// Comparator for Max-Heap (largest val on top)
struct MaxHeapCompare {
    bool operator()(const Info& a, const Info& b) {
        return a.val < b.val;  // Max-Heap: larger val comes first
    }
};

For std::priority_queue → It treats Compare as a "higher priority comes first" rule, so if a > b is true, makes it a Min-Heap as b comes before a.
For std::priority_queue → It treats Compare as a "higher priority comes first" rule, so if a < b is true, makes it a Max-Heap as b comes before a.
a - element on the top
b - new element being isnerted

For std::set, std::sort, etc. → It sorts elements directly, so a > b results in descending order (like a Max-Heap).

*/