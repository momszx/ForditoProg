using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Beadandó
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        Automata automata = new Automata();
        public MainWindow()
        {
            List<List<string>> lsts = new List<List<string>>();

            for (int i = 0; i < 11; i++)
            {
                lsts.Add(new List<string>());

                for (int j = 0; j < 6; j++)
                { 
                    string temp = automata.Matrix.MatrixGet[i, j];
                    if (temp!=null)
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
            string input = InPutText.Text;
            automata.AutomataSetter(input);
            simpleInputTextLable.Content = automata.Input;
            string output = automata.asd();
            SuccesLable.Content = output;
        }
    }
}