// Bellman Ford Algorithm
// n-1 find the shortest path from source to all other vertices
// ek or bar chalado relaxation and agar distance update hua toh negative cycle hai
// reason to iterate n-1 times is that the longest path in a graph can be n-1 matlab ek vertex se dusre vertex tak n-1 edges hongi jiski wajah se n-1 iteration me saare vertices tak ka shortest path mil jata hai

#include <iostream>
#include <unordered_map>
#include <list>
#include <vector>
#include <climits>

using namespace std;

class Graph
{
    int V;
    unordered_map<int, list<pair<int, int>>> adjList;

public:
    Graph(int V)
    {
        this->V = V;
    }

    void addEdge(int u, int v, int w)
    {
        adjList[u].push_back(make_pair(v, w));
    }

    void bellmanFord(int src)
    {
        vector<int> dist(V, INT_MAX);
        dist[src] = 0;

        for (int i = 1; i < V; i++)
        {
            for (auto srcEdges : adjList)
            {
                for (auto edge : srcEdges.second)
                {
                    int u = srcEdges.first;
                    int v = edge.first;
                    int weight = edge.second;
                    if (dist[u] != INT_MAX && dist[u] + weight < dist[v])
                    {
                        dist[v] = dist[u] + weight;
                    }
                }
            }
        }

        int flag = 0;
        for (auto srcEdges : adjList)
        {
            for (auto edge : srcEdges.second)
            {
                int u = srcEdges.first;
                int v = edge.first;
                int weight = edge.second;
                if (dist[u] != INT_MAX && dist[u] + weight < dist[v])
                {
                    flag = 1;
                    dist[v] = dist[u] + weight;
                }
            }
        }

        if (flag)
        {
            cout << "Graph contains negative cycle" << endl;
            return;
        }

        for (int i = 0; i < V; i++)
        {
            cout << "Distance from source " << src << " to vertex " << i << " is " << dist[i] << endl;
        }
    }
};

int main()
{
    int V = 5;
    Graph g(V);

    g.addEdge(0, 1, -1);
    g.addEdge(0, 2, 4);
    g.addEdge(1, 2, 3);
    g.addEdge(1, 3, 2);
    g.addEdge(1, 4, 2);
    g.addEdge(3, 2, 5);
    g.addEdge(3, 1, 1);
    g.addEdge(4, 3, -3);

    g.bellmanFord(0);

    return 0;
}
/*
Example Graph:
    0
   /|\
  / | \
1  2   3
 |  |  |
4   5  6

Edges with weights:
0 -> 1 (4)
0 -> 2 (1)
0 -> 3 (5)
1 -> 4 (1)
2 -> 5 (2)
3 -> 6 (3)
4 -> 5 (3)
5 -> 6 (1)
*/

Graph exampleGraph(7);
exampleGraph.addEdge(0, 1, 4);
exampleGraph.addEdge(0, 2, 1);
exampleGraph.addEdge(0, 3, 5);
exampleGraph.addEdge(1, 4, 1);
exampleGraph.addEdge(2, 5, 2);
exampleGraph.addEdge(3, 6, 3);
exampleGraph.addEdge(4, 5, 3);
exampleGraph.addEdge(5, 6, 1);

exampleGraph.bellmanFord(0);