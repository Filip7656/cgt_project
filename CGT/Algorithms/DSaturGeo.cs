using System;
using System.Collections.Generic;
using CGT.Models;

namespace CGT.Algorithms
{
    public class DSaturGeo
    {

        private GraphGeo graphGeo;

        private SortedSet<int> colors;
        private List<Vertex> colorlessVertices;
        public List<Vertex> initialVertices;


        public DSaturGeo(GraphGeo graph)
        {
            this.graphGeo = graph;
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
                List<Vertex> adjacentVertices = graphGeo.getAdjacentVertices(v);
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

            foreach (Vertex v in this.graphGeo.getVertices())
            {
                List<Vertex> adjacentVertices = graphGeo.getAdjacentVertices(v);
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

                List<Vertex> adjacentVertices = graphGeo.getAdjacentVertices(selectedVertex);
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

                calculateSaturationDegree(graphGeo.getAdjacentVertices(selectedVertex));
            }

        }

        public GraphGeo getGraph()
        {
            return graphGeo;
        }

        public void setGraph(GraphGeo graph)
        {
            this.graphGeo = graph;
        }


    }
}

