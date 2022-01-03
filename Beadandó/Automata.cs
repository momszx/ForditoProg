using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Beadandó
{
    public class Automata
    {
        private string input;
        private int i = 0;
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
        //a kapott stringben kicseréli az összes számot i betükre pl 1+2*3== i+i*i
        private string ToSimple(string st)
        {
            return Regex.Replace(st, "([0-9])+", "i");
        }
        //ha a input utlsó karaktere # akkor csak egyszerűsit ha nem tartalmazza a kért karaktert akkor hozzáadja és a veremhez hozzá adja a kezdő karakterekt
        public void AutomataSetter(string input)
        {
            if (input[input.Length - 1] == '#')
            {
                Input = $"{ToSimple(input)}";
            }
            else
            {
                Input = $"{ToSimple(input)}#";
            }
            Verem.Push("#");
            Verem.Push("E");
        }

        public string ToOutPut()
        {
            int x;
            int y;
            //addig megyünk mig el nem érjük az utolsó karaktert a #
            while (Input[I] != '#')
            {
                Console.WriteLine(Verem.Peek());
                //Megnézük a verem tartalmát ha "e" akkor pop olunk 
                if (Verem.Peek() == "e")
                {
                    Verem.Pop();
                }
                //beállitjuk az veremPop értékét a Verem tetején levő értékre
                string veremPop = Verem.Pop();
                //x,y értéket beállitjuk a hozzájuk tartozó kulcspároknak 
                try
                {
                    x = Matrix.XAxis[veremPop];
                    y = Matrix.YAxis[char.ToString(Input[I])];
                }
                // ha nem tudjuk beállitani akkor hibával kilépünk és vissza adunk egy stringet
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return "Hibás bemenet";
                }
                //Ha a Matrix x,y rácsában pop műveletet olvasunk akkor növeljük az I értékét eggyel
                if (Matrix.MatrixGet[x, y] == "pop")
                {
                    I++;
                }
                // ha a Matrix x,y rácsában pop null akkor hibával kilépünk és vissza adunk egy stringet
                else if (Matrix.MatrixGet[x, y] == null)
                {
                    return "Hibás bemenet";
                }
                //különben Matrix x,y rácsának tartalmát szétszedjük ','ként 
                else
                {
                    string[] splited = Matrix.MatrixGet[x, y].Split(',');
                    //HA aszétszedet érték tartalmaz pontot akkor azt tovább bontjuk és a kapott tönbön visszafelé haladva betöltük a verembe
                    if (splited[0].Contains("."))
                    {
                        string[] dotSplitted = splited[0].Split('.');
                        for (int j = dotSplitted.Length - 1; j >= 0; j--)
                        {
                            Verem.Push(dotSplitted[j]);
                        }
                    }
                    //különben a Veremhez hozzá adjuk a splited első elemét
                    else
                    {
                        Verem.Push(splited[0]);
                    }
                    // A szabályhoz hozzáfűzzük a splited hosszánál eggyel kissebbszámot 
                    Szabaly += splited[splited.Length - 1];
                }
            }//Vissza adjuk a Szabályt
            return Szabaly;
        }
    }
}