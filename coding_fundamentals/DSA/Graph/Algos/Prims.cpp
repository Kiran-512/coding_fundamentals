#include <iostream>
#include <vector>
#include <climits>

using namespace std;

int getMinValueNode(vector<int> &key, vector<bool> &mstSet)
{
    int min = INT_MAX;
    int index = -1;
    for (int i = 0; i < key.size(); i++)
        if (!mstSet[i] && key[i] < min)
            min = key[i], index = i;
    return index;
}

void printMST(vector<int> &parent, vector<vector<int>> &adj, int V)
{
    cout << "Edge \tWeight\n";
    for (int i = 1; i < V; i++)
    {
        cout << parent[i] << " - " << i << " \t" << adj[i][parent[i]] << " \n";
    }
}

int getMSTSum(vector<int> &parent, vector<vector<pair<int, int>>> &adj)
{
    int sum = 0;
    for (int u = 0; u < parent.size(); ++u)
    {
        if (parent[u] == -1) continue;
        for (auto edge : adj[u])
        {
            int v = edge.first;
            int w = edge.second;
            if (v == parent[u])
                sum += w;
        }
    }
    return sum;
}

void primMST(unordered_map<int, list<pair<int, int>>> &adj, int V)
{
    vector<int> key(V, INT_MAX);
    vector<bool> mstSet(V, false);
    vector<int> parent(V, -1);

    key[0] = 0;

    while (true)
    {
        int u = getMinValueNode(key, mstSet);

        if (u == -1)
            break;

        mstSet[u] = true;

        for (auto &edge : adj[u])
        {
            int v = edge.first;
            int weight = edge.second;
            if (!mstSet[v] && weight < key[v])
            {
                key[v] = weight;
                parent[v] = u;
            }
        }
    }

    int mstSum = getMSTSum(parent, adj);
    cout << "Sum of weights of MST is: " << mstSum << endl;
    printMST(parent, adj, V);
}

int main()
{
    int V = 5;
    // Define the adjacency list using an unordered_map
    unordered_map<int, list<pair<int, int>>> adjList;
    // Add edges to the adjacency list
    adj[0].push_back({1, 2});
    adj[0].push_back({3, 6});
    adj[1].push_back({0, 2});
    adj[1].push_back({2, 3});
    adj[1].push_back({3, 8});
    adj[1].push_back({4, 5});
    adj[2].push_back({1, 3});
    adj[2].push_back({4, 7});
    adj[3].push_back({0, 6});
    adj[3].push_back({1, 8});
    adj[3].push_back({4, 9});
    adj[4].push_back({1, 5});
    adj[4].push_back({2, 7});
    adj[4].push_back({3, 9});

    primMST(adjList, V);

    return 0;
}

//INPUT
    2       3
0-------1-------2
| \     | \     |
|  \    |  \    |
|   \   |   \   |
|    \  |    \  |
|     \ |     \ |
6       8       7
|       |       |
|       |       |
|       |       |
|       |       |
3-------4-------3
    9       5


//MST
    2       3
0-------1-------2
|               |
|               |
|               |
|               |
|               |
6               5
|               
|               
|               
|               
3-------4        