using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHW
{
    public class Session
    {
        private Cinema cinema;
        private DateTime time;
        private Room room;

        public Session(Cinema cinema, DateTime time, Room room)
        {
            this.cinema = cinema;
            this.time = time;
            this.room = room;
        }

        public void SetCinema(Cinema cinema)
        {
            this.cinema = cinema;
        }

        public void SetTime(DateTime time)
        {
            this.time = time;
        }

        public void SetRoom(Room room)
        {
            this.room = room;
        }

        public Cinema GetCinema()
        {
            return cinema;
        }

        public DateTime GetDate()
        {
            return time;
        }

        public Room GetRoom()
        {
            return room;
        }

        public void PrintSessionInfo()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Фильм:{cinema.GetName()}");
            Console.WriteLine($"Комната:{room.GetName()}");
            if (room.GetVip()==true)
            {
                Console.WriteLine($"Комфорт:VIP");
            }
            else
            {
                Console.WriteLine($"Комфорт:Простой");
            }

            Console.WriteLine($"Время:{time.Day}.{time.Month}.{time.Year}    {time.Hour}:{time.Minute}");

            Console.WriteLine("----------------------------------");

        }


    }
}
