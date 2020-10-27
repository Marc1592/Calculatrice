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
using System.IO;
using Microsoft.Win32;

namespace Apllication1
{

    // hfuizdfuzuzghoiuzhd ou PUSH 22222222222

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fluxData.ItemsSource = Buisness.clients;
        }

        public void Dysplay()
        {
            List<RéparationPhone> list = new List<RéparationPhone>();
        }

        public void MenuItem_Add(object sender, RoutedEventArgs e)
        {
            WindowAdd win2 = new WindowAdd();
            win2.Show();
        }

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            Buisness.clients.Clear();
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = openFileDialog.Filter = "CSV Format (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                Buisness.clients.Clear();
                String[] importfile = File.ReadAllLines(openFileDialog.FileName);
                openCSVfile(importfile, fluxData);
            }
        }

        public static void openCSVfile (string[] importfile, DataGrid dg)
        {
            int tailleTab = importfile.Length;
            for (int i = 0; i < tailleTab; i++)
            {
                String ligne = importfile[i];
                String[] morceau = ligne.Split(',');
                String nom = morceau[1];
                String prenom = morceau[2];
                String modelPhone = morceau[3];
                String mobile = morceau[4];
                String email = morceau[5];
                String dateRecu = morceau[6];
                String description = morceau[7];
                String status = morceau[8];
                String prixReparation = morceau[9];
               

                Buisness.clients.Add(new RéparationPhone (nom, prenom, modelPhone, mobile, email, dateRecu, description, status, prixReparation));

            }
            dg.ItemsSource = Buisness.clients;
        }


        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = saveFileDialog.Filter = "CSV Format (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, toCSV(fluxData));
                    string savefile = saveFileDialog.FileName;
                }          
        }

        public static String Save (DataGrid dg, String savefile)
        {
            if(savefile == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = saveFileDialog.Filter = "CSV Format (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, toCSV(dg));
                    savefile = saveFileDialog.FileName;
                }
            }
            else
            {
                File.WriteAllText(savefile, toCSV(dg));
            }
            return savefile;
        }

        private static string toCSV (DataGrid dg)
        {
            dg.ItemsSource = Buisness.clients;
            dg.SelectAllCells();
            dg.ClipboardCopyMode = DataGridClipboardCopyMode.ExcludeHeader;
            ApplicationCommands.Copy.Execute(null, dg);
            dg.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);

            return result;
        }
              
        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }





        private void MenuItem_Click_AddLine(object sender, RoutedEventArgs e)
        {

            RéparationPhone phone = new RéparationPhone("", "", "", "", "",
                                                     "", "", "", "");
            Buisness.clients.Add(phone);
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_AddLine(object sender, RoutedEventArgs e)
        {
            RéparationPhone phone = new RéparationPhone("", "", "", "", "",
                                                     "", "", "", "");
            Buisness.clients.Add(phone);
        }

        private void MenuItem_Click_APropos(object sender, RoutedEventArgs e)
        {
            WindowAP win3 = new WindowAP();
            win3.Show();
        }
    }
}
