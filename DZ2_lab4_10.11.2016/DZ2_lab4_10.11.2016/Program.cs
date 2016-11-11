using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2_lab4_10._11._2016
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите выражение одной строкой: ");
            string str = Console.ReadLine();

            
            int ch1 = 0;       //проверяет на скобки

            // Все допустимые символы в уравнении
            char[] ch = new char[] { '/', '\\', '-', '+', '*', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '(', ')' };

            // Проверяет на допустимые символы и скобки
            for (int i = 0; i < str.Length; i++)
            {
                if (ch.Contains(str[i]))
                {
                    if (str[i] == '(') ch1 += 1;
                    if (str[i] == ')') ch1 -= 1;
                    if (ch1 < 0)
                    {
                        Console.WriteLine("Неправильное рассположение скобок!");
                        Console.ReadLine();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("В строке существуют недопустимые символы!");
                    Console.ReadLine();
                    return;
                }
            }

            if (ch1 != 0)
            {
                Console.WriteLine("Недостаточно скобок!");
                Console.ReadLine();
                return;
            }

            // проверяет первый элемент
            if (str[0] == '/' || str[0] == '\\' || str[0] == '*' || str[0] == ')')
            {
                Console.WriteLine("Первый символ не может быть таким!");
                Console.ReadLine();
                return;
            }

            // проверяет последний элемент
            if (str[str.Length - 1] == '/' || str[str.Length - 1] == '\\' || str[str.Length - 1] == '*' || str[str.Length - 1] == '(')
            {
                Console.WriteLine("Последний символ не может быть таким!");
                Console.ReadLine();
                return;
            }

            char[] operations = new char[] { '/', '\\', '-', '+', '*', '(', ')' };
            string[] strNew = new string[str.Length];
            int j = 0;

            //Если в str две цифры стоят рядом преобразовывает их в число
            for (int i = 0; i < str.Length && j < strNew.Length; i++, j++)
            {

                if (str[i] >= '0' && str[i] <= '9')
                {
                    strNew[j] += str[i];
                    while ((i < str.Length-1) && (operations.Contains(str[i + 1]) == false))
                    {
                        i++;
                        strNew[j] += str[i];
                    }
                }
                else strNew[j] += str[i];
            }

            char[] Newoperations = new char[] { '/', '\\', '-', '+', '*' };
            char[] brackets = new char[] { '(', ')' };
            string o = "o", // операция 
                n = "n";   // число 


            string[] trio = new string[j -2];
            if (j < 3)
            {
                Console.WriteLine("Недостаточно элементов для уравнения!");
                Console.ReadLine();
                return;
            }

            // Делает из массива strNew тройки символов: если нашлась скобочка  - записывается в trio ")" или "(",
            // нашлось число - записывается в trio "o", нашелся оператор - записывается в trio "n"
            for (int i = 0; i < j - 2; i++)
            {

                if (brackets.Contains(strNew[i][0]) == true) trio[i] += strNew[i][0];
                else if (Newoperations.Contains(strNew[i][0]) == true) trio[i] += o;
                else trio[i] += n;

                if (brackets.Contains(strNew[i + 1][0]) == true) trio[i] += strNew[i + 1][0];
                else if (Newoperations.Contains(strNew[i + 1][0]) == true) trio[i] += o;
                else trio[i] += n;

                if (brackets.Contains(strNew[i + 2][0]) == true) trio[i] += strNew[i + 2][0];
                else if (Newoperations.Contains(strNew[i + 2][0]) == true) trio[i] += o;
                else trio[i] += n;

            }

            //Только такими могут быть тройки символов, иначе уравнение записано не правильно
            string[] templates = new string[] {"non", "ono", "(no", "o(n", "no(", ")on", "n)o", "on)", "((n", "n))", "))o", "o((", ")o(", "(n)", "(((", ")))" };
            for (int i = 0; i < trio.Length; i++)
            {
                if (templates.Contains(trio[i]) == false)
                {
                    Console.WriteLine("В рассположении скобочек, чисел и операторов что-то не так!");
                    Console.ReadLine();
                    return;
                }

            }
            Console.WriteLine("Выражение записано правильно!!!!!!");    

            Console.ReadLine();
        }
    }
}
