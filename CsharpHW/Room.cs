using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHW
{
    public enum Formats
    {
        Format_2D = 1,
        Format_3D = 2,
        Imax = 3
    }

    public class Room
    {
        private string name;
        private Formats format;
        public Place[,] places;
        private bool Vip;

        public Room() { }
        public Room(string name, Formats format, bool Vip, int Rows, int places)
        {
            this.places = new Place[Rows, places];

            for (int i = 0; i < this.places.GetLength(0); i++)
            {
                for (int j = 0; j < this.places.GetLength(1); j++)
                {
                    this.places[i, j] = new Place(i, j, true);
                }
            }

            this.format = format;
            this.Vip = Vip;
            this.name = name;
        }

        public Place[,] MatrixFromArray(List<Place> PlaceList, int Row)
        {

            Place[,] places = new Place[Row, PlaceList.Count() / Row];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < (PlaceList.Count() / Row); j++)
                {
                    places[i, j] = new Place(PlaceList[i * Row + j].GetPlace(), PlaceList[i * Row + j].GetRow(), PlaceList[i * Row + j].GetEmpty());
                }
            }
            return places;
        }

        public void AddPlaces(List<Place> _places, int Row)
        {


            SetPlace(MatrixFromArray(_places, Row));

        }

        public string GetName()
        {
            return name;
        }

        public void SetVip(bool Vip)
        {
            this.Vip = Vip;
        }

        public bool GetVip()
        {
            return Vip;
        }

        public Formats GetFormat()
        {
            return format;
        }

        public Place[,] GetPlaces()
        {
            return places;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetFormat(Formats format)
        {
            this.format = format;
        }

        public void SetPlace(Place[,] place)
        {
            this.places = place;
            for (int i = 0; i < place.GetLength(0); i++)
            {
                for (int j = 0; j < place.GetLength(1); j++)
                {
                    places[i, j] = place[i, j];
                }
            }
        }

        public void PrintRoomInfo()
        {
            Console.Write($" ");
            for (int i = 0; i < places.GetLength(1); i++)
            {
                if (i < 9)
                {
                    Console.Write($"  {i + 1}");
                }
                else
                {
                    Console.Write($" {i + 1}");
                }
            }
            Console.Write("\n");

            for (int i = 0; i < places.GetLength(0); i++)
            {
                for (int j = 0; j < places.GetLength(1); j++)
                {
                    if (j == 0 && i >= 0)
                    {
                        if (i < 9)
                        {
                            Console.Write(i + 1 + " ");
                        }
                        else
                        {
                            Console.Write(i + 1);
                        }
                    }
                    if (places[i, j].PlaceGetEmpty() == true)
                    {
                        Console.Write("[ ]");
                    }
                    else if (places[i, j].PlaceGetEmpty() == false)
                    {
                        Console.Write("[X]");
                    }
                }
                Console.Write("\n");

            }
            if (!Vip)
            {
                Console.WriteLine("Простая комната.");
            }
            else
            {
                Console.WriteLine("Vip");
            }

            Console.WriteLine(format.ToString());
            Console.WriteLine();
            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

        }

        public Place ChoosePlace()
        {
            int row = 0;
            int col1 = 0;
            int col2 = 0;

            Place place = new Place(0, 0, true);
            while (true)
            {

                for (int i = 0; i < places.GetLength(1); i++)
                {
                    Console.Write($"  {i + 1}");
                }
                Console.Write("\n");

                for (int i = 0; i < places.GetLength(0); i++)
                {
                    for (int j = 0; j < places.GetLength(1); j++)
                    {
                        if (j == 0 && i >= 0)
                        {
                            Console.Write(i + 1);
                        }
                        if (places[i, j].PlaceGetEmpty() == true)
                        {
                            Console.Write("[ ]");
                        }
                        else if (places[i, j].PlaceGetEmpty() == false)
                        {
                            Console.Write("[X]");
                        }
                    }
                    Console.Write("\n");
                }

                Console.SetCursorPosition(col2 + 2, row + 1);
                Console.Write("*");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && row > 0)
                {
                    row--;
                }
                if (key.Key == ConsoleKey.DownArrow && row < places.GetLength(0) - 1)
                {
                    row++;
                }
                if (key.Key == ConsoleKey.LeftArrow && col1 > 0)
                {
                    col1--;
                    col2 = col2 - 3;
                }
                if (key.Key == ConsoleKey.RightArrow && col1 < places.GetLength(1) - 1)
                {
                    col1++;
                    col2 = col2 + 3;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    if (places[row, col1].PlaceGetEmpty() == true)
                    {
                        places[row, col1].PlaceGetEmpty(false);
                        place.SetPlace(col1 + 1);
                        place.SetRow(row + 1);
                        break;
                    }

                }
                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }
            Console.Clear();
            return place;

        }

        public void СhangeRoomInfo()
        {
            bool exit = false;
            int scetcik = 6;
            List<string> RoomAboutMenu = new List<string> { "Change Name", "Change Format", "Change comfortableness", "Change the number of places" };
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(Console.WindowWidth / 2 - name.Length / 2, 2);
                Console.WriteLine(name);
                for (int i = 0; i < RoomAboutMenu.Count(); i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - RoomAboutMenu[i].Length / 2, 6 + i);
                    Console.WriteLine(RoomAboutMenu[i]);
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - RoomAboutMenu[scetcik - 6].Length / 2 - 3, scetcik);
                Console.WriteLine(">");
                Console.SetCursorPosition(Console.WindowWidth / 2 + RoomAboutMenu[scetcik - 6].Length / 2 + 3, scetcik);
                Console.WriteLine("<");


                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && scetcik > 6)
                {
                    Console.Beep();

                    scetcik--;
                    Console.Clear();

                }
                else if (key.Key == ConsoleKey.DownArrow && scetcik < 5 + RoomAboutMenu.Count())
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
                            Console.WriteLine("Введите новое название Комнаты");
                            string name = Console.ReadLine();
                            this.name = name;
                            Console.Clear();
                            break;
                        #endregion
                        case 7:
                            Console.Clear();
                            int format = 1;
                            Formats formatt = Formats.Format_2D;

                            while (true)
                            {
                                Console.WriteLine("Выберите новый формат комнаты:(Для выбора используйте стрелки -> <-)");
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
                                var kkk = Console.ReadKey();

                                if (kkk.Key == ConsoleKey.RightArrow && format < 3)
                                {
                                    format++;
                                }
                                if (kkk.Key == ConsoleKey.LeftArrow && format > 1)
                                {
                                    format--;
                                }
                                if (kkk.Key == ConsoleKey.Enter)
                                {
                                    this.format = formatt;
                                    Console.Clear();
                                    break;
                                }
                                Console.Clear();
                            }

                            break;
                        case 8:
                            Console.Clear();
                            int vip = 1;
                            bool Vip = false;
                            while (true)
                            {
                                Console.WriteLine("Выберите новый уровень комфорта комнаты:(Для выбора используйте стрелки -> <-)");
                                Console.WriteLine("Нажмите Enter после выбора");
                                if (vip == 1)
                                {
                                    Console.WriteLine("Простой");
                                    Vip = false;
                                }
                                else if (vip == 2)
                                {
                                    Console.WriteLine("Vip");
                                    Vip = true;

                                }

                                var kkk = Console.ReadKey();

                                if (kkk.Key == ConsoleKey.RightArrow && vip < 2)
                                {
                                    vip++;
                                }
                                if (kkk.Key == ConsoleKey.LeftArrow && vip > 1)
                                {
                                    vip--;
                                }
                                if (kkk.Key == ConsoleKey.Enter)
                                {
                                    Console.Clear();
                                    this.Vip = Vip;
                                    break;

                                }
                                Console.Clear();

                            }
                            exit = true;
                            break;
                        case 9:
                            {
                                Console.WriteLine("Введите новое количество рядов:");
                                int Rows;
                                Int32.TryParse(Console.ReadLine(), out Rows);
                                int places;
                                Console.WriteLine("Введите новое количество меств ряду:");

                                Int32.TryParse(Console.ReadLine(), out places);
                                this.places = new Place[Rows, places];

                                for (int i = 0; i < this.places.GetLength(0); i++)
                                {
                                    for (int j = 0; j < this.places.GetLength(1); j++)
                                    {
                                        this.places[i, j] = new Place(i, j, true);
                                    }
                                }
                                exit = true;
                            }
                            break;
                        case 10:
                            break;


                    }
                    Console.Clear();
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                    if (exit==true)
                {
                    break;
                }
            }
        }

        public double GetFullPlaces()
        {
            double templ =0;
            for (int i = 0; i < places.GetLength(0); i++)
            {
                for (int j = 0; j < places.GetLength(1); j++)
                {
                    if (places[i,j].GetEmpty()==false)
                    {
                        templ++;
                    }
                }
            }
            return templ;
        }

    }
}
