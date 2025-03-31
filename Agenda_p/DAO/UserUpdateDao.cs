using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_p.DAO
{
    class UserUpdateDao
    {
        private readonly AgendaTomContext _context;

        public UserUpdateDao()
        {
            _context = new AgendaTomContext();
        }

        public void UpdateUser(Contact updatedUser)
        {
            var existingUser = _context.Contacts.Find(updatedUser.IdContacts);
            if (existingUser != null)
            {
                existingUser.Nom = updatedUser.Nom; // Exemple pour un champ 'Name'
                existingUser.Email = updatedUser.Email; // Exemple pour un champ 'Email'
                                                        // Ajoutez d'autres propriétés à mettre à jour ici

                _context.SaveChanges(); // Enregistre les changements dans la base de données
            }
        }
    }
}
