using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fabry_Jan
{
    public partial class Form1 : Form
    {
        Graphics drawArea;
        public Form1()
        {
            InitializeComponent();
            drawArea = drawingArea.CreateGraphics();
        }
        private void btDraw_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            btVymaz.Enabled = true;
            tbT1.ReadOnly = false;
            tbT2.ReadOnly = false;

            drawingArea.Image = null;
            Refresh();


            button1click = false;
            button2click = false;
            button3click = false;
            button4click = false;
            button5click = true;

            int x1, x2, x3, x4, y1, y2, y3, y4;

            x1 = Convert.ToInt32(tbX1.Text);
            x2 = Convert.ToInt32(tbX2.Text);
            x3 = Convert.ToInt32(tbX3.Text);
            x4 = Convert.ToInt32(tbX4.Text);
            y1 = Convert.ToInt32(tbY1.Text);
            y2 = Convert.ToInt32(tbY2.Text);
            y3 = Convert.ToInt32(tbY3.Text);
            y4 = Convert.ToInt32(tbY4.Text);

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Point point3 = new Point(x3, y3);
            Point point4 = new Point(x4, y4);

            Point[] curvePoints =
            {
                 point1,
                 point2,
                 point3,
                 point4,
            };

            Pen pen = new Pen(Color.Black, 3);
            switch (cbColors.SelectedIndex)
            {
                case 0: pen = new Pen(Color.Black, 3); break;
                case 1: pen = new Pen(Color.Blue, 3); break;
                case 2: pen = new Pen(Color.Red, 3); break;
                case 3: pen = new Pen(Color.Yellow, 3); break;
                case 4: pen = new Pen(Color.Green, 3); break;
            }

            int numberx1, numberx2, numberx3, numberx4, numbery1, numbery2, numbery3, numbery4;
            if ((int.TryParse(tbX1.Text, out numberx1)) &&
                (int.TryParse(tbX2.Text, out numberx2)) &&
                (int.TryParse(tbX3.Text, out numberx3)) &&
                (int.TryParse(tbX4.Text, out numberx4)) &&
                (int.TryParse(tbX4.Text, out numbery1)) &&
                (int.TryParse(tbX4.Text, out numbery2)) &&
                (int.TryParse(tbX4.Text, out numbery3)) &&
                (int.TryParse(tbX4.Text, out numbery4)))
            {

                if (numberx1 >= 700)
                {
                    MessageBox.Show("Maximálna povolená hodnota pre bod X1 = 700");
                }
                else if (numberx2 >= 735)
                {
                    MessageBox.Show("Maximálna povolená hodnota pre bod X2 = 735");
                }
                else if (numberx3 >= 700)
                {
                    MessageBox.Show("Maximálna povolená hodnota pre bod X3 = 700");
                }
                else if (numberx4 >= 735)
                {
                    MessageBox.Show("Maximálna povolená hodnota pre bod X4 = 735");
                }
                else if (numbery1 >= 250)
                {
                    MessageBox.Show("Maximálna povolená hodnota pre bod Y1 = 250");
                }
                else if (numbery2 >= 285)
                {
                    MessageBox.Show("Maximálna povolená hodnota pre bod Y2 = 285");
                }
                else if (numbery3 >= 250)
                {
                    MessageBox.Show("Maximálna povolená hodnota pre bod Y3 = 250");
                }
                else if (numbery4 >= 285)
                {
                    MessageBox.Show("Maximálna povolená hodnota pre bod Y4 = 285");
                }
                else
                {
                    drawArea.DrawPolygon(pen, curvePoints);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            drawingArea.Image = null;
            Refresh();



            int x1, x2, x3, x4, y1, y2, y3, y4, t1, t2;

            x1 = Convert.ToInt32(tbX1.Text);
            x2 = Convert.ToInt32(tbX2.Text);
            x3 = Convert.ToInt32(tbX3.Text);
            x4 = Convert.ToInt32(tbX4.Text);
            y1 = Convert.ToInt32(tbY1.Text);
            y2 = Convert.ToInt32(tbY2.Text);
            y3 = Convert.ToInt32(tbY3.Text);
            y4 = Convert.ToInt32(tbY4.Text);
            t1 = Convert.ToInt32(tbT1.Text);
            t2 = Convert.ToInt32(tbT2.Text);

            int[,] matrix = new int[1, 3] { { x1, y1, 1 } };

            int[,] matrixnovy = new int[3, 3] { { 1, 0, 0 }, { 0, 1, 0 }, { t1, t2, 1 } };

            int tx2 = x2 + (t1-x1);
            int ty2 = y2 + (t2-y1);
            int tx3 = x3 + (t1-x1);
            int ty3 = y3 + (t2-y1);
            int tx4 = x4 + (t1-x1);
            int ty4 = y4 + (t2-y1);
            int tx11 = 1;

            int[,] matrixvysledny = new int[1, 3] { { tx2, ty2, tx11 } };

            Point point1 = new Point(t1, t2);
            Point point2 = new Point(tx2, ty2);
            Point point3 = new Point(tx3, ty3);
            Point point4 = new Point(tx4, ty4);

            Point[] curvePoints =
            {
                 point1,
                 point2,
                 point3,
                 point4,
            };


            Pen pen = new Pen(Color.Black, 3);
            switch (cbColors.SelectedIndex)
            {
                case 0: pen = new Pen(Color.Black, 3); break;
                case 1: pen = new Pen(Color.Blue, 3); break;
                case 2: pen = new Pen(Color.Red, 3); break;
                case 3: pen = new Pen(Color.Yellow, 3); break;
                case 4: pen = new Pen(Color.Green, 3); break;
            }
            drawArea.DrawPolygon(pen, curvePoints);
        }

        private bool button1click = false;
        private bool button2click = false;
        private bool button3click = false;
        private bool button4click = false;
        private bool button5click = false;
        private void drawingArea_Click(object sender, EventArgs e)
        {
            if (button1click)
            {
                MouseEventArgs eM = (MouseEventArgs)e;
                tbX1.Text = eM.X.ToString();
                tbY1.Text = eM.Y.ToString();
            }
            if (button2click)
            {
                MouseEventArgs eM = (MouseEventArgs)e;
                tbX2.Text = eM.X.ToString();
                tbY2.Text = eM.Y.ToString();
            }
            if (button3click)
            {
                MouseEventArgs eM = (MouseEventArgs)e;
                tbX3.Text = eM.X.ToString();
                tbY3.Text = eM.Y.ToString();
            }
            if (button4click)
            {
                MouseEventArgs eM = (MouseEventArgs)e;
                tbX4.Text = eM.X.ToString();
                tbY4.Text = eM.Y.ToString();
            }
            if (button5click)
            {
                MouseEventArgs eM = (MouseEventArgs)e;
                tbT1.Text = eM.X.ToString();
                tbT2.Text = eM.Y.ToString();
            }
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            tbX1.ReadOnly = false;
            tbY1.ReadOnly = false;
            tbX2.ReadOnly = true;
            tbY2.ReadOnly = true;
            tbX3.ReadOnly = true;
            tbY3.ReadOnly = true;
            tbX4.ReadOnly = true;
            tbY4.ReadOnly = true;
            tbT1.ReadOnly = true;
            tbT2.ReadOnly = true;
            button1click = true;
            button2click = false;
            button3click = false;
            button4click = false;
            button5click = false;

        }

        private void bt2_Click(object sender, EventArgs e)
        {
            tbX1.ReadOnly = true;
            tbY1.ReadOnly = true;
            tbX2.ReadOnly = false;
            tbY2.ReadOnly = false;
            tbX3.ReadOnly = true;
            tbY3.ReadOnly = true;
            tbX4.ReadOnly = true;
            tbY4.ReadOnly = true;
            tbT1.ReadOnly = true;
            tbT2.ReadOnly = true;
            button1click = false;
            button2click = true;
            button3click = false;
            button4click = false;
            button5click = false;
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            tbX1.ReadOnly = true;
            tbY1.ReadOnly = true;
            tbX2.ReadOnly = true;
            tbY2.ReadOnly = true;
            tbX3.ReadOnly = false;
            tbY3.ReadOnly = false;
            tbX4.ReadOnly = true;
            tbY4.ReadOnly = true;
            tbT1.ReadOnly = true;
            tbT2.ReadOnly = true;
            button1click = false;
            button2click = false;
            button3click = true;
            button4click = false;
            button5click = false;
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            tbX1.ReadOnly = true;
            tbY1.ReadOnly = true;
            tbX2.ReadOnly = true;
            tbY2.ReadOnly = true;
            tbX3.ReadOnly = true;
            tbY3.ReadOnly = true;
            tbX4.ReadOnly = false;
            tbY4.ReadOnly = false;
            tbT1.ReadOnly = true;
            tbT2.ReadOnly = true;
            button1click = false;
            button2click = false;
            button3click = false;
            button4click = true;
            button5click = false;
        }

        private void drawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (button1click)
            {
                drawingArea.Cursor = Cursors.Cross;
            }
        }

        private void ulozit1_Click(object sender, EventArgs e)
        {
            tbX1.ReadOnly = true;
            tbY1.ReadOnly = true;
            button1click = false;
        }

        private void ulozit2_Click(object sender, EventArgs e)
        {
            tbX2.ReadOnly = true;
            tbY2.ReadOnly = true;
            button2click = false;
        }

        private void ulozit3_Click(object sender, EventArgs e)
        {
            tbX3.ReadOnly = true;
            tbY3.ReadOnly = true;
            button3click = false;
        }

        private void ulozit4_Click(object sender, EventArgs e)
        {
            tbX4.ReadOnly = true;
            tbY4.ReadOnly = true;
            button4click = false;
        }

        private void btVymaz_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            drawingArea.Image = null;
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbX1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbY1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbY2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbX3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbY3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbX4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbY4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbT1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbT2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
