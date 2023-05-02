using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJZadatakZaVezbu
{
    public class Student
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public double Prosek { get; set; }
        public int TrenutnaGodinaStudija { get; set; }
        public DateOnly DatumUpisa { get; set; }
        public BrojIndeksa BrojIndeksa { get; set; }
        public Smer Smer { get; set; }

        public Student() { }

        public Student(string ime, string prezime, double prosek, int trenutnaGodinaStudija, DateOnly datumUpisa, BrojIndeksa brojIndeksa, Smer smer)
        {
            Ime = ime;
            Prezime = prezime;
            Prosek = prosek;
            TrenutnaGodinaStudija = trenutnaGodinaStudija;
            DatumUpisa = datumUpisa;
            BrojIndeksa = brojIndeksa;
            Smer = smer;
        }

        public override string ToString()
        {
            return $"{BrojIndeksa} {Ime} {Prezime} Godina {TrenutnaGodinaStudija} Smer {Smer} Upisan {DatumUpisa} Prosek {Prosek.ToString("F")}";
        }

    }
}
