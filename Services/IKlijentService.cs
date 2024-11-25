using ProjekatGNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGNS.Services
{
    public interface IKlijentService
    {
        void SaveUsers(string filename);
        void ReadUsers(string filename);
        List<RegistrovaniKorisnik> FindallClients(String email);
        Klijent NadjiKlijentaPrekoEmaila(string email);
    }
}
