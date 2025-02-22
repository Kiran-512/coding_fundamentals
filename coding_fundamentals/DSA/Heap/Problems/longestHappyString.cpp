#include <iostream>
#include <queue>
#include <string>
#include <vector>

using namespace std;

class Solution {
public:
    string longestDiverseString(int a, int b, int c) {
        priority_queue<pair<int, char>> pq;
        if (a > 0) pq.push(make_pair(a, 'a'));
        if (b > 0) pq.push(make_pair(b, 'b'));
        if (c > 0) pq.push(make_pair(c, 'c'));

        string result = "";
        while (pq.size() > 1)
        {
            pair<int, char> top1 = pq.top();
            pq.pop();
            pair<int, char> top2 = pq.top();
            pq.pop();

            if (top1.first >= 2)
            {
                result.push_back(top1.second);
                result.push_back(top1.second);
                top1.first -= 2;
            }
            else
            {
                result.push_back(top1.second);
                top1.first--;
            }
            if (top1.first > 0) pq.push(top1);

            if (top2.first >=2 && top2.first >= top1.first)
            {
                result.push_back(top2.second);
                result.push_back(top2.second);
                top2.first -= 2;
            }
            else
            {
                result.push_back(top2.second);
                top2.first--;
            }
            if (top2.first > 0) pq.push(top2);
        }
        if (pq.size() ==1)
        {
            if (pq.top().first >= 2)
            {
                result.push_back(pq.top().second);
                result.push_back(pq.top().second);
            }
            else
            {
                result.push_back(pq.top().second);
            }
        }
        return result;
    }
};

int main() {
    Solution solution;
    int a = 1, b = 1, c = 7;
    cout << "Longest happy string: " << solution.longestDiverseString(a, b, c) << endl;
    return 0;
}