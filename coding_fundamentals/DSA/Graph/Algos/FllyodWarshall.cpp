#include <iostream>
#include <vector>
#include <limits.h>
#include <unordered_map>
#include <list>

using namespace std;

#define V 4
#define MAXI 1e9

void printSolution(vector<vector<int>> &dist);

void floydWarshall(unordered_map<int, list<pair<int, int>>> &graph)
{
    vector<vector<int>> dist(V, vector<int>(V, MAXI));

    // Initialize the diagonal elements to 0 as  the distance from a vertex to itself is 0
    for (int i = 0; i < V; i++)
        dist[i][i] = 0;

    // Initialize the distance matrix with the weights of the edges
    for (auto &srcEdges : graph)
    {
        for (auto &edge : srcEdges.second)
        {
            int u = srcEdges.first;
            int v = edge.first;
            int weight = edge.second;
            dist[u][v] = weight;
        }
    }

    // Floyd Warshall Algorithm
    // Pick all vertices as intermediate one by one and update all shortest
    for (int helper = 0; helper < V; helper++)
    {
        // Pick all vertices as source one by one and update all shortest paths
        for (int src = 0; src < V; src++)
        {
            // Pick all vertices as destination one by one and update all shortest paths
            for (int dest = 0; dest < V; dest++)
            {
                // If vertex k is on the shortest path from src to dest, then update the value of dist[src][dest], what is k? k is the helper vertex but its helper right? so we are checking if the path from src to dest is shorter if we go through the helper
                dist[src][dest] = min(dist[src][dest], dist[src][helper] + dist[helper][dest]);
            }
        }
    }

    printSolution(dist);
}

void printSolution(vector<vector<int>> &dist)
{
    cout << "The following matrix shows the shortest distances"
            " between every pair of vertices \n";
    for (int i = 0; i < V; i++)
    {
        for (int j = 0; j < V; j++)
        {
            if (dist[i][j] == MAXI)
                cout << "INF" << "     ";
            else
                cout << dist[i][j] << "     ";
        }
        cout << endl;
    }
}

int main()
{
    unordered_map<int, list<pair<int, int>>> graph;
    graph[0].push_back({1, 5});
    graph[0].push_back({3, 10});
    graph[1].push_back({2, 3});
    graph[2].push_back({3, 1});

    floydWarshall(graph);
    return 0;
}
// OUTPUT
//  The following matrix shows the shortest distances between every pair of vertices
//  0     5     8     9
//  INF     0     3     4
//  INF     INF     0     1
//  INF     INF     INF     0
//  Compare this snippet from coding_fundamentals/DSA/Graph/problems/cloneGraph.cpp:
