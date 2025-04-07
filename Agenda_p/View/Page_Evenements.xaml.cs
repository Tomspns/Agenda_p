using Google.Apis.Calendar.v3.Data;
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
    /// Logique d'interaction pour Page_Evenements.xaml
    /// </summary>
    public partial class Page_Evenements : UserControl // Utiliser UserControl si tu utilises un UserControl
    {
        public Page_Evenements()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            try
            {
                Events events = GoogleCalendarService.ListUpcomingEvents();
                foreach (var eventItem in events.Items)
                {
                    string eventSummary = eventItem.Summary ?? "Aucun titre"; // Gérer le cas où Summary pourrait être null
                    DateTime eventStart = eventItem.Start?.DateTime ?? DateTime.Now; // Gérer le cas où Start pourrait être null
                    EventsListBox.Items.Add($"{eventSummary} ({eventStart})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des événements : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
