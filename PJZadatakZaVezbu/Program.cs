
namespace PJZadatakZaVezbu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studenti = new();
            Student a = new Student("Mika", "Mikic", 6.5, 3, DateOnly.Parse("6.5.2020"), new(20, 2020), Smer.ISIT);
            Student b = new Student("Zika", "Zikic", 7, 3, DateOnly.Parse("6.5.2020"), new(21, 2020), Smer.UK);
            Student c = new Student("Luka", "Lukic", 9.3, 3, DateOnly.Parse("6.6.2021"), new(300, 2021), Smer.ISIT);
            Student d = new Student("Aca", "Mikic", 8, 2, DateOnly.Parse("6.6.2021"), new(1, 2021), Smer.ISIT);
            studenti.Add(a);
            studenti.Add(b);
            studenti.Add(c);
            studenti.Add(d);
            DataHelper helper = new(studenti);
            int izbor = 0;
            while(izbor !=7)
            {
                DataHelper.PrintMainMenu();
                if(!int.TryParse(Console.ReadLine(),out izbor))
                {
                    izbor = -1;
                }
                helper.MainMenuActions(izbor);
            }

        }
    }
}