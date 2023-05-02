using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJZadatakZaVezbu
{
    public enum Smer
    {
        ISIT, ME, OM, UK
    }

    public static class SmerExt
    { 
        public static string FullName(this Smer s)
        {
            if (s == Smer.ISIT) return "Informacioni sistemi i tehnologije";
            else if (s == Smer.ME) return "Menadzment";
            else if (s == Smer.OM) return "Operacioni menadzment";
            else return "Upravljanje kvalitetom";

        }

        public static void Table(this List<Student> studenti)
        {
            foreach(var i in studenti)
            {
                Console.WriteLine(i);
            }
        }

    }

}

