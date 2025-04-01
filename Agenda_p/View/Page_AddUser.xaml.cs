using Agenda_p.DAO;
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

namespace Agenda_p.View
{
    /// <summary>
    /// Logique d'interaction pour Page_AddUser.xaml
    /// </summary>
    public partial class Page_AddUser : UserControl
    {
        public Page_AddUser()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var firstName = FirstNameTextBox.Text;
            var lastName = LastNameTextBox.Text;
            var birthDate = BirthDatePicker.SelectedDate;

            if (birthDate.HasValue)
            {
                var contact = new Contact
                {
                    Prénom = firstName,
                    Nom = lastName,
                    Naissance = DateOnly.FromDateTime(birthDate.Value), // Conversion de DateTime à DateOnly
                    Email = EmailTextBox.Text,
                    Numéro = PhoneTextBox.Text
                };

                // Crée une instance de UserAddDao
                UserAddDao userAddDao = new UserAddDao();
                userAddDao.AddUser(contact); // Utilise l'instance pour ajouter le contact
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une date de naissance.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Retourner à la page précédente
            var parentPage = (Page_Contacts)Application.Current.MainWindow.Content;
            parentPage.LoadContacts(); // Recharge les contacts
        }
    }
}
