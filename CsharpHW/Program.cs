using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
namespace CsharpHW
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Building build = new Building("Togrul's cinema");
            #region Debug

            Room room1 = new Room("Zal 1", Formats.Format_2D, false, 6, 7);
            Room room2 = new Room("Zal 2", Formats.Format_3D, false, 5, 10);
            Room room3 = new Room("Bakcell", Formats.Imax, false, 4, 5);
            Room room4 = new Room("Zal 3", Formats.Format_2D, false, 6, 12);
            Room room5 = new Room("Zal 4", Formats.Format_3D, false, 7, 8);
            Room room6 = new Room("Azercell", Formats.Imax, false, 4, 6);
            Room room7 = new Room("Albali", Formats.Format_2D, true, 3, 4);
            Room room8 = new Room("Bolkart", Formats.Format_3D, true, 3, 4);
            Room room9 = new Room("Zal Vip", Formats.Format_2D, true,2, 5);
            Room room10 = new Room("Step", Formats.Format_3D, true, 4, 7);
            build.AddRoom(room1);
            build.AddRoom(room2);
            build.AddRoom(room3);
            build.AddRoom(room4);
            build.AddRoom(room5);
            build.AddRoom(room6);
            build.AddRoom(room7);
            build.AddRoom(room8);
            build.AddRoom(room9);
            build.AddRoom(room10);
            DateTime time1 = new DateTime(2018, 5,20 );
            DateTime time2 = new DateTime(2018, 4, 23 );
            DateTime time3 = new DateTime(2014, 12, 18);
            DateTime time4 = new DateTime(2016, 5, 12);
            DateTime time5 = new DateTime(2018, 3, 15);

            DateTime time6 = new DateTime(2011,11, 2);

            Cinema cin = new Cinema("Хан Соло: Звёздные войны.Истории", "Фильм расскажет о похождениях юного космического сорвиголовы Хана Соло и его верного напарника Чубакки и о том, как они стали самыми быстрыми пилотами и самыми хитрыми контрабандистами далёкой Галактики.", time1, new List<Genres> { Genres.Action, Genres.Adventure, Genres.Horror }, "Рон Ховард", new List<string>
            {"Олден Эренрайк",
             "Йонас Суотамо",
             "Вуди Харрельсон",
             "Эмилия Кларк",
             "Дональд Гловер",
             "Тэнди Ньютон",
             "Фиби Уоллер-Бридж",
             "Пол Беттани",
             "Джон Фавро",
             "Эрин Келлима"});
            Cinema cin2 = new Cinema("Мстители: Война бесконечности", "Пока Мстители и их союзники продолжают защищать мир от различных опасностей, с которыми не смог бы справиться один супергерой, новая угроза возникает из космоса: Танос. Межгалактический тиран преследует цель собрать все шесть Камней Бесконечности — артефакты невероятной силы, с помощью которых можно менять реальность по своему желанию. Всё, с чем Мстители сталкивались ранее, вело к этому моменту — судьба Земли никогда ещё не была столь неопределённой.", time2, new List<Genres> { Genres.Action,Genres.Adventure,Genres.Comedy}, "Энтони Руссо", new List<string> { "Роберт Дауни мл.", "Крис Хемсворт", "Марк Руффало", "Крис Эванс", "Скарлетт Йоханссон" });
            Cinema cin3 = new Cinema("Соседи. На тропе войны 2", "На этот раз в дом по соседству с Маком и Келли въезжает университетский женский клуб. Чтобы разобраться с новыми соседями, которые не дают им покоя, Мак и Келли решают обратиться за помощью к их бывшему врагу — Тедди Сандерсу.", time4, new List<Genres> { Genres.Comedy}, "Николас Столлер", new List<string> { "Зак Эфрон", "Сет Роген", "Хлоя Грейс Морец", "Роуз Бирн" });
            Cinema cin4 = new Cinema("Хоббит: Битва пяти воинств", "Когда отряд из тринадцати гномов нанимал хоббита Бильбо Бэгинса в качестве взломщика и четырнадцатого, «счастливого», участника похода к Одинокой горе, Бильбо полагал, что его приключения закончатся, когда он выполнит свою задачу — найдет сокровище, которое так необходимо предводителю гномов Торину. Путешествие в Эребор, захваченное драконом Смаугом, королевство гномов, оказалось еще более опасным, чем предполагали гномы и даже Гэндальф — мудрый волшебник, протянувший Торину и его отряду руку помощи.", time3, new List<Genres> { Genres.Action, Genres.Adventure, Genres.Comedy }, "Николас Столлер", new List<string> { "Питер Джексон", "Орландо Блум", "Мартин Фримен", "Ричард Армитидж" });
            Cinema cin5 = new Cinema("Дэдпул 2", "Единственный и неповторимый болтливый наемник — вернулся! Ещё более масштабный, ещё более разрушительный и даже ещё более голозадый, чем прежде! Когда в его жизнь врывается суперсолдат с убийственной миссией, Дэдпул вынужден задуматься о дружбе, семье и о том, что на самом деле значит быть героем, попутно надирая 50 оттенков задниц. Потому что иногда чтобы делать хорошие вещи, нужно использовать грязные приёмчики.", time5, new List<Genres> { Genres.Action, Genres.Adventure, Genres.Comedy }, "Дэвид Литч", new List<string> { "Райан Рейнольдс", "Джош Бролин", "Морена Баккарин", "Джулиан Деннисон", "Зази Битц", "ТиДжей Миллер" });
            Cinema cin6 = new Cinema("1+1 Неприкасаемые", "Пострадав в результате несчастного случая, богатый аристократ Филипп нанимает в помощники человека, который менее всего подходит для этой работы, — молодого жителя предместья Дрисса, только что освободившегося из тюрьмы. Несмотря на то, что Филипп прикован к инвалидному креслу, Дриссу удается привнести в размеренную жизнь аристократа дух приключений.", time6, new List<Genres> { Genres.Comedy }, "Людовико Эйнауди", new List<string> { "Франсуа Клюзе", "Омар Си", "Анн Ле Ни", "Одри Флеро" });

            build.AddCinema(cin);
            build.AddCinema(cin2);
            build.AddCinema(cin3);
            build.AddCinema(cin4);


            build.AddCinema(cin5);
            build.AddCinema(cin6);

            //plce = room1.ChoosePlace();
            // plce = room1.ChoosePlace();
            //plce = room1.ChoosePlace();
            //plce = room1.ChoosePlace();
            // cin.changeCinemaInfo();
            //room1.places[3, 4].SetEmpty(false);
            //  Console.WriteLine("p" + plce.GetPlace() + "r" + plce.GetRow());
            //build.CinemasDelete();


            //build.RoomsInfoMenu();
            //build.RoomsDelete();
            //build.RoomsInfoMenu();

            //   build.CreateTheRoom();
            //room1.PrintRoom();
            // build.CreateCinema();
            //  cin.ChangeCinemaInfo();
            // room1.СhangeRoomInfo();
            //  build.CreateSession();


            //List<DateTime> times = new List<DateTime>();
            //times.Add(time1);
            //times.Add(time2);
            //times.Add(time3);
            //times.Add(time4);


            // Session ses = new Session(cin, time1, room1);
            // Session ses2 = new Session(cin, time2, room1);
            // Session ses3 = new Session(cin, time3, room1);
            // build.Sessions.Add(ses);
            // build.Sessions.Add(ses2);
            // build.Sessions.Add(ses3);

            //// build.Save();
            #endregion

            build.MainMenu();

        }




    }
}