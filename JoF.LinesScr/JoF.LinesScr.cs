using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LinesScr
{
    public partial class LinesScr : Form
    {
        private Point mouseLocation;
        private Random rand = new Random();
        private Graphics g;

        private int particleCount = 20;
        private int particleRadius = 1;
        private int particleSpeed = 20;
        private int particleDistance = 250;

        private List<Particle> particles;
        private Pen pen;
        private Brush bgBrush, particleBrush;

        public LinesScr(Rectangle bounds)
        {
            InitializeComponent();
            this.Bounds = bounds;
            Initialise();
        }

        private void LinesScr_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
        }

        private void LinesScr_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseLocation.IsEmpty)
            {
                if (Math.Abs(mouseLocation.X - e.X) > 5 || Math.Abs(mouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }
            mouseLocation = e.Location;
        }

        private void LinesScr_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void LinesScr_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Draw();
        }


        private void Initialise()
        {
            g = CreateGraphics();

            particles = new List<Particle>();
            for (int i = 0; i < particleCount; i++)
            {
                particles.Add(new Particle(this.Bounds.Width, this.Bounds.Height, rand));
            }
            bgBrush = new SolidBrush(Color.FromArgb(10, 0, 0, 0));
        }

        private void Draw()
        {
            // add almost transparent bg
            g.FillRectangle(bgBrush, 0, 0, this.Bounds.Width, this.Bounds.Height);

            foreach (Particle p in particles)
            {
                particleBrush = new SolidBrush(Color.White);
                g.FillRectangle(particleBrush, p.Location.X, p.Location.Y, particleRadius, particleRadius);
                foreach (Particle p2 in particles)
                {
                    int dx = p2.Location.X - p.Location.X;
                    int dy = p2.Location.Y - p.Location.Y;
                    double d = Math.Sqrt(dx * dx + dy * dy);

                    if (d < particleDistance)
                    {
                        pen = new Pen(Color.FromArgb(p.Alpha, p.Red, p.Green, p.Blue));
                        g.DrawLine(pen, p.Location.X, p.Location.Y, p2.Location.X, p2.Location.Y);
                    }
                }

                int x = Convert.ToInt32(p.Location.X + particleSpeed * Math.Cos(p.Angle * Math.PI / 180));
                int y = Convert.ToInt32(p.Location.Y + particleSpeed * Math.Sin(p.Angle * Math.PI / 180));
                if (x < 0) x = this.Bounds.Width;
                if (y < 0) y = this.Bounds.Height;
                if (x > this.Bounds.Width) x = 0;
                if (y > this.Bounds.Height) y = 0;

                p.Location = new Point(x, y);
            }
        }
    }
}
