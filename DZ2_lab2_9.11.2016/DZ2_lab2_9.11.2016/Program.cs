using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2_lab2_9._11._2016
{
    class Program
    {
        static void Main(string[] args)
        {
            // Дни недели 
            const byte Monday = 0x01;       // 0000 0001 
            const byte Tuesday = 0x02;      // 0000 0010
            const byte Wednesday = 0x04;    // 0000 0100
            const byte Thursday = 0x08;     // 0000 1000
            const byte Friday = 0x10;       // 0001 0000
            const byte Saturday = 0x20;     // 0010 0000
            const byte Sunday = 0x40;       // 0100 0000

            // Пароль 
            const byte CorrectPassword = 0x87;  // 1000 0111

            // Предметы
            byte Algorithms = 0x17;     // 0001 0010
            byte Graphics = 0xC;        // 0000 1100
            byte c_sharp = 0x12;        // 0011 0010            
            byte Math = 0x14;           // 0001 0100
            byte Eng = 0x5;             // 0000 0101


            Console.WriteLine("Список предметов:  ");
            Console.WriteLine("Algorithms (1)");
            Console.WriteLine("Graphics (2)");
            Console.WriteLine("c# (3)");
            Console.WriteLine("Math (4)");
            Console.WriteLine("English (5)");
            Console.WriteLine();


            Console.WriteLine("Дни недели:  ");
            Console.WriteLine("Понедельник (1)");
            Console.WriteLine("Вторник (2)");
            Console.WriteLine("Среда (3)");
            Console.WriteLine("Четверг (4)");
            Console.WriteLine("Пятница (5)");
            Console.WriteLine("Суббота (6)");
            Console.WriteLine("Воскресенье (7)");

            Console.WriteLine();

            // номер предмета и номер дня, которые вводит пользователь 
            int day = 0,
              lesson = 0;

            // предмет и день которые соответствуют номеру предмета и номеру дня, которые вводит пользователь 
            byte d = 0,
                 l = 0;
            
            bool ch = true;  //счетчик который определяет сколько раз смотреть и менять расписание 

            while (ch)
            {
                Console.WriteLine("Хотите поменять расписание? (да (Yes), нет (No))");
                string s3 = Console.ReadLine();
                Console.WriteLine();
                if (s3 == "Yes" || s3 == "yes")
                {
                    Console.WriteLine("Введите пароль: ");
                    string p = Console.ReadLine();
                    byte password = 0;
                    bool pwd = byte.TryParse(p, out password);

                    if (pwd && (password ^ CorrectPassword) == 0)
                    {
                        Console.WriteLine("Пароль правильный!");

                        Console.Write("Введите номер предмета: ");
                        string s4 = Console.ReadLine();
                        bool result3 = int.TryParse(s4, out lesson);
                        Console.WriteLine();

                        Console.Write("Введите номер дня недели: ");
                        string s5 = Console.ReadLine();
                        bool result4 = int.TryParse(s5, out day);
                        Console.WriteLine();

                        if ((result3 == true) && (result4 == true) && (lesson >= 1 && lesson <= 5) && (day >= 1 && day <= 7))
                        {

                            #region day
                            if (day == 1) d = Monday;
                            if (day == 2) d = Tuesday;
                            if (day == 3) d = Wednesday;
                            if (day == 4) d = Thursday;
                            if (day == 5) d = Friday;
                            if (day == 6) d = Saturday;
                            if (day == 7) d = Sunday;
                            #endregion

                            #region lesson
                            if (lesson == 1) Algorithms = (byte)(Algorithms ^ d);
                            if (lesson == 2) Graphics = (byte)(Graphics ^ d);
                            if (lesson == 3) c_sharp = (byte)(c_sharp ^ d);
                            if (lesson == 4) Math = (byte)(Math ^ d);
                            if (lesson == 5) Eng = (byte)(Eng ^ d);
                            #endregion

                            Console.WriteLine("Расписание измененно. ");

                        }
                        else Console.WriteLine("Введите правильный номер соответсвующий дню недели и предмету");

                    }
                    else Console.WriteLine("Пароль неверный");
                }
                else ch = false;
            }

            ch = true;
            while (ch)
            {
                Console.WriteLine("Хотите посмотреть расписание? (да (Yes), нет (No))");
                string str = Console.ReadLine();
                if (str == "Yes" || str == "yes")
                {
                    Console.WriteLine();
                    Console.Write("Введите номер предмета: ");
                    string s2 = Console.ReadLine();
                    bool result2 = int.TryParse(s2, out lesson);
                    Console.WriteLine();

                    Console.Write("Введите номер дня недели: ");
                    string s1 = Console.ReadLine();
                    bool result1 = int.TryParse(s1, out day);
                    Console.WriteLine();


                    if ((result1 == true) && (result2 == true) && (lesson >= 1 && lesson <= 5) && (day >= 1 && day <= 7))
                    {

                        #region day
                        if (day == 1) d = Monday;
                        if (day == 2) d = Tuesday;
                        if (day == 3) d = Wednesday;
                        if (day == 4) d = Thursday;
                        if (day == 5) d = Friday;
                        if (day == 6) d = Saturday;
                        if (day == 7) d = Sunday;
                        #endregion

                        #region lesson
                        if (lesson == 1) l = Algorithms;
                        if (lesson == 2) l = Graphics;
                        if (lesson == 3) l = c_sharp;
                        if (lesson == 4) l = Math;
                        if (lesson == 5) l = Eng;
                        #endregion

                        if ((l & d) > 0) Console.WriteLine("Такой предмет есть в этот день. Этот день рабочий. ");
                        else Console.WriteLine("Этого предмета нет в этот день");
                    }
                    else Console.WriteLine("Введите правильный номер соответсвующий дню недели и предмету");
                }
                else ch = false;
            }


            Console.ReadLine();
        }
    }
}
