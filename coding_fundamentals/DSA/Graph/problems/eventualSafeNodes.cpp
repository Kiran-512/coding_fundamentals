#include <iostream>
#include <vector>

using namespace std;

class Solution
{
public:
    vector<int> eventualSafeNodes(vector<vector<int>> &graph)
    {

        int V = graph.size(); //// V is the number of vertice
        vector<int> result;
        vector<bool> visited(V, false);
        vector<bool> dfsVisited(V, false);
        vector<bool> safe(V, false);

        for (int u = 0; u < V; ++u)
        {
            if (!visited[u])
            {
                dfs(u, graph, visited, dfsVisited, safe);
            }
        }

        for (int u = 0; u < V; ++u)
        {
            if (safe[u])
            {
                result.push_back(u);
            }
        }

        return result;
    }

private:
    bool dfs(int parent, vector<vector<int>> &adjList, vector<bool> &visited, vector<bool> &dfsVisited, vector<bool> &safe)
    {
        visited[parent] = true;
        dfsVisited[parent] = true;

        for (int child : adjList[parent])
        {
            if (!visited[child])
            {
                if (!dfs(child, adjList, visited, dfsVisited, safe))
                {
                    return false;
                }
            }
            else if (dfsVisited[child])
            {
                return false;
            }
        }

        dfsVisited[parent] = false;
        safe[parent] = true;
        return true;
    }
};

int main()
{
    Solution solution;
    vector<vector<int>> adjList = {{1, 2}, {2, 3}, {5}, {0}, {5}, {}, {}};
    vector<int> safeNodes = solution.eventualSafeNodes(adjList);

    cout << "Safe nodes are: ";
    for (int node : safeNodes)
    {
        cout << node << " ";
    }
    cout << endl;

    return 0;
}