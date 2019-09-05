using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg01_Linje
{
    struct Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void ResetPoint()
        {
            this.x = 0;
            this.y = 0;
        }
        public void DisplayPoint()
        {
            string lineOut = $"The points sits at {this.x},{this.y}";
            Console.WriteLine(lineOut);
        }
    }
    enum LineColor {Red, Blue, Green}

    class Line
    {
        public Point Start;
        public Point End;
        private LineColor color;

        public Line(Point start, Point end, LineColor color)
        {
            this.Start = start;
            this.End = end;
            this.color = color;
        }

        public void MoveLine (int offsetX, int offsetY)
        {
            this.Start.x += offsetX;
            this.Start.y += offsetY;

            this.End.x += offsetX;
            this.End.y += offsetY;
        }

        public double GetLineLength()
        {
            var diffX = Math.Abs(this.Start.x - this.End.x);
            var diffY = Math.Abs(this.Start.y - this.End.y);

            var lineLength = Math.Sqrt(diffX*diffY + diffY*diffY);
            return lineLength;
        }

        public LineColor GetColor()
        {
            return color;
        }

        public void ResetLine()
        { 
            this.Start.ResetPoint();
            this.End.ResetPoint();
        }

        public void DisplayLine()
        {
            string lineOut = $"The {this.color} line starts at {this.Start.x},{this.Start.y} and ends at {this.End.x},{this.End.y}";
            Console.WriteLine(lineOut);
        }

    }


    class Program
    {   
        static void Main(string[] args)
        {
            // struct is a value-type, so not required to instantiate
            Point start;
            start.x = 0;
            start.y = 1;
            
            // using ctor
            Point end = new Point(3, 6);

            Line firstLine = new Line(start, end, LineColor.Red);
            firstLine.DisplayLine();
            Console.WriteLine($"Linelength is {firstLine.GetLineLength():0.000}");
            Console.ReadKey();

            firstLine.MoveLine(5, 3);
            firstLine.DisplayLine();
            Console.WriteLine($"Linelength is {firstLine.GetLineLength():0.000}");
            Console.ReadKey();
        }
    }
}
