// this workds for undirected graph only, for directed graph we need to check for back edge
//  Bridges are the edges in a graph that if removed, increase the number of connected components in the graph.
//
//  To find the bridges in a graph, we can use the brute force approach of removing each edge and checking if the graph is still connected. If the graph is not connected after removing an edge, then that edge is a bridge.
//
//  The time complexity of this approach is O(V*(V+E)), where V is the number of vertices and E is the number of edges in the graph.

#include <iostream>
#include <vector>
#include <list>
#include <unordered_map>
#include <utility>

using namespace std;

class Graph
{
    int V;                             // Number of vertices
    unordered_map<int, list<int>> adj; // Adjacency list

public:
    Graph(int V);
    void addEdge(int v, int w);
    void removeEdge(int v, int w);
    void DFS(int v, unordered_map<int, bool> &visited);
    bool isConnected();
    void findBridgesBruteForce();
    void findBridgesUtil();
    void findBridges();
};

Graph::Graph(int V)
{
    this->V = V;
}

void Graph::addEdge(int u, int v)
{
    adj[u].push_back(v);
    adj[v].push_back(u);
}

void Graph::removeEdge(int v, int w)
{
    adj[u].remove(v);
    adj[v].remove(u);
}

void Graph::DFS(int src, unordered_map<int, bool> &visited)
{
    visited[src] = true;
    for (auto v : adj[src])
        if (!visited[v])
            DFS(v, visited);
}

bool Graph::isConnected()
{
    // Create a map to keep track of visited nodes
    unordered_map<int, bool> visited;

    // Initialize all nodes as not visited
    for (auto &pair : adj)
        visited[pair.first] = false;

    int nonIsolatedVertex = -1;
    // Find the first vertex with edges (non-isolated vertex)
    for (auto &srcEdges : adj)
    {
        int u = srcEdges.first;
        list<int> neigbhours = srcEdges.second;
        if (neigbhours.size() > 0)
        {
            nonIsolatedVertex = u;
            break;
        }
    }

    // If there are no edges in the graph, it is considered connected
    if (nonIsolatedVertex == -1)
        return true;

    // Perform DFS starting from the first non-isolated vertex
    DFS(u, visited);

    // Check if all vertices with edges are visited
    for (auto &srcEdges : adj)
    {
        int u = srcEdges.first;
        list<int> neigbhours = srcEdges.second;
        if (!visited[u] && neigbhours.size() > 0)
            return false; // If any vertex with edges is not visited, graph is not connected
    }
    // If all vertices with edges are visited, graph is connected
    return true;
}

void Graph::findBridgesBruteForce()
{
    for (auto &srcEdges : adj)
    {
        int u = srcEdges.first;
        for (auto &v : srcEdges.second)
        {
            removeEdge(u, v);
            if (!isConnected())
                cout << u << " " << v << endl;
            addEdge(u, v);
        }
    }
}
// Utility function to find bridges using DFS traversal
/**
 * @brief A utility function to find bridges in a graph using DFS traversal.
 *
 * This function is a part of the Graph class and is used to find all the bridges in the graph.
 * A bridge is an edge in a graph whose removal increases the number of connected components.
 *
 * @param u The current vertex being visited.
 * @param visited A map to keep track of visited vertices.
 * @param tin A map to store the discovery times of visited vertices.
 *            tin[u] represents the discovery time of vertex u.
 * @param low A map to store the lowest discovery time reachable from the subtree rooted with the vertex.
 *            low[u] represents the lowest discovery time reachable from vertex u.
 * @param timer A counter to keep track of the discovery time of vertices.
 * @param parent The parent vertex of the current vertex u.
 */
void Graph::findBridgesUtil(int u, unordered_map<int, bool> &visited, unordered_map<int, int> &tin, unordered_map<int, int> &low, int &timer, int parent)
{
    visited[u] = true;         // Mark the current node as visited
    tin[u] = low[u] = timer++; // Initialize discovery time and low value

    // Iterate through all the vertices adjacent to this vertex
    for (int v : adj[u])
    {
        if (v == parent) // If v is the parent of u, ignore it
            continue;
        if (!visited[v])
        {
            // If v is not visited, recur for it
            findBridgesUtil(v, visited, tin, low, timer, u);
            // Check if the subtree rooted at v has a connection back to one of the ancestors of u
            low[u] = min(low[u], low[v]);

            // If the lowest vertex reachable from subtree under v is below u in DFS tree, then u-v is a bridge
            if (low[v] > tin[u])
                cout << u << " " << v << endl;
        }
        else
        {
            // Update low value of u for parent function calls
            low[u] = min(low[u], tin[v]);
        }
    }
}

// Function to find bridges in the graph
void Graph::findBridges()
{
    unordered_map<int, bool> visited; // To keep track of visited vertices
    unordered_map<int, int> tin;      // To store discovery times of visited vertices
    unordered_map<int, int> low;      // To store the lowest discovery times reachable from the subtree
    int timer = 0;                    // Timer to keep track of discovery times

    // Initialize the visited, tin, and low arrays
    for (auto &pair : adj)
    {
        int u = pair.first;
        if (!visited[u])
            findBridgesUtil(u, visited, tin, low, timer, -1); // Call the recursive helper function to find bridges
    }
}
int main()
{
    Graph g(5);
    g.addEdge(0, 1);
    g.addEdge(0, 2);
    g.addEdge(1, 2);
    g.addEdge(1, 3);
    g.addEdge(3, 4);

    cout << "Bridges in the graph:\n";
    g.findBridgesBruteForce();

    return 0;
}