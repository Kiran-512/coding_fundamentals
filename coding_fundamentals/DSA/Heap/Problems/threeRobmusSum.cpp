#include <iostream>
#include <vector>
#include <algorithm>
#include <unordered_set>
#include <queue>

using namespace std;

typedef pair<int, int> Point;

bool checkBounds(vector<vector<int>> &grid, const vector<Point> &P)
{
    int m = grid.size();
    int n = grid[0].size();
    for (Point p : P)
    {
        if (p.first < 0 || p.first >= m || p.second < 0 || p.second >= n)
        {
            return false;
        }
    }
    return true;
}

bool getAllVertices(vector<vector<int>> &grid, Point center, int delta, vector<Point> &P)
{
    P[0] = {center.first - delta, center.second};
    P[1] = {center.first, center.second - delta};
    P[2] = {center.first + delta, center.second};
    P[3] = {center.first, center.second + delta};
    if (checkBounds(grid, P))
        return true;
    return false;
}

void getAllRhombusSum(vector<vector<int>> &grid, Point center, priority_queue<int> &pq, unordered_set<int> &uniqueSums)
{
    pq.push(grid[center.first][center.second]);
    uniqueSums.insert(grid[center.first][center.second]);
    int delta = 1;
    vector<Point> P(4);
    while (getAllVertices(grid, center, delta, P))
    {
        int sum = 0;
        for (pair<int, int> v : P)
        {
            sum += grid[v.first][v.second];
        }

        // all cells between AB
        for (int i = 1; i < P[2].first - P[0].first; i++)
        {
            sum += grid[P[0].first + i][P[0].second + i];
        }
        // all cells between BC
        for (int i = 1; i < P[2].first - P[1].first; i++)
        {
            sum += grid[P[1].first + i][P[1].second - i];
        }
        // all cells between CD
        for (int i = 1; i < P[2].first - P[3].first; i++)
        {
            sum += grid[P[2].first - i][P[2].second - i];
        }
        // all cells between DE
        for (int i = 1; i < P[3].first - P[0].first; i++)
        {
            sum += grid[P[3].first - i][P[3].second + i];
        }

        if (uniqueSums.insert(sum).second)
        {
            pq.push(sum);
        }
        delta++;
    }
}

vector<int> getThreeLargestRhombusSums(const vector<vector<int>> &grid)
{
    int m = grid.size();
    int n = grid[0].size();
    priority_queue<int> pq;
    unordered_set<int> uniqueSums;
    for (int i = 0; i < m; ++i)
    {
        for (int j = 0; j < n; ++j)
        {
            getAllRhombusSum(grid, {i, j}, pq, uniqueSums);
        }
    }

    vector<int> result;
    while (!pq.empty() && result.size() < 3)
    {
        result.push_back(pq.top());
        pq.pop();
    }
    return result;
}

int main()
{
    vector<vector<int>> grid = {
        {3, 4, 5, 1, 3},
        {3, 3, 4, 2, 3},
        {20, 30, 200, 40, 10},
        {1, 5, 5, 4, 1},
        {4, 3, 2, 2, 5}};

    vector<int> result = getThreeLargestRhombusSums(grid);

    for (int sum : result)
    {
        cout << sum << " ";
    }

    return 0;
}