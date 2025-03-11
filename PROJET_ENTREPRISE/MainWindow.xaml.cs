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

namespace PROJET_ENTREPRISE;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnADDrapelle_click(object sender, RoutedEventArgs e)
    {
        if (txtAJOUTRAPELLE.Text != "" && dpDateRappel.SelectedDate != null)
        {
            lstRAPELLE.Items.Add(txtAJOUTRAPELLE.Text + " - " + dpDateRappel.SelectedDate.Value.ToShortDateString());
            txtAJOUTRAPELLE.Clear();
            dpDateRappel.SelectedDate = null;
            ATTENTION();
        }
    }







    private void ATTENTION()
    {
        DateTime? dateProche = null;
        string nomProche = "";

        foreach (string item in lstRAPELLE.Items)
        {
            string[] DATE = item.Split(" - ");
            if (DATE.Length == 2 && DateTime.TryParse(DATE[1], out DateTime date))
            {
                if (dateProche == null || date < dateProche)
                {
                    dateProche = date;
                    nomProche = DATE[0];
                }
            }
        }

        if (dateProche != null)
            txtPROCHAIN.Text = $"ATTENTION : PROCHAIN PAIEMENT DE {nomProche} LE {dateProche.Value.ToShortDateString()}";
        else
            txtPROCHAIN.Text = "ATTENTION : PROCHAIN PAIEMENT - AUCUN";
    }


}