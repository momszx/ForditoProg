using System;
using System.Collections.Generic;
using System.IO;

namespace Beadandó
{
    public class Matrix
    {
        private string matrixSizePath = "MatrixSize.txt";
        private string matrixPath = "Matrix.txt";
        private string xAxisPath = "xAxis.txt";
        private string yAxisPath = "yAxis.txt";
        private string[,] matrix;
        private Dictionary<string, int> yAxis = new Dictionary<string, int>();
        private Dictionary<string, int> xAxis = new Dictionary<string, int>();
        public Matrix()
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(matrixSizePath)))
            {
                string line;
                while ((line=sr.ReadLine())!=null)
                {
                    string[] lines;
                    lines = line.Split('|');
                    try
                    {
                        int x = Convert.ToInt32(lines[0]);
                        int y = Convert.ToInt32(lines[1]);
                        matrix= new string[x,y];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                
            }
            using ( StreamReader sr = new StreamReader(File.OpenRead(xAxisPath)))
            {
                string line;
                while ((line=sr.ReadLine())!=null)
                {
                    string[] lines;
                    lines = line.Split('|');
                    try
                    {
                        int temp = Convert.ToInt32(lines[1]);
                        xAxis.Add(lines[0],temp);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            using ( StreamReader sr = new StreamReader(File.OpenRead(yAxisPath)))
            {
                string line;
                while ((line=sr.ReadLine())!=null)
                {
                    string[] lines;
                    lines = line.Split('|');
                    try
                    {
                        int temp = Convert.ToInt32(lines[1]);
                        yAxis.Add(lines[0],temp);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            using ( StreamReader sr = new StreamReader(File.OpenRead(matrixPath)))
            {
                string line;
                while ((line=sr.ReadLine())!=null)
                {
                    string[] lines;
                    lines = line.Split('|');
                    try
                    {
                        int temp = Convert.ToInt32(lines[0]);
                        int temp2 = Convert.ToInt32(lines[1]);
                        matrix[temp, temp2] = lines[2];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        public string[,] MatrixGet => matrix;

        public Dictionary<string, int> XAxis => xAxis;

        public Dictionary<string, int> YAxis => yAxis;
    }
}