using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_p.DAO
{
    class UserAddDao
    {
        private readonly AgendaTomContext _context;

        public UserAddDao()
        {
            _context = new AgendaTomContext();
        }

        public void AddUser(Contact newUser)
        {
            _context.Contacts.Add(newUser);
            _context.SaveChanges(); // Enregistre les changements dans la base de données
        }
    }
}
