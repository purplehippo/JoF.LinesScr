using System;
using System.Drawing;

namespace LinesScr
{
    class Particle
    {
        private Point location;
        private float angle;
        private int red, green, blue, alpha;

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }

        public float Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        public int Alpha
        {
            get { return alpha; }
            set { alpha = value; }
        }

        public int Blue
        {
            get { return blue; }
            set { blue = value; }
        }

        public int Green
        {
            get { return green; }
            set { green = value; }
        }

        public int Red
        {
            get { return red; }
            set { red = value; }
        }

        public Particle(int w, int h, Random rand)
        {
            location = new Point(rand.Next(w), rand.Next(h));
            angle = rand.Next(360);
            red = rand.Next(255);
            green = rand.Next(255);
            blue = rand.Next(255);
            alpha = rand.Next(255);
        }
    }
}
