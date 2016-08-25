using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarboundModTools.UI.Designer
{
    public class DrawPanel : Panel
    {
        public event DoPaint Repaint;

        Timer timer;

        public DrawPanel() {
            timer = new Timer();
            Fps = 30;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            if (Repaint != null && !this.DesignMode)
                Repaint(e.Graphics, e.ClipRectangle);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            base.OnPaintBackground(e);

            Graphics g = e.Graphics;
            Rectangle r = e.ClipRectangle;

            const int length = 5;
            Brush brush0 = Brushes.White;
            Brush brush1 = Brushes.DarkGray;
            bool drawn = false;

            for(int x = 0; x * length < r.Right; x++) {
                for(int y = 0; y < r.Bottom; y++) {
                    if (drawn)
                        g.FillRectangle(brush1, r.X + x * length, r.Y + y * length, length, length);
                    else
                        g.FillRectangle(brush0, r.X + x * length, r.Y + y * length, length, length);

                    drawn = !drawn;
                }
                drawn = !drawn;
            }
        }

        public int Fps
        {
            set
            {
                timer.Interval = Math.Max( 1000 / value, 1);
            }
            get
            {
                float interval = timer.Interval;
                return (int)(1 / (interval / 1000));
            }
        }

        public bool EnableClock
        {
            set { timer.Enabled = value; }
            get { return timer.Enabled; }
        }
    }

    public delegate void DoPaint(Graphics g, Rectangle r);
}
