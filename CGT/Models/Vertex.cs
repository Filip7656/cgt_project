using System;
namespace CGT.Models
{
    public class Vertex : IComparable<Vertex>
    {
        private String label { get; set; }
        private int adjDegree { get; set; }
        private int satDegree { get; set; }
        private int color { get; set; }
        private int X { get; set; }
        private int Y { get; set; }


        public Vertex(String label)
        {
            this.label = label;
            adjDegree = 0;
            satDegree = 0;
            color = 0;
            this.X = 0;
            this.Y = 0;
        }

        public Vertex(String label, int X, int Y)
        {
            this.label = label;
            adjDegree = 0;
            satDegree = 0;
            color = 0;
            this.X = X;
            this.Y = Y;
        }

        public int compareTo(Vertex o)
        {
            if (this.satDegree == o.satDegree)
            {
                if (this.adjDegree > o.adjDegree)
                {
                    return -1;
                }
                else if (this.adjDegree < o.adjDegree)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (this.satDegree > o.satDegree)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        public double calculateDistance(Vertex v)
        {
            return Math.Sqrt(Math.Pow(this.X - v.getX(), 2) + Math.Pow(this.Y - v.getY(), 2));
        }

        public String getLabel()
        {
            return label;
        }

        public void setLabel(String label)
        {
            this.label = label;
        }

        public int getAdjDegree()
        {
            return adjDegree;
        }

        public void setAdjDegree(int adjDegree)
        {
            this.adjDegree = adjDegree;

        }

        public int getSatDegree()
        {
            return satDegree;
        }

        public void setSatDegree(int satDegree)
        {
            this.satDegree = satDegree;
        }

        public int getColor()
        {
            return color;
        }

        public void setColor(int color)
        {
            this.color = color;
        }
        override
        public String ToString()
        {
            return label;
        }

        public int getX()
        {
            return X;
        }

        public void setX(int x)
        {
            X = x;
        }

        public int getY()
        {
            return Y;
        }

        public void setY(int y)
        {
            Y = y;
        }


        public int CompareTo(Vertex o)
        {
            if (this.satDegree == o.satDegree)
            {
                if (this.adjDegree > o.adjDegree)
                {
                    return -1;
                }
                else if (this.adjDegree < o.adjDegree)
                {
                    return 1;
                }
                else
                    return 0;
            }
            else if (this.satDegree > o.satDegree)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}
