using System;
using System.Collections.Generic;
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
using Microsoft.Win32;
using Osztalyaim;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tartaly> tartalyok = new List<Tartaly>();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        public MainWindow()
        {
            InitializeComponent();
            rdoTeglatest.IsChecked = true;
        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = false;
            txtBel.IsEnabled = false;
            txtCel.IsEnabled = false;
            txtAel.Text = "10";
            txtBel.Text = "10";
            txtCel.Text = "10";
        }

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = true;
            txtBel.IsEnabled = true;
            txtCel.IsEnabled = true;
            txtAel.Text = "";
            txtBel.Text = "";
            txtCel.Text = "";
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            Tartaly Ujtartaly;
            if (rdoKocka.IsChecked == true)
            {
                Ujtartaly = new Tartaly(txtNev.Text);
            }
            else
            {   
                Ujtartaly = new Tartaly(txtNev.Text,Convert.ToInt32(txtAel.Text), Convert.ToInt32(txtBel.Text), Convert.ToInt32(txtCel.Text));
            }
            tartalyok.Add(Ujtartaly);
            lbTartalyok.Items.Add(Ujtartaly.Info());
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                    foreach (var item in tartalyok)
                    {
                        sw.WriteLine(item.Info());
                    }
                    sw.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(Convert.ToString(err));
                throw;
            }
        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            if(lbTartalyok.SelectedIndex != -1)
            {
                tartalyok[lbTartalyok.SelectedIndex].DuplazMeretet();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
            else
            {
                MessageBox.Show("Válasszon ki vmit!");
            }
        }

        private void btnLeenged_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex != -1)
            {
                tartalyok[lbTartalyok.SelectedIndex].TeljesLeengedes();
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
            else
            {
                MessageBox.Show("Válasszon ki vmit!");
            }
        }

        private void btntolt_Click(object sender, RoutedEventArgs e)
        {
            if (lbTartalyok.SelectedIndex != -1)
            {
                tartalyok[lbTartalyok.SelectedIndex].Tolt(Convert.ToDouble(txtMennyitTolt.Text));
                lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
            }
            else
            {
                MessageBox.Show("Válasszon ki vmit!");
            }
        }
    }
} 