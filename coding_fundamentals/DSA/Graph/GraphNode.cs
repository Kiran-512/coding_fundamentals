using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace All.Design.Patterns.DSA.Graph
{
    public class GraphNode
    {
        public Dictionary<int, List<int>> adjUnWeightedList;
        public Dictionary<int, List<KeyValuePair<int, int>>> adjWeightNodeList;

        public GraphNode()
        {
            adjUnWeightedList = new Dictionary<int, List<int>>();
        }
        public void AddEdge(int u, int v, bool isDirected = false)
        {
            if (isDirected)//u->v
            {
                if (!adjUnWeightedList.TryGetValue(u, out var list))
                {
                    list = new List<int>();
                    adjUnWeightedList[u] = list;
                }
                adjUnWeightedList[u].Add(v);
                return;
            }
            //u-> and v->u
            if (!adjUnWeightedList.TryGetValue(u, out var edglist))
            {
                edglist = new List<int>();
                adjUnWeightedList[u] = edglist;
            }
            edglist.Add(v);

            if (!adjUnWeightedList.TryGetValue(v, out edglist))
            {
                edglist = new List<int>();
                adjUnWeightedList[v] = edglist;
            }
            edglist.Add(u);
        }
        public void AddWeightedEdge(int u, int v, int weight, bool isDirected = false)
        {
            if (isDirected)//u->v
            {
                if (!adjWeightNodeList.TryGetValue(u, out var list))
                {
                    list = new List<KeyValuePair<int, int>>();
                    adjWeightNodeList[u] = list;
                }
                adjWeightNodeList[u].Add(new KeyValuePair<int, int>(v, weight));
                return;
            }
            //u-> and v->u
            if (!adjWeightNodeList.TryGetValue(u, out var edglist))
            {
                edglist = new List<KeyValuePair<int, int>>();
                adjWeightNodeList[u] = edglist;
            }
            edglist.Add(new KeyValuePair<int, int>(v, weight));

            if (!adjWeightNodeList.TryGetValue(v, out edglist))
            {
                edglist = new List<KeyValuePair<int, int>>();
                adjWeightNodeList[v] = edglist;
            }
            edglist.Add(new KeyValuePair<int, int>(u, weight));
        }
        public void PrintEdgeList()
        {
            foreach (var item in adjUnWeightedList)
            {
                Console.Write(item.Key + ": {");
                foreach (var edge in item.Value)
                {
                    Console.Write(edge + ",");
                }
                Console.WriteLine("}");
            }
        }
        public void PrintWeightedEdgeList()
        {
            foreach (var item in adjWeightNodeList)
            {
                Console.Write(item.Key + ": {");
                foreach (var edge in item.Value)
                {
                    Console.Write("[" + edge.Key + "," + edge.Value + "]" + ",");
                }
                Console.WriteLine("}");
            }
        }
        public void BFS(int src)
        {
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            Queue<int> q = new Queue<int>();
            q.Enqueue(src);
            visited[src] = true;
            while (q.Count > 0)
            {
                int currentNode = q.Dequeue();
                Console.Write(currentNode + " ");
                foreach (var item in adjUnWeightedList[currentNode])
                {
                    if (!visited[item])
                    {
                        visited[item] = true;
                        q.Enqueue(item);
                    }
                }
            }
        }

        public void DFS(int src, Dictionary<int, bool> visited)
        {
            visited[src] = true;
            Console.Write(src);
            foreach (var child in adjUnWeightedList[src])
            {
                if (!visited[child])
                {
                    DFS(child, visited);
                }
            }
        }

        //undirected graph BFS cycle
        public bool isCyclePresentBFS(int src)
        {
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            Dictionary<int, int> parent = new Dictionary<int, int>();
            Queue<int> q = new Queue<int>();
            q.Enqueue(src);
            visited[src] = true;
            parent[src] = -1;
            while (q.Count > 0)
            {
                int parentEle = q.Dequeue();
                foreach (var child in adjUnWeightedList[src])
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        parent[child] = src;
                        q.Enqueue(child);
                    }
                    else if (parent[parentEle] != child)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool isCyclePresentDFS(int src, Dictionary<int, bool> visited, int parent = -1)
        {
            visited[src] = true;
            foreach (var child in adjUnWeightedList[src])
            {
                if (!visited[child])
                {
                    visited[child] = true;
                    bool ans = isCyclePresentDFS(child, visited, src);
                    if (ans)
                    {
                        return ans;
                    }
                }
                else if (parent != child)
                {
                    return true;
                }
            }
            return false;
        }

        //directed graph cycle Detection
        public bool isCyclePresentDFS(int src, Dictionary<int, bool> visited, Dictionary<int, bool> isInDFS)
        {
            visited[src] = true;
            isInDFS[src] = true;
            foreach (var child in adjUnWeightedList[src])
            {
                if (!visited[child])
                {
                    var ans = isCyclePresentDFS(child, visited, isInDFS);
                    if (ans)
                    {
                        return ans;
                    }
                }
                else if (isInDFS[child])
                {
                    return true;
                }
            }
            //backracking
            isInDFS[src] = false;//f any node is visited and akready in the dfs then there's a cycle!
            return false;
        }

        //topological sort
        public void DFSTopo(int src, Dictionary<int, bool> visited, Stack<int> topoOrder)
        {//Normal DFS chalao and store src in stack in return call
            visited[src] = true;
            foreach (var child in adjUnWeightedList[src])
            {
                if (!visited[child])
                {
                    DFSTopo(child, visited, topoOrder);
                }

            }
            topoOrder.Push(src);
        }
        public void BFSTopo(int V) //Kahn's Algoritham
        {
            //TODO: 
            //FIND INDEGREE OF ALL NODES
            List<int> indegree = new List<int>(); //since here nodes are int so we can directl use the list where index represents the node
            // for other datatypes for node, will haev to make the use of map, where key wll hold the node value and value will hold indegree
            for (int i = 0; i <= V; ++i)
            {
                foreach (var child in adjUnWeightedList[i])
                {
                    ++indegree[child];
                }
            }
            //PUSH ALL Nodes with indegree 0 in the queue

            Queue<int> q = new Queue<int>();
            for (int i = 0; i <= V; i++)
            {
                if (indegree[i] == 0)
                {
                    q.Enqueue(i);
                }
            }
            List<int> topoOrder = new List<int>();

            //jab tak q empty nahi ho jati tab tak 0 indegree wale nodes q me push kardo
            //q se node nikalkar please store in the ans
            while (q.Count != 0)
            {
                int front = q.Dequeue();
                topoOrder.Add(front);
                foreach (var child in adjUnWeightedList[front])
                {
                    --indegree[child];
                    if (indegree[child] == 0)
                    {
                        q.Enqueue(child);
                    }
                }
            }


            foreach (var item in topoOrder)
            {
                Console.Write(item + " ");
            }
        }

        //Shortest Path Algos
        public int BFSShortedPath(int src, int destination)
        {
            //create a distance array
            Dictionary<int, int> distance = new Dictionary<int, int>();

            //create a queue and push the src in the queue
            Queue<int> q = new Queue<int>();
            q.Enqueue(src);

            //create a parent map
            Dictionary<int, int> parents = new Dictionary<int, int>();
            parents[src] = -1;

            //create a visisted map
            Dictionary<int, bool> visisted = new Dictionary<int, bool>();
            visisted[src] = true;


            //find out parents for all child nodes
            while (q.Count > 0)
            {
                int parentEle = q.Dequeue();
                foreach (var child in adjUnWeightedList[parentEle])
                {
                    if (!visisted[child])
                    {
                        parents[child] = parentEle;
                        q.Enqueue(child);
                    }
                }
            }

            //
            int ans = 0;
            while (destination != -1)
            {
                ans += destination;
                destination = parents[destination];
            }
            return ans;
        }
        public void DFSShortedPath(int src)//single source shorted path algo : shorted path of all nodes from a single source node
        
        {
            //DAG -> 
            //src - here src is the node which always has  the indegree 0

            //find the topo order using DFS
            //visited map
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            Stack<int> topoOrder = new Stack<int>();
            DFSTopo(src, visited, topoOrder);

            //iterate on the topo order and using queue set the distance for each neighbour node
            List<int> distance = new List<int>();//distance array could be a map

            src = topoOrder.Pop();

            distance[src] = 0;

            foreach (var child in adjWeightNodeList[src])
            {
                if (distance[src] + child.Value < distance[child.Key])
                {
                    distance[child.Key] = distance[src] + child.Value;
                }
            }

            while (topoOrder.Count > 0)
            {
                src = topoOrder.Pop();
                foreach (var child in adjWeightNodeList[topoOrder.Peek()])
                {
                    if (distance[src] + child.Value < distance[child.Key])
                    {
                        distance[child.Key] = distance[src] + child.Value;
                    }
                }
            }

            //distance array
            int index = 0;
            foreach (var item in distance)
            {
                Console.Write("{ " + index + ": " + +item + " },");
            }
        }
        public void DijkstraShortedPath(int src, int dest, int V)
        {
            if (V <= 0)
            {
                V = adjWeightNodeList.Count;
            }

            //using hashset to make sure I get the node with the smallest distance on top of the stack
            SortedSet<KeyValuePair<int, int>> set = new SortedSet<KeyValuePair<int, int>>();


            //distance array to keep the tack on the distxance of each node, Initialize distances to infinity
            List<int> distance = Enumerable.Repeat(int.MaxValue, V).ToList();

            //add the soruce in the list
            var pair = new KeyValuePair<int, int>(0, src);
            set.Add(pair);

            while (set.Count > 0)
            {
                pair = set.Min;
                set.Remove(pair);// remove that pair because we now have min disntace upto the this node from all toher nodes from the source

                foreach (var child in adjWeightNodeList[pair.Value])
                {
                    if (distance[pair.Value] + child.Key < distance[child.Value])
                    {
                        set.Remove(child);

                        distance[child.Value] = distance[pair.Value] + child.Key;

                        set.Add(new KeyValuePair<int, int>(distance[child.Key], child.Value));
                    }
                }
            }
        }
    }
    public class GraphNode<T>
    {
        public Dictionary<T, List<T>> adjUnWeightedList;
        public Dictionary<T, List<KeyValuePair<T, int>>> adjWeightNodeList;
        public GraphNode()
        {
            adjUnWeightedList = new Dictionary<T, List<T>>();
        }
        public void AddEdge(T u, T v, bool isDirected = false)
        {
            if (isDirected)//u->v
            {
                if (!adjUnWeightedList.TryGetValue(u, out var list))
                {
                    list = new List<T>();
                    adjUnWeightedList[u] = list;
                }
                adjUnWeightedList[u].Add(v);
                return;
            }
            //u-> and v->u
            if (!adjUnWeightedList.TryGetValue(u, out var edglist))
            {
                edglist = new List<T>();
                adjUnWeightedList[u] = edglist;
            }
            edglist.Add(v);

            if (!adjUnWeightedList.TryGetValue(v, out edglist))
            {
                edglist = new List<T>();
                adjUnWeightedList[v] = edglist;
            }
            edglist.Add(u);
        }
        public void AddWeightedEdge(T u, T v, int weight, bool isDirected = false)
        {
            if (isDirected)//u->v
            {
                if (!adjWeightNodeList.TryGetValue(u, out var list))
                {
                    list = new List<KeyValuePair<T, int>>();
                    adjWeightNodeList[u] = list;
                }
                adjWeightNodeList[u].Add(new KeyValuePair<T, int>(v, weight));
                return;
            }
            //u-> and v->u
            if (!adjWeightNodeList.TryGetValue(u, out var edglist))
            {
                edglist = new List<KeyValuePair<T, int>>();
                adjWeightNodeList[u] = edglist;
            }
            edglist.Add(new KeyValuePair<T, int>(v, weight));

            if (!adjWeightNodeList.TryGetValue(v, out edglist))
            {
                edglist = new List<KeyValuePair<T, int>>();
                adjWeightNodeList[v] = edglist;
            }
            edglist.Add(new KeyValuePair<T, int>(u, weight));
        }
        public void PrintEdgeList()
        {
            foreach (var item in adjUnWeightedList)
            {
                Console.Write(item.Key + ": {");
                foreach (var edge in item.Value)
                {
                    Console.Write(edge + ",");
                }
                Console.WriteLine("}");
            }
        }
        public void PrintWeightedEdgeList()
        {
            foreach (var item in adjWeightNodeList)
            {
                Console.Write(item.Key + ": {");
                foreach (var edge in item.Value)
                {
                    Console.Write("[" + edge.Key + "," + edge.Value + "]" + ",");
                }
                Console.WriteLine("}");
            }
        }
    }
}
