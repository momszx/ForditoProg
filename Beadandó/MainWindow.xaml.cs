using System.Collections.Generic;

namespace Beadandó
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Automata automata = new Automata();
        public MainWindow()
        {
            //feltöljuk a nézetet a mátri alapján
            List<List<string>> lsts = new List<List<string>>();
            for (int i = 0; i < 11; i++)
            {
                lsts.Add(new List<string>());
                for (int j = 0; j < 6; j++)
                {
                    string temp = automata.Matrix.MatrixGet[i, j];
                    if (temp != null)
                    {
                        if (temp.Contains("."))
                        {
                            temp.Replace(".", string.Empty);
                        }
                    }
                    lsts[i].Add(temp);
                }
            }
            InitializeComponent();
            lst.ItemsSource = lsts;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //Beolvassuk a input mező tartalmát pl 21+3*1
            string input = InPutText.Text;
            //Az automata osztály segitségével az inputot átkonvertáljuk egyszerűsitet názetre és beállitjuk a vermet 
            automata.AutomataSetter(input);
            //Az automata input mezőjét kiolvasva beállitjuk a egyszerüsitett label értékét pl i+i*i#
            simpleInputTextLable.Content = automata.Input;
            //Le generáljuk a kimeneti értéket és a vissza térési értéket beállitjuk a labelnél pl i+i*i#->148624858
            string output = automata.ToOutPut();
            SuccesLable.Content = output;
        }
    }
}