using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHW
{
    public enum Genres
    {
        Action = 1,
        Adventure = 2,
        Comedy = 3,
        Historical = 4,
        Horror = 5,
        Musically = 6,
        ScienceFiction = 7,
        Western = 8
    }

    public class Cinema
    {
        public string name;
        public string about;
        public string director;
        public List<string> actors;
        public DateTime Premier;
        public List<Genres> Janres;
        public bool Archivated = false;

        public Cinema(string name, string about, DateTime primera, List<Genres> janres, string director, List<string> actors)
        {
            this.name = name;
            this.about = about;
            Premier = primera;
            Janres = janres;
            this.actors = actors;
            this.director = director;
        }

        public string GetName()
        {
            return name;
        }

        public string GetAbout()
        {
            return about;
        }

        public string GetDirector()
        {
            return director;
        }

        public DateTime GetPremier()
        {
            return Premier;
        }

        public void SetName(string name)
        {

            this.name = name;
        }

        public void SetAbout(string about)
        {
            this.about = about;
        }

        public void PrintCinemaInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Название фильма:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GetName());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Время премьеры:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{GetPremier().Day}/{GetPremier().Month}/{GetPremier().Year}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Описание фильма:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(GetAbout());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Жанры:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < Janres.Count(); i++)
            {
                Console.Write(Janres[i]);
                if (i < Janres.Count - 1)
                {
                    Console.Write(",");
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nРежисер:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(director);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Актеры:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < actors.Count(); i++)
            {
                Console.Write(actors[i]);
                if (i < actors.Count - 1)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine("\n");
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        public void ChangeCinemaInfo()
        {
            int scetcik = 6;
            List<string> CinemaAboutMenu = new List<string> { "Change Name", "Change about", "Change director", "Change actors", "Change premier time", "Change genres" };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(Console.WindowWidth / 2 - name.Length / 2, 2);
                Console.WriteLine(name);
                for (int i = 0; i < CinemaAboutMenu.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - CinemaAboutMenu[i].Length / 2, 6 + i);
                    Console.WriteLine(CinemaAboutMenu[i]);
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - CinemaAboutMenu[scetcik - 6].Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + CinemaAboutMenu[scetcik - 6].Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + CinemaAboutMenu.Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Beep();
                    Console.Clear();
                    switch (scetcik)
                    {
                        case 6:
                            #region case6
                            Console.WriteLine("Введите новое название фильма");
                            string name = Console.ReadLine();
                            this.name = name;
                            break;
                        #endregion
                        case 7:
                            #region case 7

                            Console.WriteLine("Старое описание :" + this.about);
                            Console.WriteLine("Введите новое описание фильма");
                            string about = Console.ReadLine();
                            this.about = about;
                            break;
                        #endregion
                        case 8:
                            #region case 8 
                            Console.WriteLine("Старый режжисер:" + this.director);
                            Console.WriteLine("Введите нового режиссера");
                            string director = Console.ReadLine();
                            this.director = director;
                            break;
                        #endregion
                        case 9:
                            Console.WriteLine("Введите Актера:");
                            Console.WriteLine("Нажмите Enter чтобы добавить нового  актера:");
                            Console.WriteLine("Нажмите Tab чтобы вернуться назад:");
                            string actor = "";
                            actors.Clear();
                            while (true)
                            {

                                var kyy = Console.ReadKey();

                                if (kyy.Key == ConsoleKey.Tab)
                                {
                                    Console.Clear();
                                    break;
                                }
                                
                                if (kyy.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    
                                    actors.Add(actor);
                                }

                                actor += kyy.KeyChar;
                            }

                            break;

                        case 10:
                            #region case 10

                            int year = 2018;
                            while (true)
                            {
                                Console.WriteLine("Старое время премьеры:" + this.Premier);
                                Console.WriteLine("Установите год премьеры:<>");
                                Console.WriteLine(year);
                                var kay = Console.ReadKey();
                                if (kay.Key == ConsoleKey.RightArrow && year < (int)DateTime.Today.Year)
                                {
                                    year++;
                                }
                                if (kay.Key == ConsoleKey.LeftArrow && year > 1900)
                                {
                                    year--;
                                }
                                if (kay.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();

                                    break;
                                }
                                Console.Clear();
                            }
                            int month = 1;
                            while (true)
                            {
                                Console.WriteLine("Старое время премьеры:" + this.Premier);
                                Console.WriteLine("Установите месяц премьеры:<>");
                                Console.WriteLine(month);
                                var kay = Console.ReadKey();
                                if (kay.Key == ConsoleKey.RightArrow && month < 12)
                                {
                                    month++;
                                }
                                if (kay.Key == ConsoleKey.LeftArrow && month > 1)
                                {
                                    month--;
                                }
                                if (kay.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();

                                    break;

                                }
                                Console.Clear();
                            }
                            int day = 1;
                            while (true)
                            {
                                Console.WriteLine("Старое время премьеры:" + this.Premier);
                                Console.WriteLine("Установите день премьеры:<>");
                                Console.WriteLine(day);
                                var kay = Console.ReadKey();
                                if (kay.Key == ConsoleKey.RightArrow && day < DateTime.DaysInMonth(year, month))
                                {
                                    day++;
                                }
                                if (kay.Key == ConsoleKey.LeftArrow && day > 1)
                                {
                                    day--;
                                }
                                if (kay.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();

                                    break;
                                }
                                DateTime time = new DateTime(year, month, day);
                                Premier = time;
                            }
                            Console.Clear();

                            break;
                        #endregion

                        case 11:
                            #region case11

                            int jenres = 1;
                            Genres Genre = Genres.Action;
                            List<string> GenresAboutMenu = new List<string> { "Add Genre", "Delete Genre" };
                            int sceti = 6;
                            while (true)
                            {
                                for (int i = 0; i < GenresAboutMenu.Count(); i++)
                                {
                                    Console.SetCursorPosition(Console.WindowWidth / 2 - GenresAboutMenu[i].Length / 2, 6 + i);
                                    Console.WriteLine(GenresAboutMenu[i]);
                                }
                                Console.SetCursorPosition(Console.WindowWidth / 2 - GenresAboutMenu[scetcik - 10].Length / 2 - 3, sceti);
                                Console.WriteLine(">");
                                Console.SetCursorPosition(Console.WindowWidth / 2 + GenresAboutMenu[scetcik - 10].Length / 2 + 3, sceti);
                                Console.WriteLine("<");
                                var kuy = Console.ReadKey();

                                if (kuy.Key == ConsoleKey.UpArrow && sceti > 6)
                                {
                                    Console.Beep();

                                    sceti--;
                                    Console.Clear();

                                }
                                else if (kuy.Key == ConsoleKey.DownArrow && sceti < 5 + GenresAboutMenu.Count())
                                {
                                    Console.Beep();
                                    sceti++;
                                    Console.Clear();

                                }
                                if (kuy.Key == ConsoleKey.Enter)
                                {
                                    if (sceti == 6)
                                    {


                                        while (true)
                                        {


                                            Console.WriteLine("Выберите жанры:");
                                            Console.WriteLine("Нажмите Enter чтобы добавить еще Жанр:");
                                            Console.WriteLine("Нажмите Tab чтобы перейти к следующему шагу:");


                                            if (jenres == 1)
                                            {
                                                Console.WriteLine("Action");
                                                Genre = Genres.Action;
                                            }
                                            else if (jenres == 2)
                                            {
                                                Console.WriteLine("Adventure");
                                                Genre = Genres.Adventure;
                                            }
                                            else if (jenres == 3)
                                            {
                                                Console.WriteLine("Comedy");
                                                Genre = Genres.Comedy;
                                            }
                                            else if (jenres == 4)
                                            {
                                                Console.WriteLine("Historical");
                                                Genre = Genres.Historical;
                                            }
                                            else if (jenres == 5)
                                            {
                                                Console.WriteLine("Horror");
                                                Genre = Genres.Horror;
                                            }
                                            else if (jenres == 6)
                                            {
                                                Console.WriteLine("Musically");
                                                Genre = Genres.Musically;
                                            }
                                            else if (jenres == 7)
                                            {
                                                Console.WriteLine("ScienceFiction");
                                                Genre = Genres.ScienceFiction;
                                            }
                                            else if (jenres == 8)
                                            {
                                                Console.WriteLine("Western");
                                                Genre = Genres.Western;
                                            }
                                            var kay = Console.ReadKey();

                                            if (kay.Key == ConsoleKey.RightArrow && jenres < 8)
                                            {
                                                jenres++;
                                            }
                                            if (kay.Key == ConsoleKey.LeftArrow && jenres > 1)
                                            {
                                                jenres--;
                                            }

                                            if (kay.Key == ConsoleKey.Enter)
                                            {
                                                Janres.Add(Genre);
                                                Console.Clear();
                                            }
                                            if (kay.Key == ConsoleKey.Tab)
                                            {

                                                Console.Clear();
                                                break;
                                            }
                                            Console.Clear();

                                        }
                                    }
                                    if (sceti == 7)
                                    {
                                        int scet = 6;
                                        Console.Clear();

                                        while (true)
                                        {
                                            if (Janres.Count == 0)
                                            {
                                                Console.SetCursorPosition(Console.WindowWidth / 2 - 9, scet);
                                                Console.WriteLine("Janres is empty!!!");
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                string message = "Please choose a genre to delete it";
                                                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                                                Console.WriteLine(message);
                                                for (int i = 0; i < Janres.Count(); i++)
                                                {
                                                    Console.SetCursorPosition(Console.WindowWidth / 2 - Janres[i].ToString().Length / 2, 6 + i);
                                                    Console.WriteLine(Janres[i].ToString());
                                                }
                                                Console.SetCursorPosition(Console.WindowWidth / 2 - Janres[scet - 6].ToString().Length / 2 - 3, scet);
                                                Console.WriteLine(">");
                                                Console.SetCursorPosition(Console.WindowWidth / 2 + Janres[scet - 6].ToString().Length / 2 + 3, scet);
                                                Console.WriteLine("<");
                                            }

                                            var kky = Console.ReadKey();
                                            if (kky.Key == ConsoleKey.UpArrow && scet > 6)
                                            {
                                                Console.Beep();

                                                scet--;
                                                Console.Clear();

                                            }
                                            else if (kky.Key == ConsoleKey.DownArrow && scet < 5 + Janres.Count())
                                            {
                                                Console.Beep();
                                                scet++;
                                                Console.Clear();

                                            }
                                            if (kky.Key == ConsoleKey.Enter)
                                            {
                                                Console.Clear();
                                                if(Janres.Count != 0)
                                                Janres.Remove(Janres[scet - 6]);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                            #endregion

                    }


                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {
                    Console.Beep();

                    break;
                }

            }
        }

        public void AddCinemaToArchive()
        {
            Archivated = true;
        }

        public void TakeCinemaFromArchive()
        {
            Archivated = false;
        }
    }
}

