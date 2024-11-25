using ProjekatGNS.Model;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekatGNS.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private EStatus status;
        public LoginWindow()
        {
            InitializeComponent();
            Util.Instance.Initialize();
            Util.Instance.CitanjeEntiteta("korisnici.txt");
            Util.Instance.CitanjeEntiteta("treneri.txt");
            Util.Instance.CitanjeEntiteta("klijenti.txt");
            Util.Instance.CitanjeEntiteta("treninzi.txt");
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = TxtEmail.Text;
            string lozinka = PBPassword.Password;

            if (email.Equals("") || lozinka.Equals(""))
            {
                MessageBox.Show("Niste uneli sve podatke!");

            }
            else
            {
                RegistrovaniKorisnik korisnik = Util.Instance.Login(email, lozinka);
                if (korisnik == null)
                {
                    MessageBox.Show("Neispravan email ili lozinka.");

                }
                else if (korisnik != null)
                {
                    Params.UlogovaniKorisnik = korisnik;
                    PrikazUlogovanogKorisnikaWindow ulogovaniKorisnikWindow = new PrikazUlogovanogKorisnikaWindow(korisnik);
                    this.Close();
                    ulogovaniKorisnikWindow.Show();

                }

            }


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
