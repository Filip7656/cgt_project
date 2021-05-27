using System;
using System.Collections.Generic;
using CGT.Models;

namespace CGT.Algorithms
{
    public class DSatur
    {


        private Graph graph;
        private SortedSet<int> colors;
        private List<Vertex> colorlessVertices;
        public List<Vertex> initialVertices;

        public DSatur(Graph graph)
        {
            this.graph = graph;
            this.colors = new SortedSet<int>();
            this.colorlessVertices = graph.getVertices();
            this.initialVertices = graph.getVertices();
        }

        // get total number of colors used.
        public int getColorCount()
        {
            return colors.Count;
        }

        private void calculateSaturationDegree(List<Vertex> inputVertices)
        {

            foreach (Vertex v in inputVertices)
            {
                List<Vertex> adjacentVertices = graph.getAdjacentVertices(v);
                SortedSet<int> adjColorCodes = new SortedSet<int>();
                foreach (Vertex adjVertex in adjacentVertices)
                {
                    int color = adjVertex.getColor();
                    if (color > 0)
                    {
                        adjColorCodes.Add(adjVertex.getColor());
                    }
                }
                v.setSatDegree(adjColorCodes.Count);
            }
        }

        public void calculateSaturationDegree()
        {

            foreach (Vertex v in this.graph.getVertices())
            {
                List<Vertex> adjacentVertices = graph.getAdjacentVertices(v);
                SortedSet<int> adjColorCodes = new SortedSet<int>();
                foreach (Vertex adjVertex in adjacentVertices)
                {
                    int color = adjVertex.getColor();
                    if (color > 0)
                    {
                        adjColorCodes.Add(adjVertex.getColor());
                    }
                }
                v.setSatDegree(adjColorCodes.Count);
            }
        }

        public void colorGraph()
        {
            calculateSaturationDegree(colorlessVertices);

            while (colorlessVertices.Count > 0)
            {
                SortedSet<Vertex> PQNode = new SortedSet<Vertex>(colorlessVertices);

                Vertex selectedVertex = PQNode.Max;
                PQNode.Remove(selectedVertex);

                List<Vertex> adjacentVertices = graph.getAdjacentVertices(selectedVertex);
                SortedSet<int> adjColorCodes = new SortedSet<int>();
                foreach (Vertex adjVertex in adjacentVertices)
                {
                    int color = adjVertex.getColor();
                    if (color > 0)
                    {
                        adjColorCodes.Add(adjVertex.getColor());
                    }
                }

                SortedSet<int> tempColors = new SortedSet<int>(colors);
                tempColors.ExceptWith(adjColorCodes);
                int newColor;
                if (tempColors.Count > 0)
                {
                    newColor = tempColors.Max;

                }
                else
                {
                    newColor = colors.Count + 1;
                    colors.Add(newColor);
                }
                selectedVertex.setColor(newColor);

                colorlessVertices.Remove(selectedVertex);

                calculateSaturationDegree(graph.getAdjacentVertices(selectedVertex));
            }

        }

        public Graph getGraph()
        {
            return graph;
        }

        public void setGraph(Graph graph)
        {
            this.graph = graph;
        }


    }
}

