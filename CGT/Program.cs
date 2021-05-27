using System;
using System.Collections.Generic;
using CGT.Algorithms;
using CGT.Models;

namespace CGT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> verticesList = new List<String>();
            verticesList.Add("A");
            verticesList.Add("B");
            verticesList.Add("C");
            verticesList.Add("D");
            verticesList.Add("E");

            GraphGeo g = new GraphGeo(verticesList);
            g.calculateAllEdges();
            g.computeAdjacentDegree();
            g.displayGraph();



            Graph g2 = new Graph(verticesList);
            g2.addEdge("A", "E");
            g2.addEdge("A", "B");
            g2.addEdge("B", "C");
            g2.addEdge("C", "A");
            g2.addEdge("D", "E");
            g2.displayGraph();
            DSatur dSatur = new DSatur(g2);
            dSatur.colorGraph();
            Console.Write(dSatur.getColorCount());
        }
    }
}
