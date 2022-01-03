using System;
using System.Collections.Generic;
using System.IO;

namespace Beadandó
{
    public class Matrix
    {
        private readonly string matrixSizePath = "MatrixSize.txt";
        private readonly string matrixPath = "Matrix.txt";
        private readonly string xAxisPath = "xAxis.txt";
        private readonly string yAxisPath = "yAxis.txt";
        private readonly string[,] matrix;
        private readonly Dictionary<string, int> yAxis = new Dictionary<string, int>();
        private readonly Dictionary<string, int> xAxis = new Dictionary<string, int>();
        public Matrix()
        {//iitalizáláskor beolvassuk a matrixSizePath-et szétszedjük | ként és a mátrix x,y kordinátán létrehozunk egy új stringet
            using (StreamReader sr = new StreamReader(File.OpenRead(matrixSizePath)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lines;
                    lines = line.Split('|');
                    try
                    {
                        int x = Convert.ToInt32(lines[0]);
                        int y = Convert.ToInt32(lines[1]);
                        matrix = new string[x, y];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
            //beolvassuk a xAxisPath és | ként tördeljük és a xAxis Directory(kulcspár) hoz hozzá rendeljük az értékeket
            using (StreamReader sr = new StreamReader(File.OpenRead(xAxisPath)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lines;
                    lines = line.Split('|');
                    try
                    {
                        int temp = Convert.ToInt32(lines[1]);
                        xAxis.Add(lines[0], temp);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            //beolvassuk a yAxisPath és | ként tördeljük és a yAxis Directory(kulcspár) hoz hozzá rendeljük az értékeket
            using (StreamReader sr = new StreamReader(File.OpenRead(yAxisPath)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] lines;
                    lines = line.Split('|');
                    try
                    {
                        int temp = Convert.ToInt32(lines[1]);
                        yAxis.Add(lines[0], temp);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            //beolvassuk a matrixPath és | ként tördeljük , a mártixban az x,y kordináták alapján meghatározzuk a cella értékét 
            using (StreamReader sr = new StreamReader(File.OpenRead(matrixPath)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
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