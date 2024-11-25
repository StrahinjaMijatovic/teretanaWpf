using ProjekatGNS.Model;
using ProjekatGNS.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjekatGNS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EStatus status;
        public MainWindow()
        {
            InitializeComponent();

            Util.Instance.CitanjeEntiteta("korisnici.txt");
            Util.Instance.CitanjeEntiteta("treneri.txt");
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Hide();
            loginWindow.Show();
        }
        private void btnRegistracija_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik registrovaniKorisnici = new RegistrovaniKorisnik();
            DodajIzmeniKlijentaWindow dodajIzmeniKlijenta = new DodajIzmeniKlijentaWindow(status, registrovaniKorisnici);
            dodajIzmeniKlijenta.cmbTipKorisnika.IsEnabled = true;

            if (!(bool)dodajIzmeniKlijenta.ShowDialog())
            {

            }
            this.Show();
        }

    }
}
