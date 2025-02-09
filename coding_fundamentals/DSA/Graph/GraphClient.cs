using System;
using System.Collections.Generic;
using System.Text;

namespace All.Design.Patterns.DSA.Graph
{
    public class GraphClient
    {
        public static void Main1() {
            GraphNode g = new GraphNode();
            g.AddEdge(0,1);
            g.AddEdge(1,2);
            g.AddEdge(2,3);
            g.AddEdge(1,3);

            g.PrintEdgeList();
            Console.ReadLine();
        }
    }
}
