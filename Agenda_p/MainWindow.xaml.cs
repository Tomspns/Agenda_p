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
        Window_content.Children.Add(pagecontacts);
    }

    private void BTN_ToDoList_Click(object sender, RoutedEventArgs e)
    {
        Window_content.Children.Clear();
        Page_Accueil pageaccueil = new Page_Accueil();
        Window_content.Children.Add(pageaccueil);
    }

    private void BTN_Messages_Click(object sender, RoutedEventArgs e)
    {
        Window_content.Children.Clear();
        Page_Accueil pageaccueil = new Page_Accueil();
        Window_content.Children.Add(pageaccueil);
    }
}