using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;


namespace test02
{

    public partial class Form1 : Form
    {
        int y_space = 40;
        int x_space = 130;
        int start_x = 1000;
        int start_y = 200;

        string StrText;
        Font StrFont;
        Brush StrBrush;
        Color StrColor;
        Point StrLocation;
        int control_test = 0;

        //table data 
        Color RectColor;
        Pen RectPen;
        Rectangle Rect;
        string[] years = { "Years", "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009" };
        string[] Revenue = { "Revenue", "150", "170", "180", "175", "200", "250", "210", "240", "280", "140" };
        string[] Revenue_measured = { "Revenue", "140", "180", "200", "220", "240", "260", "280", "300", "320", "340" };

        //Line Data
        Color LineColor;
        Pen LinePen;
        Point LineStart;
        Point LineEnd;
        /// linegraph
        Color linegraph;
        Pen LineGrapPen;

        public Form1()
        {
            InitializeComponent();
            linegraph = Color.Black;
            WindowState = FormWindowState.Maximized;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
             y_space = 40;
             x_space = 130;
             start_x = 1000;
             start_y = 200;
           
            DisplayText();
            Displaytable();
            Displaygraph();
            point();


        }
        public void Displaytable()
        {
            Graphics g = this.CreateGraphics();
            RectColor = Color.Black;
            RectPen = new Pen(RectColor, 5);
            Rect = new Rectangle(start_x, start_y, x_space, y_space);
            StrText = years[0];
            StrLocation = new Point(start_x + 7, start_y + 7);
            g.DrawString(StrText, StrFont, StrBrush, StrLocation);
            g.DrawRectangle(RectPen, Rect);

            start_x = start_x + x_space;
            Rect = new Rectangle(start_x, start_y, x_space, y_space);
            StrText = Revenue[0];
            StrLocation = new Point(start_x, start_y + 7);
            g.DrawString(StrText, StrFont, StrBrush, StrLocation);
            g.DrawRectangle(RectPen, Rect);
            for (int i = 2; i < 21; i++)
            {
                start_y = start_y + y_space;
                start_x = start_x - x_space;
                Rect = new Rectangle(start_x, start_y, x_space, y_space);
                g.DrawRectangle(RectPen, Rect);
                StrText = years[i / 2];

                StrLocation = new Point(start_x, start_y + 7);
                g.DrawString(StrText, StrFont, StrBrush, StrLocation);
                i++;
                start_x = start_x + x_space;
                Rect = new Rectangle(start_x, start_y, x_space, y_space);
                g.DrawRectangle(RectPen, Rect);
                StrText = Revenue[i / 2];
                StrLocation = new Point(start_x, start_y + 7);
                g.DrawString(StrText, StrFont, StrBrush, StrLocation);
            }


        }
        public void DisplayText()
        {
            Graphics g = this.CreateGraphics();
            StrText = "ABC Company";
            StrFont = new Font("Times New Roman", 20);
            StrColor = Color.Black;
            StrBrush = new SolidBrush(StrColor);
            StrLocation = new Point(650, 50);

            g.DrawString(StrText, StrFont, StrBrush, StrLocation);

            //"Anual Revenue", 670, 100);
            StrText = "Anual Revenue";
            StrFont = new Font("Times New Roman", 20);
            StrColor = Color.Black;
            StrBrush = new SolidBrush(StrColor);
            StrLocation = new Point(650, 100);

            g.DrawString(StrText, StrFont, StrBrush, StrLocation);

            //underline 
            float x1 = 650;
            float y1 = 50 + 40;
            float x2 = 650 + 190;
            float y2 = y1;
            LineColor = Color.Black;
            LinePen = new Pen(LineColor, 3);
            g.DrawLine(LinePen, x1, y1, x2, y2);



            y1 = 100 + 40;
            y2 = y1;
            LinePen = new Pen(LineColor, 3);
            g.DrawLine(LinePen, x1, y1, x2, y2);


        }
        public void Displaygraph()
        {
            Graphics g = this.CreateGraphics();
            RectColor = Color.Black;
            RectPen = new Pen(RectColor, 5);
            Rectangle FRect = new Rectangle(200, 200, 700, 500);
            Color ForeColor = Color.BlueViolet;
            Color BackColor = Color.White;
            HatchStyle FRect_Style = HatchStyle.Cross;
            Brush FRect_Brush = new HatchBrush(FRect_Style, ForeColor, BackColor);
            g.FillRectangle(FRect_Brush, FRect);
            vertical();
            Horizontal();
        }

