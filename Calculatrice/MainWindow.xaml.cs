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

namespace Calculatrice
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DisplayTotal();
        }

        public void DisplayTotal()
        {
            int a;
            int b;
            int total = 0;
            String Hist = "";

            try {
                a = int.Parse(this.nombreA.Text);
                b = int.Parse(this.nombreB.Text);
            }
            catch (Exception)
            {
                a = 0;
                b = 0;
            }

            string s = "{0} {1} {2} = {3}";
            

            if (this.addi.IsChecked == true)
            {
                total = a + b;
                Hist = String.Format(s, a,"+", b, total);
              
            }
            else if(this.soust.IsChecked == true)
            {
                total = a - b;
                Hist = String.Format(s, a, "-", b, total);
            }
            else if (this.multi.IsChecked == true)
            {
                total = a * b;
                Hist = String.Format(s, a, "*", b, total);
            }
            else if (this.div.IsChecked == true)
            {
                total = a / b;
                Hist = String.Format(s, a, "/", b, total);
            }
         
            this.Total.Content = total;
            this.hist.Items.Add(Hist);

        }
     
        private void total_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                DisplayTotal();
            }
        }
     
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            this.hist.Items.Clear();
            this.affichageSelection.Content = "";

        }

        private void hist_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (hist.SelectedItem != null)
            {
                this.affichageSelection.Content = hist.SelectedItem.ToString();
            }
        }
        private void hist_KeyDown(object sender, KeyEventArgs e)
        {
            if (hist.SelectedItem != null)
            {
                this.affichageSelection.Content = hist.SelectedItem.ToString();
            }
        }

        private void hist_KeyUp(object sender, KeyEventArgs e)
        {
            if (hist.SelectedItem != null)
            {
                this.affichageSelection.Content = hist.SelectedItem.ToString();
            }
        }

        private void ann_Click(object sender, RoutedEventArgs e)
        {
            this.nombreA.Clear();
            this.nombreB.Clear();
            this.Total.Content = "";
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.hist.Items.Clear();
            this.affichageSelection.Content = "";

            this.nombreA.Clear();
            this.nombreB.Clear();
            this.Total.Content = "";
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true) { 

                String[] openFile = File.ReadAllLines(openFileDialog.FileName);

                int tailleFile = openFile.Length;

                for (int i = 0; i < tailleFile; i++)
                {
                    this.hist.Items.Add(openFile[i]);
                }
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            int tailleBox = this.hist.Items.Count;
            string[] content = new string[tailleBox];

            for (int i = 0; i < tailleBox; i++)
            {
                content[i] = this.hist.Items[i].ToString();
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllLines(saveFileDialog.FileName, content);
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void hist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
      
        public void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Window1 win2 = new Window1();
            win2.Show();
            win2.Owner = this;
        }
        public String Test()
        {
            return "works";
        }
    }  
}
