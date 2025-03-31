using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var userToDelete = _context.Contacts.Find(userId);
            if (userToDelete != null)
            {
                _context.Contacts.Remove(userToDelete);
                _context.SaveChanges(); // Enregistre les changements dans la base de données
            }
        }
    }
}