        public void vertical()
        {
            Graphics g = this.CreateGraphics();
            LineColor = Color.Black;
            LinePen = new Pen(LineColor, 3);
            ///////// Vertical line ////////
            LineStart = new Point(200, 200);
            LineEnd = new Point(200, 700);
            g.DrawLine(LinePen, LineStart, LineEnd);
            ///////write Revenue tag///////////
            StrText = "Revenue";
            StrLocation = new Point(140, 170);
            StrFont = new Font("Times New Roman", 15);
            g.DrawString(StrText, StrFont, StrBrush, StrLocation);
            ///////// Arrow line //////////

            LineStart = new Point(205, 210);
            LineEnd = new Point(200, 200);
            g.DrawLine(LinePen, LineStart, LineEnd);
            LineStart = new Point(195, 210);
            LineEnd = new Point(200, 200);
            g.DrawLine(LinePen, LineStart, LineEnd);

            /////////mesure lines ///////////
            for (int i = 1; i <= 10; i++)
            {
                dash_horitontal(i);
            }

        }
        public void Horizontal()
        {
            Graphics g = this.CreateGraphics();
            LineColor = Color.Black;
            LinePen = new Pen(LineColor, 3);
            ///////// horizontal line ////////
            LineStart = new Point(900, 700);
            LineEnd = new Point(200, 700);
            g.DrawLine(LinePen, LineStart, LineEnd);
            ///////// Arrow line //////////

            LineStart = new Point(890, 695);
            LineEnd = new Point(900, 700);
            g.DrawLine(LinePen, LineStart, LineEnd);
            LineStart = new Point(890, 705);
            LineEnd = new Point(900, 700);
            g.DrawLine(LinePen, LineStart, LineEnd);
            ///////write years tag///////////
            StrText = "Years";
            StrLocation = new Point(900, 700);
            StrFont = new Font("Times New Roman", 15);
            g.DrawString(StrText, StrFont, StrBrush, StrLocation);
            /////////mesure lines ///////////
            for (int i = 1; i <= 10; i++)
            {
                dash_vertical(i);
            }
        }

        void dash_vertical(int y)
        {
            StrText = Revenue_measured[y];
            Graphics g = this.CreateGraphics();
            y = 700 - (y * 45);

            LineStart = new Point(193, y);
            LineEnd = new Point(207, y);
            g.DrawLine(LinePen, LineStart, LineEnd);
            StrLocation = new Point(140, y - 10);
            StrFont = new Font("Times New Roman", 15);
            g.DrawString(StrText, StrFont, StrBrush, StrLocation);

        }

        void dash_horitontal(int x)
        {
            StrText = years[x];
            Graphics g = this.CreateGraphics();
            x = 200 + (x * 60);
            LineStart = new Point(x, 707);
            LineEnd = new Point(x, 693);
            g.DrawLine(LinePen, LineStart, LineEnd);
            StrLocation = new Point(x - 10, 720);
            StrFont = new Font("Times New Roman", 15);
            g.DrawString(StrText, StrFont, StrBrush, StrLocation);
            // bar(x);
        }
        void point()
        {
            Graphics g = this.CreateGraphics();
            Point point1 = new Point(200 + 1 * 60, 800 - Int32.Parse(Revenue[1]));
            bar(200 + 1 * 60, 800 - Int32.Parse(Revenue[1]));
            Point point2 = Point.Add(point1, new Size(9, 0));
            LineGrapPen = new Pen(linegraph, 2);
            g.DrawLine(LineGrapPen, point1, point2);
            LineStart = point1;
            LineEnd = point1;
            for (int x = 2; x < 11; x++)
            {
                LineGrapPen = new Pen(linegraph, 5);
                LineStart = point1;
                point1 = new Point(200 + x * 60, 800 - Int32.Parse(Revenue[x]));
                bar(200 + x * 60, 800 - Int32.Parse(Revenue[x]));
                LineEnd = point1;
                g.DrawLine(LineGrapPen, LineStart, LineEnd);
                point2 = Point.Add(point1, new Size(9, 0));
                LineGrapPen = new Pen(linegraph, 10);
                g.DrawLine(LineGrapPen, point1, point2);



            }
        }
        void bar(int x, int y)
        {
            int x1 = x;
            int y1 = y;
            int x2 = 20;
            int y2 = 700 - y;

            Graphics g = this.CreateGraphics();
            RectColor = Color.Black;
            RectPen = new Pen(RectColor, 5);
            Rect = new Rectangle(x1, y1, x2, y2);
            HatchStyle FRect_Style = HatchStyle.DashedHorizontal;
            Brush FRect_Brush = new HatchBrush(FRect_Style, Color.Red, Color.Gray);
            g.FillRectangle(FRect_Brush, Rect);
            // g.DrawRectangle(RectPen, Rect);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X > 200 && e.X < 900 && e.Y > 200 && e.Y < 700)
            {
                for (int i = 200; i < 900; i+=65)
                {
                    if (e.X > i-65 && e.X < i)
                    {
                        MessageBox.Show("year is " + years[(i - 200) / 65]+ "\nit's revenue is "+Revenue[(i - 200) / 65] );
                    }
                    
                }
            }
         
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {

                linegraph = Color.Red;
                Invalidate();
               
            }
            if (e.KeyCode == Keys.G && e.Modifiers == Keys.Control)
            {

                linegraph=Color.Green;
                Invalidate();
               
            }
            if (e.KeyCode == Keys.B && e.Modifiers == Keys.Control)
            {

                linegraph = Color.Blue;
                Invalidate();
        
                
            }
           

        }
    }


}


