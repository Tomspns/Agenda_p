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
    /// Logique d'interaction pour Page_Contacts.xaml
    /// </summary>
    public partial class Page_Contacts : UserControl
    {
        public Page_Contacts()
        {
            InitializeComponent();
            LoadContacts();
        }

        private void LoadContacts()
        {
            using (var context = new AgendaTomContext())
            {
                var contacts = context.Contacts.ToList(); // Récupère tous les contacts
                ContactsListView.ItemsSource = contacts; // Lier les données au ListView
            }
        }
    }
}
