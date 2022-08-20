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

namespace GraphicCalculator
{
    static class Constants
    {
        public const int MIN_LINE_GAP = 40;
        public const int MAX_LINE_GAP = 80;
    }

    public partial class GraphicView : Control
    {
        bool graph_clicked = false;
        bool paint_line = false;
        float x_scale = 50;
        float y_scale = 50;
        int x_offset = 0;
        int y_offset = 0;
        int x_clicked = 0;
        int y_clicked = 0;
        int x_last_mouse = 0;
        int y_last_mouse = 0;

        MathManager math_manager;

        public GraphicView()
        {
            InitializeComponent();

            math_manager = new MathManager();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public void SetVariableChar(char var)
        {
            math_manager.SetVariableChar(var);
            Invalidate();
        }

        public bool SetExpression(String exp)
        {
            paint_line = math_manager.ParseExpression(exp);
            Invalidate();
            return paint_line;
        }

        private void PaintBack(Graphics graphics)
        {
            Rectangle recClient = Rectangle.FromLTRB(0, 0, Width, Height);
            using (SolidBrush brush = new SolidBrush(Color.White)) graphics.FillRectangle(brush, recClient);
        }

        private void PaintGraphics(Graphics graphics)
        { 
            int offset = Width / 2;
            PointF[] graphic_points = new PointF[2 * offset];

            for (int x = -offset - x_offset; x < offset - x_offset; x++)
            {
                double y = math_manager.Evaluate(x / x_scale) * y_scale;

                // In case some values are NaN:
                if (Double.IsNaN(y))
                    y = 0;

                float x_screen = Width / 2 + (float)(x + x_offset);
                float y_screen = Height / 2 - (float)(y - y_offset);

                // Clip extremities: 
                y_screen = Math.Min(Height + 2, Math.Max(y_screen, -2));

                graphic_points[x + offset + x_offset] = new PointF(x_screen, y_screen);
            }

            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.Red, 3)) graphics.DrawLines(pen, graphic_points);
        }

        private void PaintSelection(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.Red, 2) ;

            double x = x_last_mouse - x_offset - Width / 2;
            double y = math_manager.Evaluate(x / x_scale) * y_scale;
            float y_screen = Height / 2 - (float)(y - y_offset);

            graphics.FillEllipse(brush, x_last_mouse - 3, y_screen - 3, 6, 6);
            graphics.DrawEllipse(pen, x_last_mouse-3, y_screen-3, 6, 6);

            Font drawFont = new Font("Arial Bold", 9, FontStyle.Bold);
            StringFormat drawFormat = new StringFormat();
            brush.Color = Color.Black;

            String point = "("  + (x / x_scale).ToString("0.000") + 
                           ", " + (y / y_scale).ToString("0.000") + ")";

            graphics.DrawString(point, drawFont, brush, x_last_mouse + 10, y_screen, drawFormat);
        }

        private void PaintGrid(Graphics graphics)
        {
            Pen pen = new Pen(Color.Gray, 1);
            PointF vert_line_a;
            PointF vert_line_b;
            PointF hori_line_a;
            PointF hori_line_b;

            float x_line_scale = x_scale;
            float y_line_scale = y_scale;

            while (x_line_scale > Constants.MAX_LINE_GAP)
                x_line_scale /= 2;

            while (x_line_scale < Constants.MIN_LINE_GAP)
                x_line_scale *= 2;

            while (y_line_scale > Constants.MAX_LINE_GAP)
                y_line_scale /= 2;

            while (y_line_scale < Constants.MIN_LINE_GAP)
                y_line_scale *= 2;

            int x_a = (int)((-(Width/2) - x_offset) / x_line_scale);
            int x_b = (int)(((Width/2) - x_offset) / x_line_scale);
            int y_a = (int)((-(Height/2) - y_offset) / y_line_scale);
            int y_b = (int)(((Height/2) - y_offset) / y_line_scale);

            for (int y = y_a; y <= y_b; y++)
            {
                hori_line_a = new PointF(0, Height/2 + y_offset + y*y_line_scale);
                hori_line_b = new PointF(Width, Height/2 + y_offset + y*y_line_scale);
                graphics.DrawLine(pen, hori_line_a, hori_line_b);
            }

            for (int x = x_a; x <= x_b; x++)
            {
                vert_line_a = new PointF(Width/2 + x_offset + x*x_line_scale, 0);
                vert_line_b = new PointF(Width/2 + x_offset + x*x_line_scale, Height);
                graphics.DrawLine(pen, vert_line_a, vert_line_b);
            }

            pen.Color = Color.Black;
            pen.Width = 2;
            vert_line_a = new Point(0, Height / 2 + y_offset);
            vert_line_b = new Point(Width, Height / 2 + y_offset);
            hori_line_a = new Point(Width / 2 + x_offset, 0);
            hori_line_b = new Point(Width / 2 + x_offset, Height);

            graphics.DrawLine(pen, vert_line_a, vert_line_b);
            graphics.DrawLine(pen, hori_line_a, hori_line_b);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            PaintBack(e.Graphics);
            PaintGrid(e.Graphics);

            if (paint_line)
            {
                PaintGraphics(e.Graphics);

                if ((Control.ModifierKeys & Keys.Shift) != 0)
                    PaintSelection(e.Graphics);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            float zoom_ratio = 1.2f;

            if (e.Delta > 0)
            {
                x_scale = x_scale*zoom_ratio;
                y_scale = y_scale*zoom_ratio;
            }
            else if (e.Delta < 0)
            { 
                x_scale = x_scale/zoom_ratio;
                y_scale = y_scale/zoom_ratio;
            }

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            graph_clicked = true;
            x_clicked = e.X - x_offset;
            y_clicked = e.Y - y_offset;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            graph_clicked = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (graph_clicked)
            {
                x_offset = e.X - x_clicked;
                y_offset = e.Y - y_clicked;
            }

            x_last_mouse = e.X;
            y_last_mouse = e.Y;
            Invalidate();
        }
    }
}
