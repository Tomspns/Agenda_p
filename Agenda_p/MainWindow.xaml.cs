using Agenda_p.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda_p;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Supprimer la navigation initiale vers Page_Contacts
        // MainFrame.Navigate(new Page_Contacts()); // Commentée ou supprimée
    }

    private void BTN_Accueil_Click(object sender, RoutedEventArgs e)
    {
        Window_content.Children.Clear();
        Page_Accueil pageaccueil = new Page_Accueil();
        Window_content.Children.Add(pageaccueil);
    }

    private void BTN_Evenements_Click(object sender, RoutedEventArgs e)
    {
        Window_content.Children.Clear();
        Page_Evenements pageevenements = new Page_Evenements();
        Window_content.Children.Add(pageevenements);
    }

    private void BTN_Contacts_Click(object sender, RoutedEventArgs e)
    {
        Window_content.Children.Clear();
        Page_Contacts pagecontacts = new Page_Contacts();
        Window_content.Children.Add(pagecontacts); // Affiche les contacts ici
    }

    private void BTN_ToDoList_Click(object sender, RoutedEventArgs e)
    {
        Window_content.Children.Clear();
        Page_Accueil pageaccueil = new Page_Accueil(); // Remplacement ici
        Window_content.Children.Add(pageaccueil);
    }

    private void BTN_Messages_Click(object sender, RoutedEventArgs e)
    {
        Window_content.Children.Clear();
        Page_Accueil pageaccueil = new Page_Accueil();
        Window_content.Children.Add(pageaccueil);
    }

    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    // Méthode pour maximiser ou restaurer la fenêtre
    private void MaximizeButton_Click(object sender, RoutedEventArgs e)
    {
        if (this.WindowState == WindowState.Normal)
        {
            this.WindowState = WindowState.Maximized;
        }
        else
        {
            this.WindowState = WindowState.Normal;
        }
    }

    // Méthode pour fermer la fenêtre
    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void SidebarToggle_Checked(object sender, RoutedEventArgs e)
    {
        Sidebar.Width = 250; // Ajuste la largeur de la barre latérale pour l'afficher
    }

    private void SidebarToggle_Unchecked(object sender, RoutedEventArgs e)
    {
        Sidebar.Width = 0; // Réduit la largeur à 0 pour masquer la barre latérale
    }
}