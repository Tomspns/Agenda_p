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
    public partial class Page_AddUser : UserControl
    {
        public Page_AddUser()
        {
            InitializeComponent();
        }

        private void NomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NomPlaceholder.Visibility = string.IsNullOrWhiteSpace(NomTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PrénomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            PrénomPlaceholder.Visibility = string.IsNullOrWhiteSpace(PrénomTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailPlaceholder.Visibility = string.IsNullOrWhiteSpace(EmailTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void NuméroTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NuméroPlaceholder.Visibility = string.IsNullOrWhiteSpace(NuméroTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ConfirmAddContactButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupération des données saisies
            var newContact = new Contact
            {
                Nom = NomTextBox.Text,
                Prénom = PrénomTextBox.Text,
                Naissance = DateOnly.FromDateTime(NaissanceDatePicker.SelectedDate.Value), // Remplace par une date appropriée
                Email = EmailTextBox.Text,
                Numéro = NuméroTextBox.Text
            };

            UserAddDao userAddDao = new UserAddDao();
            userAddDao.AddUser(newContact); // Utilisation de la méthode d'ajout

            // Réinitialiser les champs après l'ajout
            NomTextBox.Clear();
            PrénomTextBox.Clear();
            NaissanceDatePicker.SelectedDate = null;
            EmailTextBox.Clear();
            NuméroTextBox.Clear();

            MessageBox.Show("Contact ajouté avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Retour à la page des contacts
            var contactsPage = new Page_Contacts();
            var window = Window.GetWindow(this); // Récupérer la fenêtre principale
            window.Content = contactsPage; // Changer le contenu de la fenêtre
        }
    }
}
