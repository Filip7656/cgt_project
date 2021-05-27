using System;
using System.Collections.Generic;

namespace CGT.Models
{
    public class GraphGeo
    {
        public Dictionary<String, Vertex> vertices;
        private static int MAX_RAND_VAL = 6;

        private Dictionary<String, List<Vertex>> adjVertices;

        public GraphGeo(List<String> vertexLabel)
        {
            vertices = new Dictionary<String, Vertex>();
            adjVertices = new Dictionary<String, List<Vertex>>();
            foreach (String label in vertexLabel)
            {
                if (!addNewVertex(label))
                {
                    throw new Exception("CANT ADD MORE VERTICES THAN MAX_RAND_VAL^2");
                }
            }
        }

        public void calculateAllEdges()
        {
            foreach (Vertex v1 in vertices.Values)
            {
                foreach (Vertex v2 in vertices.Values)
                {
                    addEdge(v1.getLabel(), v2.getLabel());
                }
            }
        }

        public bool addNewVertex(String label)
        {
            Random r = new Random();
            Vertex v = new Vertex(label, r.Next(MAX_RAND_VAL), r.Next(MAX_RAND_VAL));
            if (validateVertex(v))
            {
                vertices.Add(label, v);
                adjVertices.Add(label, new List<Vertex>());
                return true;
            }
            else
            {
                if (vertices.Values.Count == MAX_RAND_VAL * MAX_RAND_VAL)
                {
                    return false;
                }
                return addNewVertex(label);
            }
        }

        public bool addNewVertex(Vertex v)
        {
            if (validateVertex(v))
            {
                vertices.Add(v.getLabel(), v);
                adjVertices.Add(v.getLabel(), new List<Vertex>());
                return true;
            }
            return false;
        }

        public bool validateVertex(Vertex v)
        {
            foreach (Vertex v1 in vertices.Values)
            {
                if (v.getX() == v1.getX() && v.getY() == v1.getY())
                {
                    return false;
                }
            }
            return true;
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

        private void validateVertex(String vertexLabel)
        {
            if (!vertices.ContainsKey(vertexLabel))
                throw new Exception("Illegal vertex: " + vertexLabel);

        }

        public void addEdge(String from, String to)
        {
            validateVertex(from);
            validateVertex(to);
            double dist = vertices[from].calculateDistance(vertices[to]);
            if (dist >= 1 && dist <= 2)
            {
                if (!adjVertices[from].Contains(vertices[to])
                        && !adjVertices[to].Contains(vertices[to]))
                {
                    adjVertices[from].Add(vertices[to]);
                    adjVertices[to].Add(vertices[from]);
                }

            }

        }

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


        public void displayGraph()
        {
            Console.WriteLine("Graph geo");
            foreach (var i in adjVertices)
            {
                Console.Write(i.Key);
                Console.Write("--> [");
                i.Value.ForEach((a) => Console.Write(a.ToString()));
                Vertex v = vertices[i.Key];
                Console.Write("] adj degree --> " + v.getAdjDegree());
                Console.Write(" X:" + vertices[i.Key].getX());
                Console.Write(" Y:" + vertices[i.Key].getY());
                Console.WriteLine();
            }
        }

        override
    public String ToString()
        {
            return "graphGeo";
        }
    }
}
