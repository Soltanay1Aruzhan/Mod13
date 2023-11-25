using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod13prac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            Task4();
        }



        static List<T> InputL<T>()
        {

            List<T> list = new List<T>();
            Random rand = new Random();
            for (int i = 0; i < rand.Next(1, 30); i++)
            {
                var t = Convert.ChangeType(rand.Next(1, 100), typeof(T));
                list.Add((T)t);
            }
            return list;

        }
        static void Task1()
        {
            List<int> list = InputL<int>();

            int max1 = list[0];
            int max2 = list[0];

            int index2 = 0;
            int index1 = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (max1 < list[i])
                {
                    max2 = max1;
                    max2 = list[i];
                    index2 = index1;
                }
            }

            Console.WriteLine($"Макс элемент - {max2} находится на индексе {index2}");

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]%2 != 0)
                {
                    list.Remove(i);
                }
            }

            foreach (int i in list)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine();
        }


        static void Task2()
        {
            List<double> list = InputL<double>();

            double sum = 0;

            for (int i = 0; i < list.Count;i++)
            {
                sum += list[i];
            }

            double avg = sum/list.Count;
            Console.WriteLine("Average - " + avg);

            List<double> result = list.Where(a => a > avg).ToList();

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Result");

            foreach (int i in result)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        static void Task3()
        {
            List<int> list = InputL<int>();

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Result: ");

            List<int> result = new List<int>();

            for (int i = list.Count-1;i >= 0; i--)
            {
                result.Add(list[i]);
            }

            foreach (int i in result)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        static void Task4()
        {
            List<int> list = new List<int> { 10010, 8500, 5500, 10300, 4500, 10500 };

            foreach (int i in list)
            {
                if (i < 10000)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
            foreach (int i in list)
            {
                if (i >= 10000)
                {
                    Console.Write(i + " ");
                }
            }
        }

    }
}
