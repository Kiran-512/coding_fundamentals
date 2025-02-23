#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

// Function to add an edge to the edges list
void addEdge(vector<vector<int>> &edges, int src, int dest, int weight)
{
    edges.push_back({src, dest, weight});
}

// Function to find the parent of a node with path compression
int findParent(vector<int> &parent, int node) // if src node is 3 and parent of 3 is 2 and parent of 2 is 1 then parent of 3 will be 1 as base condition is parent of node is node itself, which in this case is 1
{
    if (parent[node] != node)
    {
        parent[node] = findParent(parent, parent[node]); // Path compression
    }
    return parent[node];
}
// Initial Parent Array
// Parent array: {0, 1, 2, 3}

// Union Operations to Set Up the Parent Array

// Union(2, 1):
// findParent(parent, 2) returns 2.
// findParent(parent, 1) returns 1.
// Union operation sets parent[2] = 1.
// Parent array: {0, 1, 1, 3}

// Union(3, 2):
// findParent(parent, 3) returns 3.
// findParent(parent, 2) returns 1 (after path compression).
// Union operation sets parent[3] = 1.
// Parent array: {0, 1, 1, 1}

// Function to perform union of two sets
void unionSet(vector<int> &parent, vector<int> &rank, int u, int v)
{
    u = findParent(parent, u);
    v = findParent(parent, v);
    // calling these findParent is not required here as we are already calng it in the above function

    if (rank[u] < rank[v]) // jis bhi node ki rank jyada ho usiko parent bana do and usi node ki rank ko bhi badha do!
    {
        parent[u] = v;
        rank[v]++;
    }
    else //>= condition which means if both are equal then also we will make u as parent of v, we can make v as parent of u also as both are equal and es case me ham kisiko bhi parent bana sakte hai!
    {
        parent[v] = u;
        rank[u]++;
    }
}

// Function to perform Kruskal's algorithm to find the Minimum Spanning Tree (MST)
void kruskalMST(int V, const unordered_map<int, pair<int, int>> &edgeList)
{
    // Convert unordered_map to vector of edges
    vector<vector<int>> edges;
    for (const auto &entry : edgeList)
    {
        int u = entry.first;
        int v = entry.second.first;
        int w = entry.second.second;
        addEdge(edges, u, v, w);
    }
    
    
    // Sort edges based on their weight as we have to start with the smallest edge
    sort(edges.begin(), edges.end(), [](const vector<int> &a, const vector<int> &b)
    { return a[2] < b[2]; });

    // Initialize parent and rank vectors
    vector<int> parent(V);
    vector<int> rank(V, 0);

    // Initialize each vertex to be its own parent
    for (int u = 0; u < V; ++u)
    {
        parent[u] = u;
    }

    // Iterate through the sorted edges and construct the MST
    int mstWeight = 0;
    for (const auto &nextEdge : edges)
    {
        int u = nextEdge[0];
        int v = nextEdge[1];
        int weight = nextEdge[2];

        u = findParent(parent, u);
        v = findParent(parent, v);

        if (u != v)
        {
            // If u and v both are in the diff components so merge them
            unionSet(parent, rank, u, v);
            mstWeight += weight;
        }
        else
        {
            // ignore
        }
    }

    // Uncomment the following lines to print the edges in the constructed MST
    // cout << "Edges in the constructed MST:\n";
    // for (const auto &edge : result)
    // {
    //     cout << edge[0] << " -- " << edge[1] << " == " << edge[2] << endl;
    // }
}

int main()
{
    int V = 4; // Number of vertices in graph
    unordered_map<int, pair<int, int>> edgeList = {
        {0, {1, 10}},
        {0, {2, 6}},
        {0, {3, 5}},
        {1, {3, 15}},
        {2, {3, 4}}};

    // Call Kruskal's algorithm to find the MST
    kruskalMST(V, edgeList);

    return 0;
}

// Algorithm steps for above code in indian guy context:
//  1. Sort all the edges in non-decreasing order of their weight.
//  2. Pick the smallest edge. find the parent of the source and destination of the edge.
//  3. If the parent of the source and destination is same then ignore the edge.
//  4. If the parent of the source and destination is different then merge them and add the weight of the edge to the mstWeight.
//  5. Repeat step 2 to 4 until all the edges are visited.

// unionSet
//  1. Find the parent of u and v. not required as we are already calling it in the above function
//  2. If the rank of u is less than the rank of v then make u as the parent of v and increase the rank of v.
//  3. If the rank of u is greater than or equal to the rank of v then make v as the parent of u and increase the rank of u
//  4. If the rank of u and v is equal then make u as the parent of v and increase the rank of v.

// find parent
//  1. If the parent of the node is not the node itself then find the parent of the parent of the node.
//  2. Return the parent of the node.
//  3. If the parent of the node is the node itself then return the node.
