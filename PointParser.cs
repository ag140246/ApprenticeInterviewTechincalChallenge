using System;
using System.Collections.Generic;
using System.IO;

namespace InterviewProblem
{
   public class PointParser
   {
      /// <summary>
      ///   The purpose of this method is to parse the text file and return the series of points
      /// </summary>
      public static void Parse(string file1)
      {
         var lines = File.ReadAllLines(file1);

         // Rule: A new series is denoted by an empty line in the file.
         // A Series has a list of points on it 
         var series = new List<Series>();
         var points = new List<Point>();

         foreach (var line in lines)
         {
            if (line == "")
            {
               series.Add(new Series(points));
               points = new List<Point>();
            }
            else
            {
               var values = line.Split(',');
               var xValue = values[0];
               var yValue = values[1];
               points.Add(new Point(double.Parse(xValue), double.Parse(yValue)));
            }
         }

         for (var i = 0; i < series.Count; i++)
         {
            Console.WriteLine("Series - " + i);
            for (int j = 0; j < series[i].Points.Count; j++)
            {
               Console.WriteLine("Point " + i + " - " + series[i].Points[j].X + ", " + series[i].Points[j].Y);
            }
         }
      }
   }
}
