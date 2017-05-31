using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadanie_2_Siec_Neuronowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random random = new Random();
        ObservableCollection<KeyValuePair<double, double>> Seria1 = new ObservableCollection<KeyValuePair<double, double>>();
        ObservableCollection<KeyValuePair<double, double>> Seria2 = new ObservableCollection<KeyValuePair<double, double>>();
        public string filePath { get; set; }
        public string filePathToTest { get; set; }

        public Siec siec { get; set; }
        public List<DanaTestowa> DaneTreningowe { get; set; }
        public List<DanaTestowa> DaneTestowe { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            seria1.DataContext = Seria1;
            seria2.DataContext = Seria2;
            GenerujDaneTreningowe();
            GenerujDaneTestowe();
        }

        private void selectFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select file with data";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == true)
            {
                filePath = openFileDialog1.FileName;
                selectedFileTextBox.Text = System.IO.Path.GetFileName(filePath);
            }
        }

        private void selectFileToTestButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Select file with data";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == true)
            {
                filePathToTest = openFileDialog1.FileName;
                selectedFileToTestTextBox.Text = System.IO.Path.GetFileName(filePathToTest);
            }
        }

        private void wczytajDane(int iloscWejsc, int iloscWyjsc, string filePath, bool czyTrening = true)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (czyTrening == true)
                    DaneTreningowe = new List<DanaTestowa>();
                else
                    DaneTestowe = new List<DanaTestowa>();

                foreach (var line in lines)
                {
                    var temp = line.Replace(".", ",");
                    var numbers = temp.Split(new Char[] { ';', ' ' }).Select(double.Parse).ToList();
                    if (numbers.Count == (iloscWejsc + iloscWyjsc)) ////sprawdzamy czy plik zgodny z tym co deklarowal uzytkownik
                    {
                        DanaTestowa dana = new DanaTestowa()
                        {
                            IloscWejsc = iloscWejsc,
                            IloscWyjsc = iloscWyjsc,
                            Wejscia = numbers.Take(iloscWejsc).ToList(),
                            Wyjscia = numbers.GetRange(iloscWejsc, iloscWyjsc)
                        };
                        if (czyTrening == true)
                            DaneTreningowe.Add(dana);
                        else
                            DaneTestowe.Add(dana);
                    }
                    else
                    {
                        string messageBoxText = "Błędny format pliku";
                        string caption = "Problem z plikiem";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;
                        MessageBox.Show(messageBoxText, caption, button, icon);
                        Debug.WriteLine("Błędny format danych testowcyh w pliku");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during reading from file " + ex);
            }
        }

        private void stworzSiecButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Seria1.Clear();
                Seria2.Clear();
                /////Wczytywanie danych z formularza
                double epsilon = epsilonTextBox.Value.Value;
                int ileWarstw = warstwyTextBox.Value.Value + 1;
                var ileNeuronowNaWarstwy = iloscNeuronowTextBox.Text.Split(';').Select(Int32.Parse).ToList();
                int iloscWejsc = iloscWejscTextBox.Value.Value;
                int iloscWyjsc = iloscWyjscTextBox.Value.Value;
                double momentum = momentumTextBox.Value.Value;
                double krokNauki = krokNaukiTextBox.Value.Value;
                bool czyBias = biasCheckBox.IsChecked.Value;
                //////////////////////////////////////////////////

                siec = new Siec(iloscWejsc, iloscWyjsc);
                for (int i = 0; i < ileWarstw; i++)
                {
                    if (i == 0) /// pierwsza warstwa ukryta
                    {
                        Warstwa warstwa = new Warstwa(i, ileNeuronowNaWarstwy[i]);
                        warstwa.PoprzedniaWarstwa = null;
                        for (int j = 0; j < warstwa.IloscNeuronow; j++)
                        {
                            Neuron neuron = new Neuron(iloscWejsc, krokNauki, czyBias, momentum,true);
                            warstwa.DodajNeuron(neuron);

                        }
                        warstwa.rodzajWarstwy = Warstwa.RodzajWarstwy.Ukryta;
                        siec.Warstwy.Add(warstwa);
                        continue;
                    }
                    else
                    {
                        Warstwa warstwa = null;
                        if (i == ileWarstw - 1) ///ostatnia warstwa - wyjsciowa ktora daje wyniki i musi miec tyle neuronow ile wyjsc
                        {
                            warstwa = new Warstwa(i, iloscWyjsc);
                            warstwa.NastepnaWarstwa = null;
                            warstwa.rodzajWarstwy = Warstwa.RodzajWarstwy.Wyjsciowa;
                        }
                        else  ////// pozostałe warstwy - ukryte 
                        {
                            warstwa = new Warstwa(i, ileNeuronowNaWarstwy[i]);
                            warstwa.rodzajWarstwy = Warstwa.RodzajWarstwy.Ukryta;
                        }

                        var warstwaPoprzednia = siec.Warstwy.FirstOrDefault(x => x.Id == i - 1);
                        warstwaPoprzednia.NastepnaWarstwa = warstwa;
                        warstwa.PoprzedniaWarstwa = warstwaPoprzednia;
                        for (int j = 0; j < warstwa.IloscNeuronow; j++)
                        {
                            Neuron neuron = new Neuron(warstwa.PoprzedniaWarstwa.IloscNeuronow, krokNauki, czyBias, momentum,true); //// !!!!!!
                            warstwa.DodajNeuron(neuron);

                        }
                        siec.Warstwy.Add(warstwa);
                    }
                }
                siec.Warstwy.FirstOrDefault(x => x.rodzajWarstwy == Warstwa.RodzajWarstwy.Wyjsciowa).Neurony[0].CzySigmoidalnaAktywacja = false;
                string messageBoxText = "Sieć została poprawnie utworzona !!!";
                string caption = "Sieć utworzona";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Nieznany błąd !!!" + ex);
            }


        }

        private void testSieciButton_Click(object sender, RoutedEventArgs e)
        {
            if (siec != null)
            {
                wczytajDane(siec.IloscWejsc, siec.IloscWyjsc, this.filePathToTest, false);
                PrzeprowadzTestSieci();
                string messageBoxText = "Test zakończony. Zajrzyj do pliku z logami.";
                string caption = "Test";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void PrzeprowadzTestSieci()
        {
            Seria1.Clear();
            Seria2.Clear();
            string path = @"../../Logi/Wynik_testu_sieci.txt";
            System.IO.File.Create(path).Close();
            var wyniki=siec.TestSieci(DaneTestowe);  /// dokonczyc implementacje metody
            foreach (var punkt in DaneTestowe)
            {
                Seria1.Add(new KeyValuePair<double, double>(punkt.Wejscia[0], punkt.Wyjscia[0]));
            }
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < wyniki.Count; i = i + 1)
            {
                builder.AppendLine(String.Format("Wejście : {0} Wartość otrzymana : {1} Wartość spodziewana : {2}", wyniki[i].Key, wyniki[i].Value, Math.Sqrt(wyniki[i].Key)));
                Seria2.Add(new KeyValuePair<double, double>(wyniki[i].Key, wyniki[i].Value));
            }
            File.WriteAllText("../../wyniki_testu.txt", builder.ToString());
        }

        private void treningSieciButton_Click(object sender, RoutedEventArgs e)
        {
            if (siec != null)
            {
                siec.IloscEpok = epokiTextBox.Value.Value;
                siec.Epsilon = epsilonTextBox.Value.Value;
                Seria1.Clear();
                Seria2.Clear();
                wczytajDane(siec.IloscWejsc, siec.IloscWyjsc, this.filePath, true);
                PrzejdzWszystkieEpoki();
                string messageBoxText = "Trening ukończony !!!";
                string caption = "Trening";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(messageBoxText, caption, button, icon);
            }
        }

        private void PrzejdzWszystkieEpoki()
        {
            string path = @"../../Logi/Epoki.txt";
            string pathToError = @"../../Logi/Bledy.txt";
            System.IO.File.Create(path).Close();
            System.IO.File.Create(pathToError).Close();
            for (int i = 0; i < siec.IloscEpok; i++)
            {
                double blad = 0;
                if (i % 100 == 0 || i == siec.IloscEpok - 1)
                {
                    if (i == siec.IloscEpok - 1)
                    {
                        string patha = @"../../Logi/wyniki__.txt";
                        System.IO.File.Create(patha).Close();
                        siec.LiczEpoka(DaneTreningowe);
                    }
                    File.AppendAllText(path, "-------------------Epoka " + (i + 1) + Environment.NewLine);
                    blad = siec.LiczEpoka(DaneTreningowe );
                    Seria1.Add(new KeyValuePair<double, double>(i + 1, blad));
                    File.AppendAllText(pathToError, "-------------------Epoka " + (i + 1) + Environment.NewLine);
                    File.AppendAllText(pathToError, "Błąd sieci równy : " + blad + Environment.NewLine);
                }
                else
                {
                    blad = siec.LiczEpoka(DaneTreningowe);
                }

                if (blad < siec.Epsilon)
                    break;
            }
        }

        private void GenerujDaneTreningowe()
        {
            StringBuilder builder = new StringBuilder();
            List<double> randomNumbers = new List<double>();
            for (int i = 1 ; i < 101; i++)
            {
                var number= random.NextDouble() * 99 + 1;
                while (randomNumbers.Contains(number))
                {
                    //number = random.Next(1, 100);
                    number = random.NextDouble() * 99 + 1;

                }
                randomNumbers.Add(number);
                builder.AppendLine(number + " " + Math.Sqrt(number));
            }
            string path = "../../Dane_Treningowe.txt";
            File.WriteAllText(path,builder.ToString());
            filePath = System.IO.Path.GetFullPath(path);
            selectedFileTextBox.Text = System.IO.Path.GetFileName(path);
        }

        private void GenerujDaneTestowe()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 1; i < 101; i++)
            {
                builder.AppendLine(i + " " + Math.Sqrt(i));
            }
            string path = "../../Dane_Testowe.txt";
            File.WriteAllText(path, builder.ToString());
            filePathToTest = System.IO.Path.GetFullPath(path);
            selectedFileToTestTextBox.Text = System.IO.Path.GetFileName(path);
        }


    }
}
