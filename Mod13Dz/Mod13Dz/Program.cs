using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BankLib;

namespace Mod13Dz
{
    internal class Program
    {
        static Queue<Client> queue = new Queue<Client>();
        static void Main(string[] args)
        {
            FirstMenu();
        }

        static void FirstMenu()
        {
            Console.Clear();
            Console.WriteLine("1) Кезекке тұру үшін");
            Console.WriteLine("2) Келесі тұтынушыға қызмет көрсету");
            Console.WriteLine("3) Бағдарламадан шығыңыз");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddClientToQueue();
                    break;

                case "2":
                    ServeNextClient();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Қате таңдау. Tағы да қайталап көріңіз.");
                    Thread.Sleep(3000);
                    FirstMenu();
                    break;
            }
            Console.WriteLine();
        }

        static void AddClientToQueue()
        {
            Console.Clear();
            Console.WriteLine("Қызметті таңдаңыз:");
            Console.WriteLine("1. Кредитование");
            Console.WriteLine("2. Депозит ашу");
            Console.WriteLine("3. Консультация");
            Console.WriteLine("4. Артқа");

            string choice = Console.ReadLine();
            string service= "";

            switch (choice)
            {
                case "1":
                    service = "Кредитование";
                    break;
                case "2":
                    service = "Депозит ашу";
                    break;
                case "3":
                    service = "Консультация";
                    break;
                case "4":
                    FirstMenu();
                    break;
                default:
                    Console.WriteLine("Қате таңдау. Tағы да қайталап көріңіз.");
                    Thread.Sleep(3000);
                    AddClientToQueue();
                    break;
            }
            Console.Write("Клиенттің ЖСН енгізіңіз: ");
            string id = Console.ReadLine();

            Client client = new Client(id, service);

            queue.Enqueue(client);

            Console.WriteLine($"{client.Service} клиент {client.Id} кезекке қосылды.");
            PrintQueueStatus();
        }

        static void ServeNextClient()
        {
            if (queue.Count > 0)
            {
                Client client = queue.Dequeue();
                Console.WriteLine($"Қызмет көрсетілді {client.Service} клиент {client.Id}.");
            }
            else
            {
                Console.WriteLine("Кезек бос. Қызмет көрсететін клиенттер жоқ.");
            }

            PrintQueueStatus();
        }

        static void PrintQueueStatus()
        {
            Console.WriteLine();
            Console.WriteLine($"Ағымдағы кезек ({queue.Count} чел.):");
            foreach (var client in queue)
            {
                Console.WriteLine($"{client.Service} клиент {client.Id}");
            }

            Console.WriteLine();
            Console.WriteLine("Мәзірге оралу [Y/N]?");
            string choice = Console.ReadLine();

            if (choice == "Y" || choice == "y")
            {
                FirstMenu();
            }
            else if (choice == "N" || choice == "n") 
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Қате таңдау. тағы да қайталап көріңіз.");
                Thread.Sleep(3000);
                PrintQueueStatus();
            }
        }

    }
}
