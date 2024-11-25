using ProjekatGNS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGNS.Services
{
    class TrenerService: ITrenerService
    {
        public List<RegistrovaniKorisnik> FindallClients(string email)
        {
            throw new NotImplementedException();
        }

        public Trener NadjiTreneraPrekoEmaila(string email)
        {

            foreach (Trener trener in Util.Instance.Treneri)
            {
                if (email.Equals(trener.Korisnik.Email))
                    return trener;

            }
            return null;
        }

        public void ReadUsers(string filename)
        {
            Util.Instance.Treneri = new ObservableCollection<Trener>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] trenerIzFajla = line.Split(';');
                    RegistrovaniKorisnik registrovaniKorisnik = Util.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(trenerIzFajla[2]));

                    Trener trener = new Trener
                    {

                        Korisnik = registrovaniKorisnik,

                    };

                    Util.Instance.Treneri.Add(trener);
                }
            }
        }

        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Trener instruktor in Util.Instance.Treneri)
                {
                    file.WriteLine(instruktor.TrenerZaUpisUFajl());
                }
            }
        }
    }
}
