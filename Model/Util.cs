using ProjekatGNS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGNS.Model
{
    public sealed class Util
    {
        private static readonly Util instance = new Util();
        private IUserService userService;
        private ITrenerService trenerService;
        private IKlijentService klijentService;
        private ITreningService treningService;

        public ObservableCollection<RegistrovaniKorisnik> Korisnici { get; set; }
        public ObservableCollection<Trener> Treneri { get; set; }
        public ObservableCollection<Klijent> Klijenti { get; set; }
        public ObservableCollection<Trening> Treninzi { get; set; }

        private Util()
        {
            userService = new UserService();
            trenerService = new TrenerService();
            klijentService = new KlijentService();
            treningService = new TreningService();
        }

        static Util() { }

        public static Util Instance
        {
            get
            {
                return instance;
            }
        }

        public void Initialize()
        {

            Korisnici = new ObservableCollection<RegistrovaniKorisnik>();
            Treneri = new ObservableCollection<Trener>();
            Klijenti = new ObservableCollection<Klijent>();
            Treninzi = new ObservableCollection<Trening>();

        }

        public RegistrovaniKorisnik Login(string email, string lozinka)
        {
            foreach (RegistrovaniKorisnik korisnik in Korisnici)
            {
                if (korisnik.Email.Equals(email) && korisnik.Lozinka.Equals(lozinka))
                {
                    return korisnik;
                }
            }
            return null;
        }

        public void SacuvajEntitet(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                userService.SaveUsers(filename);
            }
            else if (filename.Contains("treneri"))
            {
                trenerService.SaveUsers(filename);
            }
            else if (filename.Contains("klijenti"))
            {
                klijentService.SaveUsers(filename);
            }
            else
            {
                treningService.SaveTrening(filename);
            }
        }

        public void CitanjeEntiteta(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                userService.ReadUsers(filename);
            }
            else if (filename.Contains("treneri"))
            {
                trenerService.ReadUsers(filename);
            }
            else if (filename.Contains("klijenti"))
            {
                klijentService.ReadUsers(filename);
            }
            else
            {
                treningService.ReadTrening(filename);
            }
        }

        public void DeleteUser(string email)
        {
            userService.DeleteUser(email);
        }

        public void DeleteTrening(int sifra)
        {
            treningService.DeleteTrening(sifra);
        }
    }
}
