using System;
using System.Reflection.Metadata;

namespace CashRegister.ConsoleApp
{
    public class CashRegister
    {
        public struct Product
        {
            public string name;
            public int price;
            public int id;
        }

        static void Main(string[] args)
        {
            Product roll;
            Product orange;
            Product cheese;

            roll.name = "Bułka";
            roll.price = 1;
            roll.id = 1;

            orange.name = "Pomarańcza";
            orange.price = 5;
            orange.id = 2;

            cheese.name = "Ser";
            cheese.price = 28;
            cheese.id = 3;
            

            int unit = 0;
            decimal kilogram = 0;
            decimal kilogram2 = 0;
            int operation;
            bool success;
            int addnext;
            string retry = "n";

            start:


            Console.WriteLine("Witamy!");

            choice();

            void choice()
            {
                Console.WriteLine("\n1. Bułka");
                Console.WriteLine("2. Pomarańcza");
                Console.WriteLine("3. Ser\n");

                do
                {
                    Console.WriteLine("Wybierz produkt od 1 do 3:");
                    success = int.TryParse(Console.ReadLine(), out operation);
                }
                while ((operation < 1 || operation > 3));


                switch (operation)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj ilość produktu");
                            unit = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine($"Koszt:" + (unit * roll.price));
                            continuation();

                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj wagę produktu");
                            kilogram = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine($"Koszt:" + (kilogram * orange.price));
                            continuation();

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Podaj wagę produktu");
                            kilogram2 = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine($"Koszt:" + (kilogram2 * cheese.price));
                            continuation();

                            break;
                        }
                    default:
                        throw new Exception("Wybrałeś zla operacje\n");
                }

            }
            string continuation()
            {

                do
                {
                    Console.WriteLine("1 - dodaj kolejny produkt \n  2 - zaplac");
                    success = int.TryParse(Console.ReadLine(), out addnext);
                }
                while ((addnext < 1 || addnext > 2));
                switch (addnext)
                {
                    case 1:
                        Console.Clear();
                        choice();
                        break;
                    case 2:
                        Console.Clear();
                        pay();
                        Console.ReadKey();
                        break;
                }
                return "";
            }
            void pay()
            {
                decimal altogether;
                decimal cost1 = roll.price * unit;
                decimal cost2 = orange.price * kilogram;
                decimal cost3 = cheese.price * kilogram2;
                if (cost1 > 0)
                    Console.WriteLine($"Bułka:" + cost1);
                if (cost2 >0)
                    Console.WriteLine($"Pomarańcza:" + cost2);
                if (cost3 > 0)
                    Console.WriteLine($"Ser:" + cost3);


                if (unit != 0 || kilogram != 0 || kilogram2 != 0)
                {
                    altogether = cost1 + cost2 + cost3;
                    Console.WriteLine("Lacznie: {0}", altogether);
                }
                else
                {
                    Console.WriteLine("blad");
                }
            }
            Console.WriteLine("Następny klient? t/n");
            retry = Console.ReadLine();
            if (retry == "t")
            {
                goto start;
            }
            Console.ReadKey();


        }
    }
}