#include <iostream>
#include <vector>
#include <set>
#include <utility>
#include <limits>
#include <unordered_map>
#include <list>

using namespace std;

const int INF = INT_MAX; // Define infinity as the maximum value of an integer

// Function to perform Dijkstra's algorithm
void dijkstra(const unordered_map<int, list<pair<int, int>>> &graph, int source, vector<int> &dist)
{
    int n = graph.size(); // Number of vertices in the graph
    dist.assign(n, INF);  // Initialize distances with infinity
    dist[source] = 0;     // Distance to the source is 0

    set<pair<int, int>> active_vertices; // Set to store active vertices
    active_vertices.insert({0, source}); // Insert the source vertex with distance 0

    while (!active_vertices.empty())
    {
        int u = active_vertices.begin()->second;   // Get the vertex with the smallest distance
        active_vertices.erase(active_vertices.begin()); // Remove it from the set

        // Iterate over all adjacent vertices
        for (auto edge : graph.at(u))
        {
            int w = edge.first;   // Edge weight
            int v = edge.second; // Adjacent vertex

            // Relaxation step
            if (dist[u] + w < dist[v]) // not greedy because of this condition as greedy algo will always choose the smallest edge
            {
                active_vertices.erase({dist[v], v});  // Remove the old distance
                dist[v] = dist[u] + w;                // Update with the new distance
                active_vertices.insert({dist[v], v}); // Insert the new distance
            }
        }
    }
}

int main()
{
    int n = 5; // Number of vertices
    int m = 6; // Number of edges

    unordered_map<int, list<pair<int, int>>> graph; // Adjacency list representation of the graph

    // Edges (u, v, w)
    graph[0].push_back({10, 1});
    graph[0].push_back({3, 2});
    graph[1].push_back({1, 2});
    graph[1].push_back({2, 3});
    graph[2].push_back({4, 3});
    graph[3].push_back({2, 4});
    graph[4].push_back({6, 0});

    int source = 0; // Source vertex

    vector<int> dist; // Vector to store distances from the source
    dijkstra(graph, source, dist);

    cout << "Distances from source vertex " << source << " to each vertex:" << endl;
    for (int i = 0; i < n; ++i)
    {
        cout << "Vertex " << i << ": " << dist[i] << endl;
    }
    return 0;
}

// limitations of dijkstra
//  1. Dijkstra's algorithm does not work for graphs with negative cycles as ye fas jata hai infinite loop me.
//  2. Dijkstra's algorithm does not work for graphs with disconnected components.
//  3. Dijkstra's algorithm does work for graphs with negative edge weights where there's no cycle!

// Negative cycle means a cycle in the graph where the sum of the weights of the edges is negative.
