using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agenda_p.DAO
{
    class UserDeleteDao
    {
        private readonly AgendaTomContext _context;

        public UserDeleteDao()
        {
            _context = new AgendaTomContext();
        }

        public void DeleteUser(int userId)
        {
            try
            {
                var userToDelete = _context.Contacts.Find(userId);
                if (userToDelete != null)
                {
                    _context.Contacts.Remove(userToDelete);
                    _context.SaveChanges(); // Enregistre les changements dans la base de données
                    MessageBox.Show("Utilisateur supprimé avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Utilisateur introuvable.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
