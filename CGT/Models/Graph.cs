using System;
using System.Collections.Generic;

namespace CGT.Models
{
    public class Graph
    {

        public Dictionary<String, Vertex> vertices { get; set; }

        private Dictionary<String, List<Vertex>> adjVertices { get; set; }

        public Graph(List<String> vertexLabel)
        {
            vertices = new Dictionary<String, Vertex>();
            adjVertices = new Dictionary<String, List<Vertex>>();
            foreach (String label in vertexLabel)
            {
                AddNewVertex(label);
            }
        }


        public List<Vertex> getVertices()
        {
            return new List<Vertex>(vertices.Values);
        }

        public List<Vertex> getAdjacentVertices(Vertex v)
        {
            return getAdjacentVertices(v.getLabel());
        }

        public List<Vertex> getAdjacentVertices(String vertexLabel)
        {
            return adjVertices[vertexLabel];
        }

        public bool AddNewVertex(String label)
        {

            Vertex v = new Vertex(label);
            vertices.Add(label, v);
            adjVertices.Add(label, new List<Vertex>());
            return true;
        }

        private void validateVertex(String vertexLabel)
        {
            if (!vertices.ContainsKey(vertexLabel))
                throw new Exception("Illegal vertex: " + vertexLabel);

        }

        // add edge between two vertices.
        public void addEdge(String from, String to)
        {
            validateVertex(from);
            validateVertex(to);
            adjVertices[from].Add(vertices[to]);
            adjVertices[to].Add(vertices[from]);
        }

        // compute adjacent degree for each vertex.
        public void computeAdjacentDegree()
        {
            foreach (var i in adjVertices)
            {
                String vertexLabel = i.Key;
                List<Vertex> adjList = i.Value;
                int adjDegree = adjList.Count;
                vertices[vertexLabel].setAdjDegree(adjDegree);
            }
        }

        // function to print out graph,adjacent and saturation degree
        public void displayGraph()
        {
            Console.WriteLine("Graph");

            foreach (var i in adjVertices)
            {
                Console.Write(i.Key);
                Console.Write("--> [");
                i.Value.ForEach((a) => Console.Write(a.getLabel()));
                Vertex v = vertices[i.Key];
                Console.Write("] adj degree --> " + v.getAdjDegree());
                Console.Write(", sat degree --> " + v.getSatDegree());
                Console.WriteLine();
            }
        }

        override
          public String ToString()
        {
            return "graph";
        }

    }
}
