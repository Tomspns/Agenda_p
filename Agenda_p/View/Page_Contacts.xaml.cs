using Agenda_p.DAO;
using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace Agenda_p.View
{
    public partial class Page_Contacts : UserControl
    {
        private List<Contact> contacts = new List<Contact>();

        public Page_Contacts()
        {
            InitializeComponent();
            LoadContacts();
        }

        public void LoadContacts()
        {
            using (var context = new AgendaTomContext())
            {
                contacts = context.Contacts.ToList();
                ContactsListView.ItemsSource = contacts;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = SearchTextBox.Text.ToLower();

            var filteredContacts = contacts
                .Where(c => (c.Nom != null && c.Nom.ToLower().Contains(searchTerm)) ||
                            (c.Prénom != null && c.Prénom.ToLower().Contains(searchTerm)) ||
                            (c.Email != null && c.Email.ToLower().Contains(searchTerm)))
                .ToList();

            ContactsListView.ItemsSource = filteredContacts;
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContactsListView.SelectedItem is Contact selectedContact)
            {
                UserDeleteDao userDeleteDao = new UserDeleteDao();
                userDeleteDao.DeleteUser(selectedContact.IdContacts);
                LoadContacts();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un contact à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            // Ouvrir la page d'ajout d'utilisateur
            var addUserPage = new Page_AddUser();
            var window = Window.GetWindow(this); // Récupérer la fenêtre principale
            window.Content = addUserPage; // Changer le contenu de la fenêtre
        }
    }
}