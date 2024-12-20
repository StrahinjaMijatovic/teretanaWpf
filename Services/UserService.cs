﻿using ProjekatGNS.Izuzeci;
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
    public class UserService : IUserService
    {
        public void DeleteUser(string email)
        {

            RegistrovaniKorisnik registrovaniKorisnik = Util.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(email));
            if (registrovaniKorisnik == null)
            {
                throw new UserNotFoundException($"Ne postoji korisnik sa emailom: {email}");
            }

            registrovaniKorisnik.Aktivan = false;
            Console.WriteLine("Uspesno obrisan korisnik sa emailom:" + email);


            Util.Instance.SacuvajEntitet("korisnici.txt");
        }

        public void ReadUsers(string filename)
        {
            Util.Instance.Korisnici = new ObservableCollection<RegistrovaniKorisnik>();

            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');

                    Enum.TryParse(korisnikIzFajla[8], out ETipKorisnika tip);
                    Enum.TryParse(korisnikIzFajla[10], out ECiljKlijenta cilj);       
                    Boolean.TryParse(korisnikIzFajla[11], out Boolean status);
                    RegistrovaniKorisnik registrovaniKorisnik = new RegistrovaniKorisnik
                    {

                        Ime = korisnikIzFajla[0],
                        Prezime = korisnikIzFajla[1],
                        Email = korisnikIzFajla[2],
                        Telefon = korisnikIzFajla[3],
                        Adresa = korisnikIzFajla[4],
                        BrKartice = korisnikIzFajla[5],
                        OsnovniJezik = korisnikIzFajla[6],
                        DodatniJezik = korisnikIzFajla[7],
                        TipKorisnika = tip,
                        Lozinka = korisnikIzFajla[9],
                        CiljKlijenta = cilj,
                        Aktivan = status
                    }; 

                    Util.Instance.Korisnici.Add(registrovaniKorisnik);
                }
            }
        }

        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (RegistrovaniKorisnik registrovaniKorisnik in Util.Instance.Korisnici)
                {
                    file.WriteLine(registrovaniKorisnik.KorisnikZaUpisUFajl());
                }
            }
        }
    }
}
