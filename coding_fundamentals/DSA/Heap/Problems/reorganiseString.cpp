#include <iostream>
#include <string>
#include <unordered_map>
#include <queue>
#include <vector>

using namespace std;

string reorganizeString(string s) {
    unordered_map<char, int> freq;
    for (char c : s) {
        freq[c]++;
    }

    priority_queue<pair<int, char>> maxHeap;//based on key or first value here maxHeap is default implementation of priority queue here
    for (auto& entry : freq) {
        maxHeap.push({entry.second, entry.first});
    }

    string result = "";
    while (maxHeap.size() > 1)
    {
        pair<int, char> first = maxHeap.top();
        maxHeap.pop();
        pair<int, char> second = maxHeap.top();        
        maxHeap.pop();

        result.push_back(first.second);
        first.first--;
        result.push_back(second.second);
        second.first--;

        if (first.first > 0) {
            maxHeap.push(first);
        }
        if (second.first > 0) {
            maxHeap.push(second);
        }
    }

    if (maxHeap.size()==1)
    {
        if (maxHeap.top().first > 1)
        {
            return "";
        }
        result.push_back(maxHeap.top().second);
    }
    return result;
}

int main() {
    string s = "aab";
    string result = reorganizeString(s);
    if (result != "") {
        cout << "Reorganized string: " << result << endl;
    } else {
        cout << "Not possible to reorganize the string" << endl;
    }
    return 0;
}