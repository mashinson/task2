using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2_lab3_9._11._2016
{
    class Program
    {

        // Сложить два числа используя битовые операции 
        public static int Add(int a, int b)
        {
            if (b == 0)  return a;

            return Add(a ^ b, (a & b) << 1);
        }


        //Перемжножить два числа используя битовые операции 
        public static int Multiplication(int a, int b)
        {
            int result = 0;

            do
            {
                if ((a & 1) > 0) result = Add(result, b);

                b <<= 1;
                a >>= 1;
            } while (a > 0);

            return result;
        }

        //Возвести в степень используя битовые операции 
        public static int binpow(int a, int n)
        {
            int res = 1;
            while (n > 0)
            {
                if ((n & 1) > 0) res = Multiplication(res, a);
                a = Multiplication(a, a);
                n >>= 1;
            }
            return res;
        }
        static void Main(string[] args)
        {
            int number1 = 0,
                number2 = 0;

            Console.Write("Введите первое число: ");
            string s1 = Console.ReadLine();
            bool result1 = int.TryParse(s1, out number1);
            Console.WriteLine();

            Console.Write("Введите второе число: ");
            string s2 = Console.ReadLine();
            bool result2 = int.TryParse(s2, out number2);
            int result = 0;
            if (result1 == true && result2 == true)
            {
                // Сложить два числа 
                Console.WriteLine();
                result = Add(number1, number2);
                Console.WriteLine("Сложение двух чисел: {0}", result);

                //Перемжножить два числа 
                Console.WriteLine();
                result = Multiplication(number1, number2);
                Console.WriteLine("Умножение двух чисел: {0}", result);

                //Возвести в степерь 
                Console.WriteLine();
                result = binpow(number1, number2);
                Console.WriteLine("Возведение в степень: {0}", result);

            }
            else Console.WriteLine("Введите числа");


            Console.ReadLine();
        }
    }
}
