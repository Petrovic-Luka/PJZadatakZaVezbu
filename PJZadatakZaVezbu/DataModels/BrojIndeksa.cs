using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJZadatakZaVezbu
{
    public struct BrojIndeksa
    {
        public int Godina { get; set; }

        public int Broj { get; set; }

        public BrojIndeksa()
        {
            Godina = 0;
            Broj = 0;
        }

        public BrojIndeksa(int broj,int godina)
        {
            Godina = godina;
            Broj= broj;
        }

        public static bool operator ==(BrojIndeksa first, BrojIndeksa second)
        {
            if (first.Broj == second.Broj && first.Godina == second.Godina) return true;
            else return false;
        }
        public static bool operator !=(BrojIndeksa first, BrojIndeksa second)
        {
            if (first.Broj == second.Broj && first.Godina == second.Godina) return false;
            else return true;
        }

        public override string ToString()
        {
            return $"{Broj}/{Godina}";
        }
    }
}
