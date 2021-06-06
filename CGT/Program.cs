using System;
using System.Collections.Generic;
using CGT.Algorithms;
using CGT.Models;
using System.Diagnostics;

namespace CGT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>()
                    {
10
            };
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine("======= {0} =======", numbers[i]);

                GraphGeo g = new GraphGeo(generateRandomVertices(numbers[i]), 3);
                g.calculateAllEdges();
                g.computeAdjacentDegree();
                g.displayGraph();
                TestGeoGraph(g);
                TestGeoGraphDSatur(g);
                Console.WriteLine("================");
            }


        }

        static void TestGeoGraph(GraphGeo g)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            {
                GeometricColoring geometricColoring = new GeometricColoring(g);
                geometricColoring.colorGraph();
                Console.WriteLine("GEO COLORING RESULT  : " + geometricColoring.getColorCount());

            }
            sw.Stop();
            Console.WriteLine("Elapsed Time = {0} ", sw.Elapsed);


        }

        static void TestGeoGraphDSatur(GraphGeo g)
        {

            Stopwatch sw = new Stopwatch();
            sw.Start();
            {

                DSaturGeo dSaturGeo = new DSaturGeo(g);
                dSaturGeo.colorGraph();
                Console.WriteLine("DSATUR COLORING RESULT  : " + dSaturGeo.getColorCount());

            }
            sw.Stop();
            Console.WriteLine("Elapsed Time = {0} ", sw.Elapsed);


        }

        static List<String> generateRandomVertices(int n)
        {
            List<String> randomVertices = new List<String>();
            for (int i = 0; i < n; i++)
            {
                randomVertices.Add(i.ToString());
            }
            return randomVertices;
        }
    }
}
