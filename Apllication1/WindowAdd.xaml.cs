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
using System.Windows.Shapes;

namespace Apllication1
{
    /// <summary>
    /// Interaction logic for WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        
        public WindowAdd()
        {
            InitializeComponent();

        }
       
        public void Button_Click_Add(object sender, RoutedEventArgs e)
        {     

            RéparationPhone phone = new RéparationPhone(nom.Text, prenom.Text, modelPhone.Text, mobile.Text, email.Text,
                                                     dateRecu.Text, description.Text, status.Text, prixReparation.Text);
            Buisness.clients.Add(phone);

            this.Close();

        }

        private void MenuItem_Click_New(object sender, RoutedEventArgs e)
        {
            nom.Clear();
            prenom.Clear();
            modelPhone.Clear();
            mobile.Clear();
            email.Clear();
            dateRecu.Clear();
            description.Clear();
            status.Clear();
            prixReparation.Clear();

        }

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
