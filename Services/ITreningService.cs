using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGNS.Services
{
    public interface ITreningService
    {
        void SaveTrening(string filename);
        void ReadTrening(string filename);
        void DeleteTrening(int sifra);
    }
}
