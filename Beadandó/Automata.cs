using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Beadandó
{
    public class Automata
    {
        private string input;
        private int i=0;
        private Stack<string> verem = new Stack<string>();
        private string szabaly = null;
        private Matrix _matrix = new Matrix();

        public Matrix Matrix
        {
            get => _matrix;
            set => _matrix = value;
        }
        public Stack<string> Verem
        {
            get => verem;
            set => verem = value;
        }
        public string Szabaly
        {
            get => szabaly;
            set => szabaly = value;
        }
        public string Input
        {
            get => input;
            set => input = value;
        }
        public int I
        {
            get => i;
            set => i = value;
        }
        private string simple(string st)
        {
            return Regex.Replace(st, "([0-9])+", "i");
        }
        public void AutomataSetter(string input)
        {
            if (input[input.Length-1]=='#')
            {
                Input = $"{simple(input)}";
            }
            else
            {
                Input = $"{simple(input)}#";
            }
            Verem.Push("#");
            Verem.Push("E");
        }

        public string asd()
        {
            int x;
            int y;
            while (Input[I]!='#')
            {
                Console.WriteLine(Verem.Peek());
                if (Verem.Peek()=="e")
                {
                    Verem.Pop();
                }
                string veremPop = Verem.Pop();
                try
                {
                    x = Matrix.XAxis[veremPop];
                    y = Matrix.YAxis[Char.ToString(Input[I])];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "Hibás bemenet";
                }
                if (Matrix.MatrixGet[x,y]=="pop")
                {
                    I++;
                }
                else if (Matrix.MatrixGet[x,y]==null)
                {
                    return "Hibás bemenet";
                }
                else
                {
                    string[] splited = Matrix.MatrixGet[x, y].Split(',');
                    if (splited[0].Contains("."))
                    {
                        string[] dotSplitted = splited[0].Split('.');
                        for (int j = dotSplitted.Length-1; j >=0 ; j--)
                        {
                            Verem.Push(dotSplitted[j]);
                        }
                    }
                    else
                    {
                        Verem.Push(splited[0]);
                    }
                    Szabaly += splited[splited.Length-1];
                }
            }
            return Szabaly;
        }
    }
}