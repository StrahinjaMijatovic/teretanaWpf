using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGNS.Model
{
    public class Rekviziti
    {
        private string _naziv;

        public string naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        private string _namena;

        public string Namena
        {
            get { return _namena; }
            set { _namena = value; }
        }
    }
}
