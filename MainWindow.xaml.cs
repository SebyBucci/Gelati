using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static bucci.sebastian._4i.Gelati.Ingrediente;

namespace bucci.sebastian._4i.Gelati
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            Gelati gelati;
            Ingredienti ingredienti;

            public MainWindow()
            {
                InitializeComponent();
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                try
                {

                    gelati = new("Gelati.csv");
                    dgGelati.ItemsSource = gelati;

                    ingredienti = new("Ingredienti.csv");
                    statusbar.Text = $"Ho letto dal file" +

                         $"{gelati.Count} gelati e " +
                         $"{ingredienti.Count} ingredienti";

                statusbar.Text = $"Ho letto dal file {gelati.Count} gelati";


                

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Errore: " + ex.Message);
                }
            }
            private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                Gelato p = e.AddedItems[0] as Gelato;
                if (p != null)
                {
                    statusbar.Text = $" Hai selezionato {p.Descrizione} {p.Prezzo}";

                Ingredienti ingredientiFiltrati = new();
                    foreach (var item in ingredienti)
                        if (item.idGelato == p.idGelato)
                        ingredientiFiltrati.Add(item);

                    dgIngredienti.ItemsSource = ingredientiFiltrati;
                }

            }


            private void dgIngredienti_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }
        }
    }