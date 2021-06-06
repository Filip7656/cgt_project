using System;
using System.Collections.Generic;
using CGT.Models;

namespace CGT.Algorithms
{
    public class GeometricColoring
    {
        private GraphGeo graph;
        private SortedSet<int> colors;

        private List<Vertex> colorlessVertices;
        public List<Vertex> initialVertices;

        public int getColorCount()
        {
            return colors.Count;
        }
        public GeometricColoring(GraphGeo _graph)
        {
            this.graph = _graph;
            this.colors = new SortedSet<int>();
            this.colorlessVertices = graph.getVertices();
            this.initialVertices = graph.getVertices();

        }


        public double getDistance(Vertex v1, Vertex v2)
        {
            double x1 = v1.getX();
            double x2 = v2.getX();
            double y1 = v1.getY();
            double y2 = v2.getY();
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
        public void colorGraph()
        {
            while (colorlessVertices.Count > 0)
            {
                List<Vertex> previousSelectedVertices = new List<Vertex>();
                int newColor = colors.Count + 1;

                while (true)
                {
                    if (colorlessVertices.Count == 0)
                    {
                        break;
                    }
                    Vertex selectedVertex = colorlessVertices[0];
                    bool found = false;

                    if (previousSelectedVertices.Count != 0)
                    {
                        foreach (Vertex v in colorlessVertices)
                        {
                            found = true;
                            selectedVertex = v;

                            // If distance to each of previousSelectedVertices is >= 3.0,
                            // we can choose another disk of the same color.
                            foreach (Vertex w in previousSelectedVertices)
                            {
                                if (getDistance(v, w) < 3.0)
                                {
                                    found = false;
                                }
                            }
                        }

                        // If such disk cannot be found, go to the next color.
                        if (!found)
                        {
                            break;
                        }
                    }

                    colorlessVertices.Remove(selectedVertex);

                    colors.Add(newColor);
                    selectedVertex.setColor(newColor);
                    List<Vertex> nearVertices = new List<Vertex>();

                    // Color each vertex within distance of 0.5 with the same color.
                    // This guarantees that any two vertices in such a disk have distance <= 1
                    foreach (Vertex v in colorlessVertices)
                    {
                        if (getDistance(v, selectedVertex) < 0.5)
                        {
                            nearVertices.Add(v);
                        }
                    }
                    foreach (Vertex v in nearVertices)
                    {
                        v.setColor(newColor);
                        colorlessVertices.Remove(v);
                    }
                    previousSelectedVertices.Add(selectedVertex);
                }
            }

        }

    }
}

