#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

void addEdge(vector<vector<int>> &edges, int src, int dest, int weight)
{
    edges.push_back({src, dest, weight});
}

int findParent(vector<int> &parent, int node)
{
    if (parent[node] != node)
    {
        parent[node] = findParent(parent, parent[node]); // Path compression
    }
    return parent[node];
}

void unionSet(vector<int> &parent, vector<int> &rank, int u, int v)
{
    u = findParent(parent, u);
    v = findParent(parent, v);

    if (rank[u] < rank[v])
    {
        parent[u] = v;
        rank[v]++;
    }
    else
    {
        parent[v] = u;
        rank[u]++;
    }
}

void kruskalMST(int V, const vector<vector<int>> &edges)
{
    // vector<vector<int>> result;
    vector<int> parent(V);
    vector<int> rank(V, 0);

    sort(edges.begin(), edges.end(), [](const vector<int> &a, const vector<int> &b)
         { return a[2] < b[2]; });

    for (int u = 0; u < V; ++u)
    {
        parent[u] = u;
    }

    for (const auto &nextEdge : edges)
    {
        int u = nextEdge[0];
        int v = nextEdge[1];
        int weight = nextEdge[2];

        u = findParent(parent, u);
        v = findParent(parent, v);

        int mstWeight = 0;
        if (u != v)
        {
            // result.push_back(nextEdge);
            unionSet(parent, rank, u, v);
            mstWeight += weight;
        }
    }

    // cout << "Edges in the constructed MST:\n";
    // for (const auto &edge : result)
    // {
    //     cout << edge[0] << " -- " << edge[1] << " == " << edge[2] << endl;
    // }
}

int main()
{
    int V = 4; // Number of vertices in graph
    vector<vector<int>> inputEdges = {
        {0, 1, 10},
        {0, 2, 6},
        {0, 3, 5},
        {1, 3, 15},
        {2, 3, 4}};

    kruskalMST(V, inputEdges);

    return 0;
}
