using Agenda_p.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Agenda_p.View
{
    /// <summary>
    /// Logique d'interaction pour Page_Contacts.xaml
    /// </summary>
    public partial class Page_Contacts : UserControl
    {
        private List<Contact> contacts = new List<Contact>(); // Initialise contacts

        public Page_Contacts()
        {
            InitializeComponent();
            LoadContacts();
        }

        public void LoadContacts()
        {
            using (var context = new AgendaTomContext())
            {
                contacts = context.Contacts.ToList(); // Récupère tous les contacts
                ContactsListView.ItemsSource = contacts; // Lier les données au ListView
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Vérifie si contacts est initialisé
                if (contacts == null || !contacts.Any())
                {
                    MessageBox.Show("La liste des contacts n'est pas initialisée ou vide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string searchTerm = SearchTextBox.Text.ToLower(); // Récupère le texte de recherche

                var filteredContacts = contacts
                    .Where(c => (c.Nom != null && c.Nom.ToLower().Contains(searchTerm)) || // Filtrer par nom
                                (c.Prénom != null && c.Prénom.ToLower().Contains(searchTerm)) || // Filtrer par prénom
                                (c.Email != null && c.Email.ToLower().Contains(searchTerm))) // Filtrer par email
                    .ToList();

                ContactsListView.ItemsSource = filteredContacts; // Met à jour le ListView avec les résultats filtrés
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            // Crée une nouvelle instance de la page d'ajout de contact
            var addContactPage = new Page_AddUser();

            // Naviguer à la page d'ajout de contact
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainFrame.Navigate(addContactPage); // Utiliser MainFrame pour naviguer
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Vérifie si un contact est sélectionné
            if (ContactsListView.SelectedItem is Contact selectedContact)
            {
                UserDeleteDao userDeleteDao = new UserDeleteDao();
                userDeleteDao.DeleteUser(selectedContact.IdContacts); // Supprime l'utilisateur sélectionné

                // Recharger la liste des contacts après suppression
                LoadContacts();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un contact à supprimer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Supprimer les gestionnaires MouseEnter et MouseLeave car ils ne sont plus nécessaires

        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                {
                    return typedChild;
                }
                var childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }
            return null;
        }
    }
}