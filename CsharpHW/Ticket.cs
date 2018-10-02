using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpHW
{
    class Ticket
    {
        private Session session;
        private int Price=0;
        public  Ticket(Session session)
        {
            this.session = session;
        }

        public  int GetPrice()
        {
            if (session.GetRoom().GetFormat()==Formats.Format_2D)
            {
                Price = Price + 2;
            }
            if (session.GetRoom().GetFormat() == Formats.Format_3D)
            {
                Price = Price + 3;
            }
            if (session.GetRoom().GetFormat() == Formats.Imax)
            {
                Price = Price + 6;
            }
            if (session.GetDate().Hour > 9 && session.GetDate().Hour <= 12)
            {
                Price = Price +1;

            }
            if (session.GetDate().Hour > 12&&session.GetDate().Hour <18)
            {
                Price = Price + 2;
            }
            if (session.GetDate().Hour > 18 && session.GetDate().Hour < 23)
            {
                Price = Price + 3;
            }

            if (session.GetRoom().GetVip() ==true)
            {
                Price = Price + 10;
            }
            return Price;
        }

        public void printTicket(Place place)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Фильм:{session.GetCinema().GetName()}");
            Console.WriteLine($"Комната:{session.GetRoom().GetName()}");
            if (session.GetRoom().GetVip() == true)
            {
                Console.WriteLine($"Комфорт:VIP");
            }
            else
            {
                Console.WriteLine($"Комфорт:Простой");
            }
            Console.WriteLine($"Ряд:{place.GetRow()}");
            Console.WriteLine($"Место:{place.GetPlace()}");
            Console.WriteLine($"Время:{session.GetDate().Day}.{session.GetDate().Month}.{session.GetDate().Year}    {session.GetDate().Hour}:{session.GetDate().Minute}");

            Console.WriteLine($"Цена:{GetPrice().ToString()}$");
            Console.WriteLine("----------------------------------");
        }

      
    }
}
