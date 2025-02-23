// this alos is used in finding the strongly connected components in a graph

// A Strongly Connected Component (SCC) of a directed graph is a maximal subgraph in which every node is reachable from every other node in that subgraph.

// Examples :
// 1. In a social network, a group of people who all know each other
// 2. In a computer network, a group of computers that can all communicate with each other
// 3. In a transportation network, a group of cities that are all connected by roads or railways
// 4. In a supply chain, a group of companies that are all linked by the flow of goods or services
// 5. In a financial network, a group of banks that are all connected by transactions

// Interconnected cities problem statment
//  Given a list of cities and the roads connecting them, find the strongly connected components in the network.
//  A strongly connected component is a group of cities where there is a path between every pair of cities in the group.
//  For example, if there are cities A, B, and C, and there are roads connecting A to B, B to C, and C to A, then A, B, and C form a strongly connected component.
//  The goal is to find all the strongly connected components in the network and return the number of cities in each component.
//  Input
//  The input to the function consists of three arguments:
//  numCities, an integer representing the number of cities in the network;
//  cities, a list of strings representing the names of the cities;
//  roads, a list of pairs of strings representing the roads connecting the cities.
//  Output
//  The function should return a list of integers representing the number of cities in each strongly connected component.
//  Note
//  The cities are uniquely identified by their names, and the roads are bidirectional.
//  Example
//  Input:
//  numCities = 5
//  cities = ["A", "B", "C", "D", "E"]
//  roads = [["A", "B"], ["B", "C"], ["C", "A"], ["D", "E"]]
//  Output:
//  [3, 2]
//  Explanation:
//  In this case, there are two strongly connected components: A, B, and C form one component, and D and E form the other component.
//  Approach
//  To find the strongly connected components in the network, we can use the Kosaraju's algorithm. The algorithm consists of the following steps:
//  1. Create an adjacency list representation of the graph using the given roads.
//  2. Perform a depth-first search (DFS) on the graph to find the finishing times of each vertex.
//  3. Reverse the graph by reversing the direction of each edge.
//  4. Perform another DFS on the reversed graph, starting from the vertices with the highest finishing times from step 2.
//  5. The vertices visited in step 4 form a strongly connected component.
//  6. Repeat steps 4 and 5 until all vertices are visited.
//  7. Count the number of vertices in each strongly connected component.
//  The time complexity of the Kosaraju's algorithm is O(V + E), where V is the number of vertices and E is the number of edges in the graph.
//  Let's implement the solution in code:
//  C++

#include <iostream>
#include <vector>
#include <unordered_map>
#include <list>
#include <stack>
#include <algorithm>

using namespace std;

void dfs(int node, unordered_map<string, list<string>> &adj, unordered_map<string, bool> &visited, stack<string> &finishStack)
{
    visited[node] = true;
    for (auto neighbor : adj[node])
    {
        if (!visited[neighbor])
        {
            dfs(neighbor, adj, visited, finishStack);
        }
    }
    finishStack.push(node);
}

void reverseDfs(int node, unordered_map<string, list<string>> &adj, unordered_map<string, bool> &visited, vector<string> &component)
{
    visited[node] = true;
    component.push_back(node);
    for (auto neighbor : adj[node])
    {
        if (!visited[neighbor])
        {
            reverseDfs(neighbor, adj, visited, component);
        }
    }
}

vector<int> findStronglyConnectedComponents(int numCities, vector<string> &cities, vector<pair<string, string>> &roads)
{
    unordered_map<string, list<string>> adj;
    for (auto road : roads)
    {
        adj[road.first].push_back(road.second);
    }

    unordered_map<string, bool> visited;
    stack<string> finishStack;

    for (auto city : cities)
    {
        if (!visited[city])
        {
            dfs(city, adj, visited, finishStack);
        }
    }

    unordered_map<string, list<string>> reversedAdj;
    for (auto road : roads)
    {
        reversedAdj[road.second].push_back(road.first);
    }

    for (auto &entry : visited)
    {
        entry.second = false;
    }

    vector<int> result;
    while (!finishStack.empty())
    {
        string node = finishStack.top();
        finishStack.pop();
        if (!visited[node])
        {
            vector<string> component;
            reverseDfs(node, reversedAdj, visited, component);
            result.push_back(component.size());
        }
    }

    return result;
}

int main()
{
    int numCities = 5;
    vector<string> cities = {"A", "B", "C", "D", "E"};
    vector<pair<string, string>> roads = {{"A", "B"}, {"B", "C"}, {"C", "A"}, {"D", "E"}};

    vector<int> scc = findStronglyConnectedComponents(numCities, cities, roads);

    for (int size : scc)
    {
        cout << size << " ";
    }

    return 0;
}

// Genral Algo
//  1.Store topo order of graph using dfs1
//  2.Reverse the graph by creating a new graph with reverse edges of the original graph from u->v to v->u
//  3.Using the topo order of the graph created in step 1, do a dfs on the reversed graph and store the connected components
//  4. Return the connected components
//  5. Done
//  Time complexity is O(V+E) where V is the number of vertices and E is the number of edges in the graph.
//  Space complexity is O(V+E) where V is the number of vertices and E is the number of edges in the graph.

// The code for the above approach is as follows:
// C++
class Graph
{
private:
    unordered_map<int, list<int>> adjList;
    int V;

    void dfs1(int src, vector<bool> &visited, stack<int> &topoOrder)
    {
        visited[src] = true;
        for (int neighbor : adjList[src])
        {
            if (!visited[neighbor])
            {
                dfs1(neighbor, visited, topoOrder);
            }
        }
        topoOrder.push(src);
    }
    void dfs2(int src, unordered_map<int, list<int>> &reversedAdjList, vector<bool> &visited, vector<int> &component)
    {
        visited[src] = true;
        component.push_back(src);
        for (int neighbor : reversedAdjList[src])
        {
            if (!visited[neighbor])
            {
                dfs2(neighbor, reversedAdjList, visited, component);
            }
        }
    }

public:
    Graph(int V)
    {
        this->V = V;
    }

    void addEdge(int u, int v, bool directed = false)
    {
        adjList[u].push_back(v);
        if (directed)
        {
            adjList[v].push_back(u);
        }
    }
    int getStronglyConnectedComponents()
    {
        stack<int> topoOrder;
        vector<bool> visited(V, false);
        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                dfs1(i, visited, topoOrder);
            }
        }

        unordered_map<int, list<int>> reversedAdjList;
        for (auto srcEdges : adjList)
        {
            int u = srcEdges.first;
            for (int v : srcEdges.second)
            {
                reversedAdjList[v].push_back(u);
            }
        }

        for (int i = 0; i < V; i++)
        {
            visited[i] = false;
        }

        vector<vector<int>> connectedComponents;
        int count = 0;

        while (!topoOrder.empty())
        {
            int src = topoOrder.top();
            topoOrder.pop();
            if (!visited[src])
            {
                vector<int> component;
                dfs2(src, reversedAdjList, visited, component);
                connectedComponents.push_back(component);
                count++;
            }
        }
        return count;
    }
};
