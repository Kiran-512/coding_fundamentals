/*
Problem: Clone a Graph

Given a reference of a node in a connected undirected graph, return a deep copy (clone) of the graph. Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.

class Node {
public:
    int val;
    vector<Node*> neighbors;
};

Test case format:

For simplicity, each node's value is the same as the node's index (1-indexed). For example, if there are 3 nodes in the graph, the first node will have value 1, the second node will have value 2, and the third node will have value 3. The graph is represented in the test case using an adjacency list.

An adjacency list is a collection of unordered lists used to represent a finite graph. Each list describes the set of neighbors of a node in the graph.

The given node will always be the first node with value 1. You must return the copy of the given node as a reference to the cloned graph.
*/

