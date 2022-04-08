using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProblematicProblem
{
    internal class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");

            string userInput = Console.ReadLine().ToLower();
            if (userInput == "yes")
            {
                cont = true;
            }
            else
            {
                cont = false;
                Environment.Exit(0);
            }

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            var userAge = int.TryParse(Console.ReadLine(), out int a);

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            string userInput2 = Console.ReadLine().ToLower();

            if (userInput2 == "sure")
            {

                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = true;
                string userInput3 = Console.ReadLine().ToLower();

                if (userInput3 == "yes")
                {
                    addToList = true;
                }
                else
                {
                    addToList = false;
                }
                Console.WriteLine();

                while (addToList == true)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    string userInput4 = Console.ReadLine().ToLower();
                    if (userInput4 == "yes")
                    {
                        addToList = true;
                    }
                    else
                    {
                        addToList = false;

                    }
                }
            }



            while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Random rng = new Random();
                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (Convert.ToInt32(userAge) > 21 && randomActivity == "Wine Tasting")
                {
                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];

                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! \nIs this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                string userInput5 = Console.ReadLine().ToLower();
                if (userInput5 == "redo")
                {
                    cont = true;

                }
                else
                {
                    cont = false;
                    Environment.Exit(0);
                }
            }
        }
    }
}
