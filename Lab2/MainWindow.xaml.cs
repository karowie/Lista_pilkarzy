using System;
using System.Collections.Generic;
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

namespace Lab2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string archiwum = "archiwum.txt";

        public MainWindow()
        {
            TextBoxWithErrorProvider.BrushForAll = Brushes.Green;
            InitializeComponent();
            textBoxImie.SetFocus();
        }

        private bool IsNotEmpty(TextBoxWithErrorProvider tb)
        {
            if (tb.Text.Trim() == "")
            {
                tb.SetError("Pole nie może być puste!");
                return false;
            }
            tb.SetError("");
            return true;
        }

        private void buttonDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (IsNotEmpty(textBoxImie) & IsNotEmpty(textBoxNazwisko))
            {
                var pilkarz = new Pilkarz(textBoxImie.Text.Trim(), textBoxNazwisko.Text.Trim(), (uint)sliderWiek.Value, (uint)sliderWaga.Value);
                Boolean juzJest = false;
                foreach (var item in listBoxLista.Items)
                {
                    var p = item as Pilkarz;
                    if (p.isEqual(pilkarz))
                    {
                        juzJest = true;
                        break;
                    }
                }
                if (!juzJest)
                {
                    listBoxLista.Items.Add(pilkarz);
                    Clear();
                }
                else
                {
                    var dialog = MessageBox.Show($"{pilkarz.ToString()} znajduje się na liście. \n Czy wyczyścić formularz?", "Uwaga", MessageBoxButton.OKCancel);
                    if (dialog == MessageBoxResult.OK)
                    {
                        Clear();
                    }
                }
            }
        }

        private void buttonEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if((IsNotEmpty(textBoxImie))& (IsNotEmpty(textBoxNazwisko)))
            {
                var pilkarz = new Pilkarz(textBoxImie.Text.Trim(), textBoxNazwisko.Text.Trim(), (uint)sliderWiek.Value, (uint)sliderWaga.Value);
                Boolean juzJest = false;
                foreach (var item in listBoxLista.Items)
                {
                    var p = item as Pilkarz;
                    if (p.isEqual(pilkarz))
                    {
                        juzJest = true;
                        break;
                    }
                }
                if (!juzJest)
                {
                    var dialogResult = MessageBox.Show($"Czy na pewno chcesz zmienić dane piłkarza \n {listBoxLista.SelectedItem} \n na \n {pilkarz.ToString()}?", "Edycja", MessageBoxButton.YesNo);

                    if(dialogResult == MessageBoxResult.Yes)
                    {
                        (listBoxLista.Items[listBoxLista.SelectedIndex] as Pilkarz).podmien(pilkarz);
                        listBoxLista.Items.Refresh();
                    }
                    Clear();
                    listBoxLista.SelectedIndex = -1;
                }
                else
                {
                    var dialog = MessageBox.Show($"{pilkarz.ToString()} znajduje się na liście (niedokonałeś żadnej zmiany albo wpisałeś dane już istniejącego).", "Uwaga");
                }
            }

        }

        private void buttonUsun_Click(object sender, RoutedEventArgs e)
        {
            if ((IsNotEmpty(textBoxImie)) & (IsNotEmpty(textBoxNazwisko)))
            {
                var pilkarz = new Pilkarz(textBoxImie.Text.Trim(), textBoxNazwisko.Text.Trim(), (uint)sliderWiek.Value, (uint)sliderWaga.Value);
                Boolean juzJest = false;
                foreach (var item in listBoxLista.Items)
                {
                    var p = item as Pilkarz;
                    if (p.isEqual(pilkarz))
                    {
                        juzJest = true;
                        break;
                    }
                }
                if (juzJest)
                {
                    var dialogResult = MessageBox.Show($"Czy na pewno chcesz usunąć {listBoxLista.SelectedItem}?", "Usuwanie", MessageBoxButton.YesNo);

                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        listBoxLista.Items.RemoveAt(listBoxLista.SelectedIndex);
                        Clear();
                    }
                }
                else
                {
                    var dialog = MessageBox.Show($"{pilkarz.ToString()} nie znajduje się na liście, dlatego nie można go usunąć.", "Uwaga");
                }
            }
                
            

        }
        private void listBoxLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxLista.SelectedIndex > -1)
            {
                textBoxImie.SetError("");
                textBoxNazwisko.SetError("");
                Wczytaj((Pilkarz)listBoxLista.SelectedItem);
            }

        }

        private void Wczytaj(Pilkarz p)
        {
            textBoxImie.Text = p.Imie;
            textBoxNazwisko.Text = p.Nazwisko;
            sliderWaga.Value = p.Waga;
            sliderWiek.Value = p.Wiek;
            buttonEdytuj.IsEnabled = true;
            buttonUsun.IsEnabled = true;
            textBoxImie.SetFocus();
        }

        private void Clear()
        {
            textBoxImie.Text = "";
            textBoxNazwisko.Text = "";
            sliderWiek.Value = 25;
            sliderWaga.Value = 75;
            buttonEdytuj.IsEnabled = false;
            buttonUsun.IsEnabled = false;
            listBoxLista.SelectedIndex = -1;
            textBoxImie.SetFocus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Pilkarz[] listaPilkarzyZPliku= Pliki.CzytajPilkarzyZPliku(archiwum);
            if(listaPilkarzyZPliku != null)
            {
                foreach(var p in listaPilkarzyZPliku)
                {
                    listBoxLista.Items.Add(p);
                }
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int n = listBoxLista.Items.Count;
            Pilkarz[] listaPilkarzy = null;
            if (n>0)
            {
                listaPilkarzy = new Pilkarz[n];
                int i = 0;
                foreach (var p in listBoxLista.Items)
                {
                    listaPilkarzy[i++] = p as Pilkarz;
                }
            }
            Pliki.ZapisPilkarzyDoPliku(archiwum, listaPilkarzy);
        }
    }
}
