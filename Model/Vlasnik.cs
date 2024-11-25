using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGNS.Model
{
    public class Vlasnik
    {
        private string _zaradaInterval;

        public string zaradaInterval
        {
            get { return _zaradaInterval; }
            set { _zaradaInterval = value; }
        }

        private string _zaradaDan;

        public string zaradaDan
        {
            get { return _zaradaDan; }
            set { _zaradaDan = value; }
        }

        private string _zaradaNedelja;

        public string zaradaNedelja
        {
            get { return _zaradaNedelja; }
            set { _zaradaNedelja = value; }
        }

        private string _zaradaMesec;

        public string zaradaMesec
        {
            get { return _zaradaMesec; }
            set { _zaradaMesec = value; }
        }

        private string _najboljiTrener;

        public string najboljiTrener
        {
            get { return _najboljiTrener; }
            set { _najboljiTrener = value; }
        }




    }

    
}
