/*
Problem: Remove Stones to Minimize the Total

Problem Statement:
You are given a list of piles of stones, where each pile contains a positive integer number of stones. In each move, you can choose any pile of stones and remove half of the stones from it (rounding down). You need to perform exactly `k` moves. The goal is to minimize the total number of stones remaining after `k` moves.

Write a function `minStoneSum` that takes two arguments:
- `piles`: a vector of integers representing the number of stones in each pile.
- `k`: an integer representing the number of moves you can perform.

The function should return the minimum possible total number of stones remaining after `k` moves.

Example:
int main() {
    vector<int> piles = {5, 4, 9};
    int k = 2;
    cout << "Minimum total after removing stones: " << minStoneSum(piles, k) << endl;
    return 0;
}

Input:
- `piles = [5, 4, 9]`
- `k = 2`

Output:
- `12`

Explanation:
1. Choose the pile with 9 stones and remove half of the stones: `9 - 4 = 5` (piles become `[5, 4, 5]`).
2. Choose the pile with 5 stones and remove half of the stones: `5 - 2 = 3` (piles become `[3, 4, 5]`).

The total number of stones remaining is `3 + 4 + 5 = 12`.

Constraints:
- `1 <= piles.length <= 10^5`
- `1 <= piles[i] <= 10^4`
- `1 <= k <= 10^5`
*/

#include <iostream>
#include <vector>
#include <queue>
#include <numeric>

using namespace std;

int minStoneSum(vector<int>& piles, int k) {
    priority_queue<int> maxHeap(piles.begin(), piles.end());
    while (k-- > 0) {
        int largest = maxHeap.top();
        maxHeap.pop();
        largest -= largest / 2;
        maxHeap.push(largest);
    }
    return accumulate(maxHeap.begin(), maxHeap.end(), 0);
    // int total = 0;
    // while (!maxHeap.empty()) {
    //     total += maxHeap.top();
    //     maxHeap.pop();
    // }
    // return total;
}

int main() {
    vector<int> piles = {5, 4, 9};
    int k = 2;
    cout << "Minimum total after removing stones: " << minStoneSum(piles, k) << endl;
    return 0;
}