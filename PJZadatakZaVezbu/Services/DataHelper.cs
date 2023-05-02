using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJZadatakZaVezbu
{
    public class DataHelper
    {
        private List<Student> students;

        public DataHelper() { students = new(); }

        public DataHelper(List<Student> value)
        {
            if(value!=null)
            students = value;
            else students = new List<Student>();
        }
        public static void PrintMainMenu()
        {
            Console.WriteLine("Izaberite 1 za kreiranje studenta");
            Console.WriteLine("Izaberite 2 za prikaz 1 studenta");
            Console.WriteLine("Izaberite 3 za prikaz svih studenata");
            Console.WriteLine("Izaberite 4 za azuriranje studenta");
            Console.WriteLine("Izaberite 5 za brisanje studenta");
            Console.WriteLine("Izaberite 6 za dodatni meni");
            Console.WriteLine("Izaberite 7 za kraj");
        }
    
        public void MainMenuActions(int izbor)
        {
            try
            {
                switch (izbor)
                {
                    case 1: AddStudent(); break;
                    case 2: DisplayStudent(); break;
                    case 3: DisplayStudents(); break;
                    case 4: UpdateStudent(); break;
                    case 5: RemoveStudent(); break;
                    case 6: SpecialMenu();break;
                    case 7: Console.WriteLine("Kraj rada"); break;
                    default: Console.WriteLine("Greska prilikom unosa"); break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EditMenuActions(int izbor,Student student)
        {
            switch (izbor)
            {
                case 1: student.Ime=setIme(); break;
                case 2: student.Prezime = setPrezime(); break;
                case 3: student.Prosek = setProsek(); break;
                case 4: student.TrenutnaGodinaStudija = setGodinaStudija(); break;
                case 5: student.DatumUpisa=setDatumUpisa(); break;
                case 6: student.Smer = setSmer();break;
                case 7: Console.WriteLine("Kraj rada"); break;
                default: Console.WriteLine("Greska prilikom unosa"); break;
            }
        }
        private void printEditMenu()
        {
            Console.WriteLine("Izaberite 1 za izmenu imena");
            Console.WriteLine("Izaberite 2 za izmenu prezimena");
            Console.WriteLine("Izaberite 3 za izmenu proseka");
            Console.WriteLine("Izaberite 4 za izmenu trenutne godine studija");
            Console.WriteLine("Izaberite 5 za izmenu datuma upisa");
            Console.WriteLine("Izaberite 6 za izmenu smera");
            Console.WriteLine("Izaberite 7 za kraj");
        }

        private void printSpecialMenu()
        {
            Console.WriteLine("Izaberite 1 poslednji indeks u godini");
            Console.WriteLine("Izaberite 2 za poredjenje popularnosti u godinama");
            Console.WriteLine("Izaberite 3 za ponovni upis");
            Console.WriteLine("Izaberite 4 za prosek po godini studija");
            Console.WriteLine("Izaberite 5 za prosek smeru");
            Console.WriteLine("Izaberite 6 za prikaz svih studenata upisanih odredjene godine");
            Console.WriteLine("Izaberite 7 za smer sa najvecim brojem studenata");
        }


        private void SpecialMenu()
        {
            int izbor = -1;
            printSpecialMenu();
            if (!int.TryParse(Console.ReadLine(), out izbor))
            {
                izbor = -1;
            }
            SpecialMenuActions(izbor);
        }

        private void SpecialMenuActions(int izbor)
        {
            try
            {
                switch (izbor)
                {
                    case 1: LastIndexOfGivenYear(); break;
                    case 2: CompareYearsByNumberOfStudents(); break;
                    case 3: UpdateIndexToCurrentYear(); break;
                    case 4: AverageByYears(); break;
                    case 5: AverageByMajor(); break;
                    case 6: StudentsByYear();break;
                    case 7: BiggestMajor(); break;
                    default: Console.WriteLine("Greska prilikom unosa"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int LastIndexOfGivenYear()
        {
            Console.WriteLine("Unesite godinu indeksa");
            if (!int.TryParse(Console.ReadLine(), out int tempGodinaIndeksa) || (tempGodinaIndeksa < 0 || tempGodinaIndeksa > DateTime.Now.Year))
            {
                throw new FormatException("Nepravilan izbor godine");
            }

            var test = students.Where(x => x.BrojIndeksa.Godina == tempGodinaIndeksa).ToList();
            test.Sort(delegate (Student x, Student y)
            {
                if (x.BrojIndeksa.Broj > y.BrojIndeksa.Broj) return 1;
                else return 0;
            });
            if (test.Count() == 0)
            { 
                Console.WriteLine("Nema studenata iz zadate godine");
                return 0;
            }
            else
            {
                Console.WriteLine(test.Last());
                return test.Last().BrojIndeksa.Broj;
            }
        }

        private int LastIndexOfGivenYear(int tempGodinaIndeksa)
        {
            if ((tempGodinaIndeksa < 0 || tempGodinaIndeksa > DateTime.Now.Year))
            {
                throw new FormatException("Nepravilan izbor godine");
            }

            var test = students.Where(x => x.BrojIndeksa.Godina == tempGodinaIndeksa).ToList();
            test.Sort(delegate (Student x, Student y)
            {
                if (x.BrojIndeksa.Broj > y.BrojIndeksa.Broj) return 1;
                else return 0;
            });
            if (test.Count() == 0)
            {
                return 0;
            }
            else
            {
                return test.Last().BrojIndeksa.Broj;
            }
        }

        private void AverageByYears()
        {
            var years = students.GroupBy(x => x.TrenutnaGodinaStudija).Select(x=>x.First()).ToList();
            foreach(var i in years)
            {
                Console.WriteLine($"{i.TrenutnaGodinaStudija} {students.Where(x => x.TrenutnaGodinaStudija == i.TrenutnaGodinaStudija).Average(x => x.Prosek)}");
            }
        }

        private void AverageByMajor()
        {
            try
            {
                var a = students.Where(x => x.Smer == Smer.ISIT).Average(x => x.Prosek);
                Console.WriteLine($"ISIT {a.ToString("F")}");
            }
            catch
            {
                Console.WriteLine("Smer ISIT nema upisanih clanova");
            }
            try
            {
                var a = students.Where(x => x.Smer == Smer.ME).Average(x => x.Prosek);
                Console.WriteLine($"ME {a.ToString("F")}");
            }
            catch
            {
                Console.WriteLine("Smer ME nema upisanih clanova");
            }
            try
            {
                var a = students.Where(x => x.Smer == Smer.UK).Average(x => x.Prosek);
                Console.WriteLine($"UK {a}");
            }
            catch
            {
                Console.WriteLine("Smer UK nema upisanih clanova");
            }
            try
            {
                var a = students.Where(x => x.Smer == Smer.OM).Average(x => x.Prosek);
                Console.WriteLine($"OM {a.ToString("F")}");
            }
            catch
            {
                Console.WriteLine("Smer OM nema upisanih clanova");
            }
        }

        private void StudentsByYear()
        {
            Console.WriteLine("Unesite godinu upisa");
            if (!int.TryParse(Console.ReadLine(), out int year) || (year < 0 || year > DateTime.Now.Year))
            {
                throw new FormatException("Nepravilan izbor godine");
            }
            foreach(var i in students.Where(x=>x.DatumUpisa.Year==year))
            {
                Console.WriteLine(i);
            }

        }
        private void CompareYearsByNumberOfStudents()
        {
            Console.WriteLine("Unesite prvu godinu");
            if (!int.TryParse(Console.ReadLine(), out int firstYear) || (firstYear < 0 || firstYear > DateTime.Now.Year))
            {
                throw new FormatException("Nepravilan izbor godine");
            }
            Console.WriteLine("Unesite drugu godinu");
            if (!int.TryParse(Console.ReadLine(), out int secondYear) || (secondYear < 0 || secondYear > DateTime.Now.Year))
            {
                throw new FormatException("Nepravilan izbor godine");
            }
            if(firstYear==secondYear)
            {
                Console.WriteLine($"Ista godina br studenata {students.Count(x => x.DatumUpisa.Year == firstYear)}");
                return;
            }
            int nFirst = students.Count(x => x.DatumUpisa.Year == firstYear);
            int nSecond = students.Count(x => x.DatumUpisa.Year == secondYear);
            int diff = 0;
            Console.WriteLine($"{firstYear} {nFirst}");
            Console.WriteLine($"{secondYear} {nSecond}");
            string result = "";
            if(firstYear>secondYear)
            {
                diff = nFirst - nSecond;
            }
            else 
            {
                diff = nSecond - nFirst;
            }
            if (diff > 0) result = "se povecala za " + diff;
            else if (diff == 0) result = "je ostala ista";
            else result = "se smanjila za " + (diff * -1);
            Console.WriteLine($"Popularnost {result}");
        }

        private void BiggestMajor()
        {
            int a = students.Count(x => x.Smer == Smer.ISIT);
            int b = students.Count(x => x.Smer == Smer.ME);
            int c = students.Count(x => x.Smer == Smer.OM);
            int d = students.Count(x => x.Smer == Smer.UK);
            int n = Math.Max(Math.Max(a, b), Math.Max(c, d));
            string res = "";
            if (a == n) res = "ISIT";
            else if (b == n) res = "ME";
            else if (c == n) res = "OM";
            else if (d == n) res = "UK";
            Console.WriteLine($"{res} {n}");
        }

        private void UpdateIndexToCurrentYear()
        {
            BrojIndeksa temp = SetBrojIndeksa();
            if(!HasIndex(temp))
            {
                Console.WriteLine("Uneti indeks ne postoji");
                return;
            }
            else
            {
                BrojIndeksa ind = new();
                ind.Godina = DateTime.Now.Year;
                ind.Broj = LastIndexOfGivenYear(DateTime.Now.Year) + 1;
                students.First(x=>x.BrojIndeksa==temp).BrojIndeksa=ind;               
            }
        }

        private void AddStudent()
        {
            Student temp = new();
            try
            {

                temp.Ime = setIme();
                temp.Prezime = setPrezime();
                temp.Prosek = setProsek();
                temp.TrenutnaGodinaStudija = setGodinaStudija();
                temp.DatumUpisa = setDatumUpisa();
                temp.Smer = setSmer();
                BrojIndeksa tempIndeks = SetBrojIndeksa();
                if (HasIndex(tempIndeks))
                {
                    throw new FormatException("Student sa datim indeksom vec postoji");
                }
                temp.BrojIndeksa = tempIndeks;
                students.Add(temp);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Neuspesan unos");
                return;
            }
        }
        private BrojIndeksa SetBrojIndeksa()
        {

            BrojIndeksa tempIndeks = new();
            Console.WriteLine("Unesite broj indeksa");
            if (!int.TryParse(Console.ReadLine(), out int tempBrojIndeksa) || tempBrojIndeksa < 0)
            {
                throw new FormatException("Nepravilan izbor broja");
            }

            tempIndeks.Broj = tempBrojIndeksa;

            Console.WriteLine("Unesite godinu indeksa");
            if (!int.TryParse(Console.ReadLine(), out int tempGodinaIndeksa) || (tempGodinaIndeksa < 0 || tempGodinaIndeksa > DateTime.Now.Year))
            {
                throw new FormatException("Nepravilan izbor godine");
            }

            tempIndeks.Godina = tempGodinaIndeksa;

            return tempIndeks;
        }
        private string setIme()
        {
            Console.WriteLine("Unesite ime studenta");
            var ime = Console.ReadLine();
            if (ime == null || ime.Length < 1)
            {
                throw new FormatException("Ime mora biti uneto");
            }
            return ime;
        }
        private string setPrezime()
        {

            Console.WriteLine("Unesite prezime studenta");
            var prezime = Console.ReadLine();
            if (prezime == null || prezime.Length < 1)
            {
                throw new FormatException("Prezime mora biti uneto");
            }
            return prezime;
        }
        private double setProsek()
        {
            Console.WriteLine("Unesite prosek studenta");
            double prosekTemp = 0;
            if (!double.TryParse(Console.ReadLine(), out prosekTemp) || (prosekTemp < 5 || prosekTemp > 10))
            {
                throw new FormatException("Nepravilan unos proseka");
            }
            return prosekTemp;
        }

        private int setGodinaStudija()
        {
            Console.WriteLine("Unesite trenutnu godinu studija");
            int godinaTemp = 0;
            if (!int.TryParse(Console.ReadLine(), out godinaTemp))
            {
                throw new FormatException("Nepravilan unos godine");
            }
                return godinaTemp;
        }

        private DateOnly setDatumUpisa()
        {
            Console.WriteLine("Unesite datum upisa");
            DateOnly tempDatum;
            if (!DateOnly.TryParse(Console.ReadLine(), out tempDatum))
            {
                throw new FormatException("Nepravilan unos datuma");
            }
                return tempDatum;
        }
        
        private Smer setSmer()
        {
            Console.WriteLine("Odaberite Smer");
            Console.WriteLine("0 : ISIT, 1 : ME, 2 : OM, 3 : UK");
            int tempSmer;
            if (!int.TryParse(Console.ReadLine(), out tempSmer) || (tempSmer < 0 || tempSmer > 3))
            {
                throw new FormatException("Nepravilan izbor smera");
            }
                return (Smer)tempSmer;
        }

        private bool HasIndex(BrojIndeksa tempIndeks)
        {
            return students.Where(x => x.BrojIndeksa == tempIndeks).Count() > 0;
        }

        private void UpdateStudent()
        {
            BrojIndeksa tempIndeks = SetBrojIndeksa();
            if (!HasIndex(tempIndeks))
            {
                Console.WriteLine("Dati indeks ne postoji u sistemu");
                return;
            }
            else
            {
                Student student = students.First(x => x.BrojIndeksa == tempIndeks);
                int izbor = -1;
                while (izbor != 7)
                {
                    printEditMenu();
                    if (!int.TryParse(Console.ReadLine(), out izbor))
                    {
                        izbor = -1;
                    }
                    EditMenuActions(izbor, student);

                }
            }
        }
             
        private void RemoveStudent()
        {
            BrojIndeksa tempIndeks = SetBrojIndeksa();
            if (!HasIndex(tempIndeks))
            {
                Console.WriteLine("Uneti indeks ne postoji u sistemu");
            }
            else
            {
                students.Remove(students.First(x => x.BrojIndeksa == tempIndeks));
                Console.WriteLine("Student uspesno obrisan");
            }
        }

        private void DisplayStudent()
        {
            BrojIndeksa tempIndeks = SetBrojIndeksa();
            if (students.Where(x => x.BrojIndeksa == tempIndeks).Count() == 0)
            {
                Console.WriteLine("Uneti indeks ne postoji u sistemu");
            }
            else
            {
                Console.WriteLine(students.First(x => x.BrojIndeksa == tempIndeks));
            }
        }

        private void DisplayStudents()
        {
            foreach(var i in students)
            {
                Console.WriteLine(i);
            }
        }


    }
}
