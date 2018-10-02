using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CsharpHW
{

    public class Building
    {
        private string Name;
        public List<Room> Rooms;
        public List<Cinema> Cinemas;
        public List<Session> Sessions;

        public Building() { }

        public Building(string name)
        {
            Rooms = new List<Room>();
            Cinemas = new List<Cinema>();
            Sessions = new List<Session>();
            Name = name;


        }

        public void AddRoom(Room room)
        {

            Rooms.Add(room);
        }

        public void AddCinema(Cinema cinema)
        {

            Cinemas.Add(cinema);
        }

        public void AddSession(Session session)
        {

            Sessions.Add(session);
        }

        public List<Cinema> GetAvailableCinemas()
        {
            List<Cinema> cinemas = new List<Cinema>();
            for (int i = 0; i < Cinemas.Count(); i++)
            {
                if (Cinemas[i].Archivated == false)
                {
                    cinemas.Add(Cinemas[i]);
                }
            }
            return cinemas;
        }

        public List<Cinema> GetArchivatedCinemas()
        {
            List<Cinema> cinemas = new List<Cinema>();
            for (int i = 0; i < Cinemas.Count(); i++)
            {
                if (Cinemas[i].Archivated == true)
                {
                    cinemas.Add(Cinemas[i]);
                }
            }
            return cinemas;
        }

        public void CustomerCinemasInfoMenu()
        {
            int scetcik = 6;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Please choose a movie to see information about it";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < GetAvailableCinemas().Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - GetAvailableCinemas()[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(GetAvailableCinemas()[i].GetName());

                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - GetAvailableCinemas()[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + GetAvailableCinemas()[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + GetAvailableCinemas().Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Beep();

                    Console.Clear();
                    GetAvailableCinemas()[scetcik - 6].PrintCinemaInfo();
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {

                    Console.Beep();
                    Console.Clear();
                    break;
                }
            }
        }

        public void RoomsInfoMenu()
        {
            int scetcik = 6;
            while (true)
            {
                string message = "Please choose a room to see its status and information about it.";

                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < Rooms.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Rooms[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(Rooms[i].GetName());
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - Rooms[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + Rooms[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    scetcik--;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + Rooms.Count())
                {
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Rooms[scetcik - 6].PrintRoomInfo();
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        public void CreateTheRoom()
        {
            Console.WriteLine("Введите название комнаты:");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите количество рядов:");
            int Row;
            Int32.TryParse(Console.ReadLine(), out Row);
            Console.Clear();
            Console.WriteLine("Введите количество мест в ряду:");
            int place;
            Int32.TryParse(Console.ReadLine(), out place);
            Console.Clear();
            int format = 1;
            Formats formatt = Formats.Format_2D;

            while (true)
            {

                Console.WriteLine("Выберите формат комнаты:(Для выбора используйте стрелки -> <-)");
                Console.WriteLine("Нажмите Enter после выбора");
                if (format == 1)
                {
                    Console.WriteLine("2D");
                    formatt = Formats.Format_2D;
                }
                else if (format == 2)
                {
                    Console.WriteLine("3D");
                    formatt = Formats.Format_3D;
                }
                else if (format == 3)
                {
                    formatt = Formats.Imax;
                    Console.WriteLine("IMAX");
                }
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow && format < 3)
                {
                    format++;
                }
                if (key.Key == ConsoleKey.LeftArrow && format > 1)
                {
                    format--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
            }

            bool Vip = false;
            int vip = 1;

            while (true)
            {
                Console.WriteLine("Выберите уровень комфорта:(Для выбора используйте стрелки -> <-)");
                Console.WriteLine("Нажмите Enter после выбора");
                if (vip == 1)
                {
                    Console.WriteLine("Обыйная комната");
                    Vip = false;

                }
                else if (vip == 2)
                {
                    Console.WriteLine("Vip Комната");
                    Vip = true;

                }

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && vip < 2)
                {
                    vip++;
                }
                if (key.Key == ConsoleKey.LeftArrow && vip > 1)
                {
                    vip--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
            }
            Room room = new Room(name, formatt, Vip, Row, place);
            Rooms.Add(room);

        }

        public void CreateCinema()
        {
            Console.WriteLine("Введите название Фильма:");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите описание фильма:");
            string about = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите имя режиссера");
            string Rejisser = Console.ReadLine();
            Console.Clear();
            List<string> actors = new List<string>();

            Console.WriteLine("Введите Актера:");
            Console.WriteLine("Нажмите Enter чтобы добавить еще актера:");
            Console.WriteLine("Нажмите Tab чтобы перейти к следующему шагу:");
            string actor = "";
            while (true)
            {

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Tab)
                {
                    Console.Clear();
                    break;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    actors.Add(actor);
                }

                actor += key.KeyChar;
            }

            int jenres = 1;
            List<Genres> genres = new List<Genres>();
            Genres Genre = Genres.Action;

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
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow && jenres < 8)
                {
                    jenres++;
                }
                if (key.Key == ConsoleKey.LeftArrow && jenres > 1)
                {
                    jenres--;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    genres.Add(Genre);
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Tab)
                {

                    Console.Clear();
                    break;
                }
                Console.Clear();

            }
            int year = 2018;
            while (true)
            {
                Console.WriteLine("Установите год премьеры:<>");
                Console.WriteLine(year);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && year < (int)DateTime.Today.Year)
                {
                    year++;
                }
                if (key.Key == ConsoleKey.LeftArrow && year > 1900)
                {
                    year--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    break;
                }
                Console.Clear();
            }
            int month = 1;
            while (true)
            {
                Console.WriteLine("Установите месяц премьеры:<>");
                Console.WriteLine(month);
                var key = Console.ReadKey();
                if (year < DateTime.Now.Year)
                {

                    if (key.Key == ConsoleKey.RightArrow && month < 12)
                    {
                        month++;
                    }
                    if (key.Key == ConsoleKey.LeftArrow && month > 1)
                    {
                        month--;
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.RightArrow && month < DateTime.Now.Month)
                    {
                        month++;
                    }
                    if (key.Key == ConsoleKey.LeftArrow && month > 1)
                    {
                        month--;
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    break;
                }
                Console.Clear();
            }
            int day = 1;
            while (true)
            {
                Console.WriteLine("Установите день премьеры:<>");
                Console.WriteLine(day);
                var key = Console.ReadKey();
                if (year != DateTime.Now.Year && month != DateTime.Now.Month)
                {
                    if (key.Key == ConsoleKey.RightArrow && day < DateTime.DaysInMonth(year, month))
                    {
                        day++;
                    }
                    if (key.Key == ConsoleKey.LeftArrow && day > 1)
                    {
                        day--;
                    }
                }
                else
                {
                    if (key.Key == ConsoleKey.RightArrow && day < DateTime.Now.Day)
                    {
                        day++;
                    }
                    if (key.Key == ConsoleKey.LeftArrow && day > 1)
                    {
                        day--;
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                Console.Clear();
            }
            DateTime time = new DateTime(year, month, day);
            Console.Clear();
            Cinema cinema = new Cinema(name, about, time, genres, Rejisser, actors);

            Console.WriteLine("Хотите добавить этот фильм в базу?(Нажмите Enter если Да,или TAB если НЕТ)");
            var ker = Console.ReadKey();
            if (ker.Key == ConsoleKey.Enter)
            {
                Cinemas.Add(cinema);
                Console.Clear();
            }
            else if (ker.Key == ConsoleKey.Tab)
            {
                Console.Clear();
            }
        }

        public void RoomsDelete()
        {
            int scetcik = 6;
            while (true)
            {
                string message = "Please choose a room to delete it.";

                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < Rooms.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Rooms[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(Rooms[i].GetName());
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - Rooms[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + Rooms[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    scetcik--;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + Rooms.Count())
                {
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Rooms.Remove(Rooms[scetcik - 6]);
                    break;
                }
            }
        }

        public void CinemasDelete()
        {
            int scetcik = 6;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Please choose a movie to delete it";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < Cinemas.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Cinemas[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(Cinemas[i].GetName());
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - Cinemas[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + Cinemas[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + Cinemas.Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Cinemas.Remove(Cinemas[scetcik - 6]);
                    break;
                }
            }
        }

        public Room ChooseRoomsByFormat(Formats format)
        {
            int scetcik = 6;
            while (true)
            {
                string message = "Please choose a room";
                List<Room> RoomsByFormat = new List<Room>();
                for (int i = 0; i < Rooms.Count(); i++)
                {
                    if (Rooms[i].GetFormat() == format)
                    {
                        RoomsByFormat.Add(Rooms[i]);
                    }
                }

                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < RoomsByFormat.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - RoomsByFormat[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(RoomsByFormat[i].GetName());
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - RoomsByFormat[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + RoomsByFormat[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    scetcik--;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + RoomsByFormat.Count())
                {
                    scetcik++;
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    return RoomsByFormat[scetcik - 6];

                }

            }
        }

        public Formats ChooseFormats()
        {
            Formats formatt = Formats.Format_2D;
            int format = 1;
            while (true)
            {

                Console.WriteLine("Выберите формат комнаты:(Для выбора используйте стрелки -> <-)");
                Console.WriteLine("Нажмите Enter после выбора");
                if (format == 1)
                {
                    Console.WriteLine("2D");
                    formatt = Formats.Format_2D;
                }
                else if (format == 2)
                {
                    Console.WriteLine("3D");
                    formatt = Formats.Format_3D;
                }
                else if (format == 3)
                {
                    formatt = Formats.Imax;
                    Console.WriteLine("IMAX");
                }
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow && format < 3)
                {
                    format++;
                }
                if (key.Key == ConsoleKey.LeftArrow && format > 1)
                {
                    format--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    return formatt;
                }
                Console.Clear();
            }

        }

        public DateTime ChooseSessionDateTime()
        {

            int year = (int)DateTime.Today.Year;
            while (true)
            {
                Console.WriteLine("Установите год :<>");
                Console.WriteLine(year);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && year < (int)DateTime.Today.Year + 5)
                {
                    year++;
                }
                if (key.Key == ConsoleKey.LeftArrow && year > (int)DateTime.Today.Year)
                {
                    year--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    break;
                }
                Console.Clear();
            }


            int month = 1;
            int minmomnth = month;
            if (year == DateTime.Today.Year)
            {
                minmomnth = DateTime.Today.Month;
                month = DateTime.Today.Month;
            }
            while (true)
            {

                Console.WriteLine("Установите месяц :<>");
                Console.WriteLine(month);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && month < 12)
                {
                    month++;
                }
                if (key.Key == ConsoleKey.LeftArrow && month > minmomnth)
                {
                    month--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    break;
                }
                Console.Clear();
            }
            int day = 1;
            int minday = day;
            if (year == DateTime.Today.Year && month == DateTime.Today.Month)
            {
                minday = DateTime.Today.Day;
                day = DateTime.Today.Day;
            }
            while (true)
            {
                Console.WriteLine("Установите день :<>");
                Console.WriteLine(day);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    break;
                }
                if (key.Key == ConsoleKey.RightArrow && day < DateTime.DaysInMonth(year, month))
                {
                    day++;
                }
                if (key.Key == ConsoleKey.LeftArrow && day > minday)
                {
                    day--;
                }

                Console.Clear();
            }

            int hour = 1;
            int minhour = hour;
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && day == DateTime.Today.Day)
            {
                minhour = DateTime.Now.Hour;
                hour = DateTime.Now.Hour;
            }
            while (true)
            {
                Console.WriteLine("Установите час:<>");
                Console.WriteLine(hour);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && hour < 23)
                {
                    hour++;
                }
                if (key.Key == ConsoleKey.LeftArrow && hour > minhour)
                {
                    hour--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    break;
                }
                Console.Clear();
            }
            int minute = 1;
            int minminute = minute;
            if (year == DateTime.Today.Year && month == DateTime.Today.Month && day == DateTime.Today.Day && hour == DateTime.Today.Hour)
            {
                minminute = DateTime.Now.Minute;
                minute = DateTime.Now.Minute;
            }
            while (true)
            {
                Console.WriteLine("Установите минуты :<>");
                Console.WriteLine(minute);
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    break;
                }
                if (key.Key == ConsoleKey.RightArrow && minute < 59)
                {
                    minute++;
                }
                if (key.Key == ConsoleKey.LeftArrow && minute > 0)
                {

                    minute--;
                }

                Console.Clear();
            }
            DateTime time = new DateTime(year, month, day, hour, minute, 0);
            return time;
        }

        public void CreateSession()
        {
            int scetcik = 6;
            Room room;
            Formats format;
            DateTime time;
            Cinema cinema;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Сhoose a movie to create a session";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < GetAvailableCinemas().Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - GetAvailableCinemas()[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(GetAvailableCinemas()[i].GetName());
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - GetAvailableCinemas()[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + GetAvailableCinemas()[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();
                    scetcik--;
                    Console.Clear();
                }

                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + GetAvailableCinemas().Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    cinema = GetAvailableCinemas()[scetcik - 6];
                    Console.Beep();
                    Console.Clear();
                    format = ChooseFormats();
                    room = ChooseRoomsByFormat(format);
                    time = ChooseSessionDateTime();
                    Sessions.Add(new Session(cinema, time, room));
                    break;
                }


            }

        }

        public void DeleteSession()
        {
            int ses = 0;
            while (true)
            {
                Console.WriteLine("Выберите сессию :<>");
                Sessions[ses].PrintSessionInfo();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && ses < Sessions.Count - 1)
                {
                    ses++;
                }
                if (key.Key == ConsoleKey.LeftArrow && ses > 0)
                {
                    ses--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Sessions.RemoveAt(ses);
                    break;
                }
                Console.Clear();
            }
        }

        public void SessionUpdate()
        {
            for (int i = 0; i < Sessions.Count(); i++)
            {
                if (DateTime.Now > Sessions[i].GetDate())
                {
                    for (int j = 0; j < Rooms.Count(); j++)
                    {
                        if (Rooms[j].GetName() == Sessions[i].GetRoom().GetName())
                        {
                            for (int y = 0; y < Rooms[j].places.GetLength(0); y++)
                            {
                                for (int z = 0; z < Rooms[j].places.GetLength(1); z++)
                                {
                                    Rooms[j].SetPlace(Sessions[i].GetRoom().GetPlaces());
                                }
                            }
                        }
                    }

                    Sessions.RemoveAt(i);
                }
            }
        }

        public void SortSessions()
        {
            Session temp;
            for (int i = 0; i < Sessions.Count() - 1; ++i)
            {
                for (int j = 0; j < Sessions.Count() - 1; ++j)
                {
                    if (Sessions[j].GetDate() > Sessions[j + 1].GetDate())
                    {
                        temp = Sessions[j];
                        Sessions[j] = Sessions[j + 1];
                        Sessions[j + 1] = temp;
                    }
                }
            }

        }

        public void PrintSortedSessionsList()
        {
            SortSessions();

            for (int i = 0; i < Sessions.Count(); i++)
            {
                Sessions[i].PrintSessionInfo();
                Console.Write("\n");
            }
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        public void EmployeCinemasInfoMenu()
        {
            int scetcik = 6;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Please choose a movie to see information about it";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < Cinemas.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Cinemas[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(Cinemas[i].GetName());

                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - Cinemas[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + Cinemas[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + Cinemas.Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Beep();

                    Console.Clear();
                    Cinemas[scetcik - 6].PrintCinemaInfo();
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {

                    Console.Beep();
                    Console.Clear();
                    break;
                }
            }
        }

        public void ChangeCinemaInfoMenu()
        {
            int scetcik = 6;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Please choose a movie to change information about it";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < Cinemas.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Cinemas[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(Cinemas[i].GetName());

                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - Cinemas[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + Cinemas[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + Cinemas.Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Beep();

                    Console.Clear();
                    Cinemas[scetcik - 6].ChangeCinemaInfo();
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {

                    Console.Beep();
                    Console.Clear();
                    break;
                }
            }
        }

        public void ChangeRoomInfoMenu()
        {
            int scetcik = 6;
            while (true)
            {
                string message = "Please choose a room to change its status and information about it.";

                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < Rooms.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Rooms[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(Rooms[i].GetName());
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - Rooms[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + Rooms[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    scetcik--;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + Rooms.Count())
                {
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Rooms[scetcik - 6].СhangeRoomInfo();
                    
                    Console.Clear();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        public void AddCinemaToArchiveMenu()
        {
            int scetcik = 6;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Please choose a movie to Add";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < GetAvailableCinemas().Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - GetAvailableCinemas()[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(GetAvailableCinemas()[i].GetName());

                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - GetAvailableCinemas()[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + GetAvailableCinemas()[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + GetAvailableCinemas().Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Beep();

                    Console.Clear();
                    GetAvailableCinemas()[scetcik - 6].AddCinemaToArchive();
                    scetcik--;
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {

                    Console.Beep();
                    Console.Clear();
                    break;
                }
            }

        }

        public void TakeCinemaFromArchiveMenu()
        {
            int scetcik = 6;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Please choose a movie to see information about it";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < GetArchivatedCinemas().Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - GetArchivatedCinemas()[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(GetArchivatedCinemas()[i].GetName());

                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - GetArchivatedCinemas()[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + GetArchivatedCinemas()[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + GetArchivatedCinemas().Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Beep();

                    Console.Clear();
                    GetArchivatedCinemas()[scetcik - 6].TakeCinemaFromArchive();
                    Console.Clear();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {

                    Console.Beep();
                    Console.Clear();
                    break;
                }
            }

        }

        public void ChangeSessionInfoMenu(Session session)
        {
            string name = "Choose what you want to change";
            int scetcik = 6;
            List<string> SessionAboutMenu = new List<string> { "Change Cinema", "Change Room", "Change Time" };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(Console.WindowWidth / 2 - name.Length / 2, 2);
                Console.WriteLine(name);
                for (int i = 0; i < SessionAboutMenu.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - SessionAboutMenu[i].Length / 2, 6 + i);
                    Console.WriteLine(SessionAboutMenu[i]);
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - SessionAboutMenu[scetcik - 6].Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + SessionAboutMenu[scetcik - 6].Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + SessionAboutMenu.Count())
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
                            Cinema cin = ChooseCinema();
                            session.SetCinema(cin);
                            break;
                        case 7:
                            Room room = ChooseRoom();
                            session.SetRoom(room);
                            break;
                        case 8:
                            DateTime time = ChooseSessionDateTime();
                            session.SetTime(time);
                            break;
                    }
                    Console.Clear();
                }
            }

        }

        public Session ChooseSession()
        {
            int ses = 0;
            while (true)
            {
                Console.WriteLine("Выберите сессию :<>");
                Sessions[ses].PrintSessionInfo();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && ses < Sessions.Count - 1)
                {
                    ses++;
                }
                if (key.Key == ConsoleKey.LeftArrow && ses > 0)
                {
                    ses--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    return Sessions[ses];
                }
                Console.Clear();
            }
        }

        public Cinema ChooseCinema()
        {
            int scetcik = 6;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Please choose a movie to change information about it";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < Cinemas.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Cinemas[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(Cinemas[i].GetName());

                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - Cinemas[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + Cinemas[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var kkkk = Console.ReadKey();
                if (kkkk.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (kkkk.Key == ConsoleKey.DownArrow && scetcik < 5 + Cinemas.Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (kkkk.Key == ConsoleKey.Enter)
                {
                    Console.Beep();

                    Console.Clear();
                    return Cinemas[scetcik - 6];
                }
                if (kkkk.Key == ConsoleKey.Backspace || kkkk.Key == ConsoleKey.Escape)
                {

                    Console.Beep();
                    Console.Clear();
                    break;
                }


            }
            return Cinemas[scetcik - 6];
        }

        public Room ChooseRoom()
        {
            int scetcik = 6;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Please choose a movie to change information about it";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < Rooms.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - Rooms[i].GetName().Length / 2, 6 + i);
                    Console.WriteLine(Rooms[i].GetName());

                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - Rooms[scetcik - 6].GetName().Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + Rooms[scetcik - 6].GetName().Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var kkkk = Console.ReadKey();
                if (kkkk.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (kkkk.Key == ConsoleKey.DownArrow && scetcik < 5 + Cinemas.Count())
                {
                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (kkkk.Key == ConsoleKey.Enter)
                {
                    Console.Beep();

                    Console.Clear();
                    return Rooms[scetcik - 6];
                }
                if (kkkk.Key == ConsoleKey.Backspace || kkkk.Key == ConsoleKey.Escape)
                {

                    Console.Beep();
                    Console.Clear();
                    break;
                }


            }
            return Rooms[scetcik - 6];
        }

        public void SaleTicket()
        {

            Session session;
            Place place;
            int ses = 0;
            while (true)
            {
                Console.WriteLine("Выберите сессию :<>");
                Sessions[ses].PrintSessionInfo();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && ses < Sessions.Count - 1)
                {
                    ses++;
                }
                if (key.Key == ConsoleKey.LeftArrow && ses > 0)
                {
                    ses--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    session = Sessions[ses];
                    Console.Clear();
                    place = Sessions[ses].GetRoom().ChoosePlace();
                    break;
                }

                Console.Clear();
            }
            Console.WriteLine("Билет");
            Ticket ticket = new Ticket(session);
            ticket.printTicket(place);
            while (true)
            {
                var keyyy = Console.ReadKey();

                if (keyyy.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    break;
                }
            }

        }

        public void ChangeSessionInfoMenu()
        {

            int ses = 0;
            while (true)
            {
                Console.WriteLine("Выберите сессию :<>");
                Sessions[ses].PrintSessionInfo();
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.RightArrow && ses < Sessions.Count - 1)
                {
                    ses++;
                }
                if (key.Key == ConsoleKey.LeftArrow && ses > 0)
                {
                    ses--;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    ChangeSessionInfoMenu(Sessions[ses]);
                    break;
                }
                Console.Clear();
            }

        }

        public void EmployeMenu()
        {
            bool exit = false;
            int scetcik = 6;
            List<string> CustomerMenu = new List<string> { "Добавить фильм", "Добавить комнату", "Добавить сеанс", "Удалить фильм", "Удалить комнату", "Удалить сеанс", "Редактировать фильм", "Редактировать комнату", "Редактировать сеанс", "Добавить фильм в Архив", "Извлечь фильм из архива", "Продать билет", "Информация о фильме ", "Информация о комнате ", "Информация о сеансе " };
            while (true)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - DateTime.Now.ToString().Length / 2, 1);
                Console.WriteLine(DateTime.Now.ToString());
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "CustomerMenu";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);

                for (int i = 0; i < CustomerMenu.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[i].Length / 2, 6 + i);
                    Console.WriteLine(CustomerMenu[i]);
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[scetcik - 6].Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + CustomerMenu[scetcik - 6].Length / 2 + 3, scetcik);
                Console.WriteLine("<");
                while (Console.KeyAvailable)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - DateTime.Now.ToString().Length / 2, 1);
                    Console.WriteLine(DateTime.Now.ToString());
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                    Console.WriteLine(message);

                    for (int i = 0; i < CustomerMenu.Count(); i++)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[i].Length / 2, 6 + i);
                        Console.WriteLine(CustomerMenu[i]);
                    }

                    Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[scetcik - 6].Length / 2 - 3, scetcik);
                    Console.WriteLine(">");
                    Console.SetCursorPosition(Console.WindowWidth / 2 + CustomerMenu[scetcik - 6].Length / 2 + 3, scetcik);
                    Console.WriteLine("<");
                    for (int i = 0; i < CustomerMenu.Count(); i++)
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[i].Length / 2, 6 + i);
                        Console.WriteLine(CustomerMenu[i]);
                    }
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                    {
                        Console.Beep();
                        scetcik--;
                        Console.Clear();
                    }
                    else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + CustomerMenu.Count())
                    {
                        Console.Beep();
                        scetcik++;
                        Console.Clear();
                    }

                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        SessionUpdate();

                        switch (scetcik)
                        {
                            case 6:
                                CreateCinema();
                                Console.Clear();
                                break;
                            case 7:
                                CreateTheRoom();
                                Console.Clear();
                                break;
                            case 8:
                                CreateSession();
                                Console.Clear();
                                break;
                            case 9:
                                if (Cinemas.Count == 0)
                                {

                                    while (true)
                                    {
                                        Console.WriteLine("Нет фильмов для удаления!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();

                                }
                                else
                                {
                                    CinemasDelete();
                                    Console.Clear();
                                }

                                break;
                            case 10:
                                if (Rooms.Count == 0)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Нет комнат для удаления!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();

                                }
                                else
                                {
                                    RoomsDelete();
                                    Console.Clear();
                                }
                                break;
                            case 11:

                                if (Sessions.Count == 0)
                                {

                                    while (true)
                                    {
                                        Console.WriteLine("Нет сеансов для удаления!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();
                                }
                                else
                                {
                                    DeleteSession();
                                    Console.Clear();
                                }
                                break;
                            case 12:
                                if (Cinemas.Count == 0)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Нет фильмов для удаления!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();

                                }
                                else
                                {
                                    ChangeCinemaInfoMenu();
                                    Console.Clear();
                                }

                                break;
                            case 13:
                                if (Rooms.Count == 0)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Нет комнат для редактирования!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();

                                }
                                else
                                {
                                    ChangeRoomInfoMenu();
                                    Console.Clear();
                                }


                                break;
                            case 14:
                                if (Sessions.Count == 0)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Нет сеансов  для редактирования!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();

                                }
                                else
                                {
                                    ChangeSessionInfoMenu();
                                    Console.Clear();
                                }

                                break;
                            case 15:

                                AddCinemaToArchiveMenu();
                                Console.Clear();

                                break;
                            case 16:
                                if (GetArchivatedCinemas().Count == 0)
                                {

                                    while (true)
                                    {
                                        Console.WriteLine("Нет фильмов в архиве!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();
                                }
                                else
                                {
                                    TakeCinemaFromArchiveMenu();
                                    Console.Clear();
                                }
                                break;
                            case 17:
                                if (Sessions.Count == 0)
                                {

                                    while (true)
                                    {
                                        Console.WriteLine("Нет сеансов чтобы продать билет!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();
                                }
                                else
                                {
                                    SaleTicket();
                                    Console.Clear();
                                }

                                break;
                            case 18:

                                EmployeCinemasInfoMenu();
                                Console.Clear();
                                break;
                            case 19:
                                if (Rooms.Count == 0)
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("Нет комнат!");
                                        var kk = Console.ReadKey();
                                        if (kk.Key == ConsoleKey.Escape)
                                        {
                                            break;
                                        }
                                    }
                                    Console.Clear();

                                }
                                else
                                {
                                    RoomsInfoMenu();
                                    Console.Clear();
                                }
                                Console.Clear();
                                break;
                            case 20:
                                SessionUpdate();
                                PrintSortedSessionsList();
                                Console.Clear();
                                break;
                        }
                        Save();
                    }
                    if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        exit = true;
                        break;
                    }
                }
                if (exit == true)
                {
                    break;
                }

            }


        }

        public void CustomerMenu()
        {
            int scetcik = 6;
            List<string> CustomerMenu = new List<string> { "Информация о сеансах", "Информация о фильмах", "Информация о заллах" };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "CustomerMenu";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < CustomerMenu.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[i].Length / 2, 6 + i);
                    Console.WriteLine(CustomerMenu[i]);
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[scetcik - 6].Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + CustomerMenu[scetcik - 6].Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {

                    Console.Beep();
                    scetcik--;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + CustomerMenu.Count())
                {

                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (scetcik)
                    {
                        case 6:
                            SessionUpdate();
                            PrintSortedSessionsList();
                            break;
                        case 7:
                            CustomerCinemasInfoMenu();
                            break;
                        case 8:
                            RoomsInfoMenu();
                            break;
                    }
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
            }

        }

        public void BossMenu()
        {
            int scetcik = 6;
            List<string> CustomerMenu = new List<string> { "Статистика проданных мест на сеанс", "Статистика проданных мест на  фильм", };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "BossMenu";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < CustomerMenu.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[i].Length / 2, 6 + i);
                    Console.WriteLine(CustomerMenu[i]);
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - CustomerMenu[scetcik - 6].Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + CustomerMenu[scetcik - 6].Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {

                    Console.Beep();
                    scetcik--;
                    Console.Clear();
                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + CustomerMenu.Count())
                {

                    Console.Beep();
                    scetcik++;
                    Console.Clear();

                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (scetcik)
                    {
                        case 6:
                            if (Sessions.Count == 0)
                            {

                                while (true)
                                {
                                    Console.WriteLine("Нет сеансов !");
                                    var kk = Console.ReadKey();
                                    if (kk.Key == ConsoleKey.Escape)
                                    {
                                        break;
                                    }
                                }
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine(GetStatisticBySession().ToString() + "% is full");
                                while (true)
                                {
                                    var kk = Console.ReadKey();
                                    if (kk.Key == ConsoleKey.Escape)
                                    {
                                        break;
                                    }
                                }
                            }
                            break;
                        case 7:
                            Console.WriteLine(GetStatisticByCinemas().ToString() + "% is full");
                            while (true)
                            {
                                var kk = Console.ReadKey();
                                if (kk.Key == ConsoleKey.Escape)
                                {
                                    break;
                                }
                            }
                            break;

                    }
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
            }


        }

        public void MainMenu()
        {
         Loading();
            int scetcik = 6;
            List<string> UsersMenu = new List<string> { "Сотрудник", "Клиент", "Начальник" };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string message = "Users Menu";
                Console.SetCursorPosition(Console.WindowWidth / 2 - message.Length / 2, 2);
                Console.WriteLine(message);
                for (int i = 0; i < UsersMenu.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - UsersMenu[i].Length / 2, 6 + i);
                    Console.WriteLine(UsersMenu[i]);
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - UsersMenu[scetcik - 6].Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + UsersMenu[scetcik - 6].Length / 2 + 3, scetcik);
                Console.WriteLine("<");

                while (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();



                    if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                    {
                        Console.Beep();
                        scetcik--;
                        Console.Clear();
                    }
                    else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + UsersMenu.Count())
                    {
                        Console.Beep();
                        scetcik++;
                        Console.Clear();

                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();

                        switch (scetcik)
                        {
                            case 6:
                                EmployeMenu();
                                break;
                            case 7:
                                CustomerMenu();
                                break;
                            case 8:
                                BossMenu();
                                break;
                        }
                    }
                }

            }
        }

        public bool Save()
        {

            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("build");
            xmlDoc.AppendChild(rootNode);

            XmlNode nameNode = xmlDoc.CreateElement("name");
            nameNode.InnerText = this.Name;
            rootNode.AppendChild(nameNode);


            XmlNode RoomCountNode = xmlDoc.CreateElement("RoomCount");
            RoomCountNode.InnerText = Rooms.Count().ToString();
            rootNode.AppendChild(RoomCountNode);

            foreach (var rm in this.Rooms)
            {
                XmlNode roomNode = xmlDoc.CreateElement("room");

                XmlNode nameRoom = xmlDoc.CreateElement("name");
                nameRoom.InnerText = rm.GetName();
                roomNode.AppendChild(nameRoom);

                XmlNode formatRoom = xmlDoc.CreateElement("format");
                formatRoom.InnerText = ((int)rm.GetFormat()).ToString();
                roomNode.AppendChild(formatRoom);

                XmlNode vipRoom = xmlDoc.CreateElement("vip");
                vipRoom.InnerText = (rm.GetVip() ? 1 : 0).ToString();
                roomNode.AppendChild(vipRoom);

                /////////////////////////////////////////////////////////////////////////////////////////
                #region XERABORA

                XmlNode RowRoom = xmlDoc.CreateElement("MatrixRow");
                RowRoom.InnerText = rm.places.GetLength(0).ToString();
                roomNode.AppendChild(RowRoom);

                List<Place> placessss = new List<Place>();
                for (int i = 0; i < rm.GetPlaces().GetLength(0); i++)
                {
                    for (int j = 0; j < rm.GetPlaces().GetLength(1); j++)
                    {
                        placessss.Add(rm.places[i, j]);
                    }
                }

                XmlNode SIZERoom = xmlDoc.CreateElement("SizeRoom");
                SIZERoom.InnerText = (rm.GetPlaces().GetLength(0) * rm.GetPlaces().GetLength(1)).ToString();
                roomNode.AppendChild(SIZERoom);

                foreach (var pl in placessss)
                {
                    XmlNode roomPlace = xmlDoc.CreateElement("place");

                    XmlNode PlaceRow = xmlDoc.CreateElement("Row");
                    PlaceRow.InnerText = pl.GetPlace().ToString();
                    roomPlace.AppendChild(PlaceRow);


                    XmlNode PlacePlace = xmlDoc.CreateElement("placeofrow");
                    PlacePlace.InnerText = pl.GetRow().ToString();
                    roomPlace.AppendChild(PlacePlace);

                    XmlNode EmptyPlace = xmlDoc.CreateElement("EmptyPlace");
                    EmptyPlace.InnerText = (pl.GetEmpty() ? 1 : 0).ToString();
                    roomPlace.AppendChild(EmptyPlace);

                    roomNode.AppendChild(roomPlace);
                }


                #endregion



                rootNode.AppendChild(roomNode);
            }

            foreach (var cin in this.Cinemas)
            {

                XmlNode cinemaNode = xmlDoc.CreateElement("cinema");
                XmlNode nameCinema = xmlDoc.CreateElement("name");
                nameCinema.InnerText = cin.GetName();
                cinemaNode.AppendChild(nameCinema);

                XmlNode aboutCinema = xmlDoc.CreateElement("about");
                aboutCinema.InnerText = cin.GetAbout();
                cinemaNode.AppendChild(aboutCinema);

                XmlNode directorCinema = xmlDoc.CreateElement("director");
                directorCinema.InnerText = cin.GetDirector();
                cinemaNode.AppendChild(directorCinema);

                XmlNode ArchivatedCinema = xmlDoc.CreateElement("Archivated");
                ArchivatedCinema.InnerText = (cin.Archivated ? 1 : 0).ToString();
                cinemaNode.AppendChild(ArchivatedCinema);

                XmlNode actiorsCinema = xmlDoc.CreateElement("actors");

                foreach (var actr in cin.actors)
                {
                    XmlNode actiorCinema = xmlDoc.CreateElement("actor");
                    actiorCinema.InnerText = actr;
                    actiorsCinema.AppendChild(actiorCinema);
                }
                cinemaNode.AppendChild(actiorsCinema);

                XmlNode PremierCinema = xmlDoc.CreateElement("Premier");
                PremierCinema.InnerText = cin.GetPremier().ToString();
                cinemaNode.AppendChild(PremierCinema);

                XmlNode JanresCinema = xmlDoc.CreateElement("Janres");
                foreach (var janrs in cin.Janres)
                {
                    XmlNode JanreCinema = xmlDoc.CreateElement("Janre");
                    JanreCinema.InnerText = ((int)janrs).ToString();
                    JanresCinema.AppendChild(JanreCinema);
                }

                cinemaNode.AppendChild(JanresCinema);
                rootNode.AppendChild(cinemaNode);
            }

            foreach (var ses in this.Sessions)
            {
                XmlNode SessionNode = xmlDoc.CreateElement("Session");

                XmlNode cinemaNode = xmlDoc.CreateElement("Cinema");


                XmlNode nameCinema = xmlDoc.CreateElement("name");
                nameCinema.InnerText = ses.GetCinema().GetName();
                cinemaNode.AppendChild(nameCinema);

                XmlNode aboutCinema = xmlDoc.CreateElement("about");
                aboutCinema.InnerText = ses.GetCinema().GetAbout();
                cinemaNode.AppendChild(aboutCinema);

                XmlNode directorCinema = xmlDoc.CreateElement("director");
                directorCinema.InnerText = ses.GetCinema().GetDirector();
                cinemaNode.AppendChild(directorCinema);

                XmlNode ArchivatedCinema = xmlDoc.CreateElement("Archivated");
                ArchivatedCinema.InnerText = (ses.GetCinema().Archivated ? 1 : 0).ToString();
                cinemaNode.AppendChild(ArchivatedCinema);

                XmlNode actiorsCinema = xmlDoc.CreateElement("actors");

                foreach (var actr in ses.GetCinema().actors)
                {
                    XmlNode actiorCinema = xmlDoc.CreateElement("actor");
                    actiorCinema.InnerText = actr;
                    actiorsCinema.AppendChild(actiorCinema);
                }
                cinemaNode.AppendChild(actiorsCinema);

                XmlNode PremierCinema = xmlDoc.CreateElement("Premier");
                PremierCinema.InnerText = ses.GetCinema().GetPremier().ToString();
                cinemaNode.AppendChild(PremierCinema);

                XmlNode JanresCinema = xmlDoc.CreateElement("Janres");
                foreach (var janrs in ses.GetCinema().Janres)
                {

                    XmlNode JanreCinema = xmlDoc.CreateElement("Janre");
                    JanreCinema.InnerText = ((int)janrs).ToString();
                    JanresCinema.AppendChild(JanreCinema);
                }
                cinemaNode.AppendChild(JanresCinema);

                SessionNode.AppendChild(cinemaNode);




                XmlNode roomNode = xmlDoc.CreateElement("room");

                XmlNode nameRoom = xmlDoc.CreateElement("name");
                nameRoom.InnerText = ses.GetRoom().GetName();
                roomNode.AppendChild(nameRoom);

                XmlNode formatRoom = xmlDoc.CreateElement("format");
                formatRoom.InnerText = ((int)ses.GetRoom().GetFormat()).ToString();
                roomNode.AppendChild(formatRoom);

                XmlNode vipRoom = xmlDoc.CreateElement("vip");
                vipRoom.InnerText = (ses.GetRoom().GetVip() ? 1 : 0).ToString();
                roomNode.AppendChild(vipRoom);



                XmlNode RowRoom = xmlDoc.CreateElement("MatrixRow");
                RowRoom.InnerText = ses.GetRoom().places.GetLength(0).ToString();
                roomNode.AppendChild(RowRoom);

                List<Place> placessss = new List<Place>();
                for (int i = 0; i < ses.GetRoom().GetPlaces().GetLength(0); i++)
                {
                    for (int j = 0; j < ses.GetRoom().GetPlaces().GetLength(1); j++)
                    {
                        placessss.Add(ses.GetRoom().places[i, j]);
                    }
                }

                foreach (var pl in placessss)
                {
                    XmlNode roomPlace = xmlDoc.CreateElement("place");

                    XmlNode PlaceRow = xmlDoc.CreateElement("Row");
                    PlaceRow.InnerText = pl.GetRow().ToString();
                    roomPlace.AppendChild(PlaceRow);


                    XmlNode PlacePlace = xmlDoc.CreateElement("placeofrow");
                    PlacePlace.InnerText = pl.GetPlace().ToString();
                    roomPlace.AppendChild(PlacePlace);

                    XmlNode EmptyPlace = xmlDoc.CreateElement("EmptyPlace");
                    EmptyPlace.InnerText = (pl.GetEmpty() ? 1 : 0).ToString();
                    roomPlace.AppendChild(EmptyPlace);


                    roomNode.AppendChild(roomPlace);
                }




                SessionNode.AppendChild(roomNode);


                XmlNode SessionTime = xmlDoc.CreateElement("Time");
                SessionTime.InnerText = ses.GetDate().ToString();
                SessionNode.AppendChild(SessionTime);

                rootNode.AppendChild(SessionNode);
            }

            xmlDoc.Save("test.xml");
            return true;
        }

        public bool Loading()
        {

            Rooms.Clear();
            Cinemas.Clear();
            Sessions.Clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("test.xml");

            XmlNode nameNode = xmlDoc.GetElementsByTagName("name").Item(0);
            this.Name = nameNode.InnerText;


            XmlNode RoomsCount = xmlDoc.GetElementsByTagName("RoomCount").Item(0);
            int RoomsCounts = Convert.ToInt32(RoomsCount.InnerText);

            var roomsNode = xmlDoc.GetElementsByTagName("room");

            foreach (XmlNode room in roomsNode)
            {

                if (RoomsCounts > 0)
                {
                    var nameRoom = room.FirstChild;
                    var loadname = nameRoom.InnerText;
                    room.RemoveChild(room.FirstChild);

                    var formatRoom = room.FirstChild;
                    Formats loadformat = (Formats)Convert.ToInt32(formatRoom.InnerText);
                    room.RemoveChild(room.FirstChild);

                    var vipRoom = room.FirstChild;

                    bool loadvip = ((Convert.ToInt32(vipRoom.InnerText) == 0) ? false : true);
                    room.RemoveChild(room.FirstChild);


                    var MatrixRow = room.FirstChild;
                    int LoadMatrixRow = Convert.ToInt32(MatrixRow.InnerText);
                    room.RemoveChild(room.FirstChild);

                    var SIZERoom = room.FirstChild;
                    int LoadSIZERoom = Convert.ToInt32(SIZERoom.InnerText);
                    room.RemoveChild(room.FirstChild);

                    #region xerabora3



                    var placessssNode = room.ChildNodes;

                    List<Place> loadPlacesList = new List<Place>();

                    foreach (XmlNode place in placessssNode)
                    {


                        var Row = place.FirstChild;
                        int LoadRow = Convert.ToInt32(Row.InnerText);
                        place.RemoveChild(place.FirstChild);

                        var PlacePlace = place.FirstChild;
                        int LoadPlacePlace = Convert.ToInt32(PlacePlace.InnerText);
                        place.RemoveChild(place.FirstChild);

                        var EmptyPlace = place.FirstChild;
                        bool loademptyplace = ((Convert.ToInt32(EmptyPlace.InnerText) == 0) ? false : true);
                        place.RemoveChild(place.FirstChild);

                        loadPlacesList.Add(new Place(LoadRow, LoadPlacePlace, loademptyplace));


                    }



                    room.RemoveChild(room.FirstChild);

                    #endregion

                    Room rm = new Room(loadname, loadformat, loadvip, LoadMatrixRow, (placessssNode.Count / LoadMatrixRow));

                    rm.AddPlaces(loadPlacesList, LoadMatrixRow);


                    this.AddRoom(rm);

                    RoomsCounts--;
                }
            }

            var cinemasNode = xmlDoc.GetElementsByTagName("cinema");
            foreach (XmlNode cinema in cinemasNode)
            {
                var nameCinema = cinema.FirstChild;
                var loadname = nameCinema.InnerText;
                cinema.RemoveChild(cinema.FirstChild);

                var aboutCinema = cinema.FirstChild;
                var loadabout = aboutCinema.InnerText;
                cinema.RemoveChild(cinema.FirstChild);

                var directorCinema = cinema.FirstChild;
                var loaddirector = nameCinema.InnerText;
                cinema.RemoveChild(cinema.FirstChild);

                var arcihvatedCinema = cinema.FirstChild;
                bool loadarchivated = ((Convert.ToInt32(arcihvatedCinema.InnerText) == 0) ? false : true);
                cinema.RemoveChild(cinema.FirstChild);

                var actorsCinema = cinema.FirstChild;
                List<string> loadactors = new List<string>();
                foreach (XmlNode actor in actorsCinema)
                {
                    loadactors.Add(actor.InnerText);
                }
                cinema.RemoveChild(cinema.FirstChild);

                var premierCinema = cinema.FirstChild;
                var loadpremier = Convert.ToDateTime(premierCinema.InnerText);
                cinema.RemoveChild(cinema.FirstChild);

                var janresCinema = cinema.FirstChild;
                List<Genres> loadjanres = new List<Genres>();
                foreach (XmlNode janre in janresCinema)
                {
                    loadjanres.Add((Genres)Convert.ToInt32(janre.InnerText));
                }
                cinema.RemoveChild(cinema.FirstChild);
                Cinema cin = new Cinema(loadname, loadabout, loadpremier, loadjanres, loaddirector, loadactors);
                cin.Archivated = loadarchivated;
                this.AddCinema(cin);
            }


            var SeesionNodes = xmlDoc.GetElementsByTagName("Session");
            foreach (XmlNode session in SeesionNodes)
            {
                #region CinemaNode

                XmlNode CinemaNode = session.FirstChild;

                var CinemaName = CinemaNode.FirstChild;
                var loadname = CinemaName.InnerText;
                CinemaNode.RemoveChild(CinemaNode.FirstChild);


                var aboutCinema = CinemaNode.FirstChild;
                var loadabout = aboutCinema.InnerText;
                CinemaNode.RemoveChild(CinemaNode.FirstChild);

                var directorCinema = CinemaNode.FirstChild;
                var loaddirector = directorCinema.InnerText;
                CinemaNode.RemoveChild(CinemaNode.FirstChild);

                var arcihvatedCinema = CinemaNode.FirstChild;
                bool loadarchivated = ((Convert.ToInt32(arcihvatedCinema.InnerText) == 0) ? false : true);
                CinemaNode.RemoveChild(CinemaNode.FirstChild);

                var actorsCinema = CinemaNode.FirstChild;
                List<string> loadactors = new List<string>();
                foreach (XmlNode actor in actorsCinema)
                {
                    loadactors.Add(actor.InnerText);
                }
                CinemaNode.RemoveChild(CinemaNode.FirstChild);

                var premierCinema = CinemaNode.FirstChild;
                var loadpremier = Convert.ToDateTime(premierCinema.InnerText);
                CinemaNode.RemoveChild(CinemaNode.FirstChild);

                var janresCinema = CinemaNode.FirstChild;
                List<Genres> loadjanres = new List<Genres>();
                foreach (XmlNode janre in janresCinema)
                {
                    loadjanres.Add((Genres)Convert.ToInt32(janre.InnerText));
                }
                CinemaNode.RemoveChild(CinemaNode.FirstChild);

                session.RemoveChild(session.FirstChild);
                #endregion

                ///////////////////////////////////////////////////////////////////////////

                XmlNode RoomNode = session.FirstChild;


                var nameRoom = RoomNode.FirstChild;

                var LoadName = nameRoom.InnerText;
                RoomNode.RemoveChild(RoomNode.FirstChild);



                var formatRoom = RoomNode.FirstChild;
                Formats loadformat = (Formats)Convert.ToInt32(formatRoom.InnerText);
                RoomNode.RemoveChild(RoomNode.FirstChild);

                var vipRoom = RoomNode.FirstChild;
                bool loadvip = ((Convert.ToInt32(vipRoom.InnerText) == 0) ? false : true);
                RoomNode.RemoveChild(RoomNode.FirstChild);


                var MatrixRow = RoomNode.FirstChild;
                int LoadMatrixRow = Convert.ToInt32(MatrixRow.InnerText);
                RoomNode.RemoveChild(RoomNode.FirstChild);

                var SIZERoom = RoomNode.FirstChild;
                int LoadSIZERoom = Convert.ToInt32(SIZERoom.InnerText);
                RoomNode.RemoveChild(RoomNode.FirstChild);


                var placessssNode = RoomNode.ChildNodes;

                List<Place> loadPlacesList = new List<Place>();

                foreach (XmlNode place in placessssNode)
                {
                    if (LoadSIZERoom > 0)
                    {

                        var Row = place.FirstChild;
                        int LoadRow = Convert.ToInt32(Row.InnerText);
                        place.RemoveChild(place.FirstChild);

                        var PlacePlace = place.FirstChild;
                        int LoadPlacePlace = Convert.ToInt32(PlacePlace.InnerText);
                        place.RemoveChild(place.FirstChild);

                        var EmptyPlace = place.FirstChild;
                        bool loademptyplace = ((Convert.ToInt32(EmptyPlace.InnerText) == 0) ? false : true);
                        place.RemoveChild(place.FirstChild);

                        loadPlacesList.Add(new Place(LoadRow, LoadPlacePlace, loademptyplace));

                    }
                }


                RoomNode.RemoveChild(RoomNode.FirstChild);
                session.RemoveChild(session.FirstChild);

                var SessionDate = session.FirstChild;
                var loadDate = Convert.ToDateTime(SessionDate.InnerText);
                session.RemoveChild(session.FirstChild);

                Room rm = new Room(LoadName, loadformat, loadvip, LoadMatrixRow, (placessssNode.Count / LoadMatrixRow));
                rm.AddPlaces(loadPlacesList, LoadMatrixRow);
                Session ses = new Session((new Cinema(loadname, loadabout, loadpremier, loadjanres, loaddirector, loadactors)), loadDate, rm);


                this.AddSession(ses);

            }

            return true;
        }

        public double GetStatisticBySession()
        {
            double percent = 0;
            Session ses;
            ses = ChooseSession();
            double averace = 0;
            averace = ses.GetRoom().GetPlaces().GetLength(0) * ses.GetRoom().GetPlaces().GetLength(1);
            percent = (averace / (ses.GetRoom().GetFullPlaces()));
            return percent;
        }

        public double GetStatisticByCinemas()
        {
            Cinema cin;
            cin = ChooseCinema();
            double templ = 0;
            double percent;
            double averace = 0;
            for (int i = 0; i < Sessions.Count; i++)
            {
                if (Sessions[i].GetCinema().GetName() == cin.GetName())
                {
                    averace = Sessions[i].GetRoom().GetPlaces().GetLength(0) * Sessions[i].GetRoom().GetPlaces().GetLength(1);
                    percent = (averace / (Sessions[i].GetRoom().GetFullPlaces()));
                    templ = templ + percent;
                }

            }


            return templ;
        }
    }
}


