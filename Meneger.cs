using System;
using Cars.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Meneger
    {
        private static Market market = new Market();
        private static Garaj garaj = new Garaj();
        private BazaManagerJson bazaManager = new BazaManagerJson();
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("     Market           Garaje          Exit");
            Console.WriteLine("     press M          press G        press ESC");
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.G:
                    Console.Clear();
                    GarajMenu();
                    break;
                case ConsoleKey.M:
                    Console.Clear();
                    MarketMenu();
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.Backspace:
                default:
                    bazaManager.SaveBaza(Garaj.path, Garaj.DicCars);
                    bazaManager.SaveBaza(Market.path, Market.DicCars);                   
                    return;
            }
        }

        public void Start()
        {
            bazaManager.ReadBaza(Garaj.path);
            bazaManager.ReadBaza(Market.path);            
            MainMenu();
        }

        public void MarketMenu()
        {
            Console.WriteLine("   ADD    _ 1 \n   DELETE _ 2 \n   SHOW   _ 3 \n   BACK   _ Backspace/Esc");
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    market.AddCar();                   
                    MainMenu();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    market.DeleteCar();
                   
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    market.Show();
                    Console.ReadKey();
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.Backspace:
                default:
                    MainMenu();
                    return;
            }
        }
        public void GarajMenu()
        {
            Console.WriteLine("    BUY   _ 1 \n    SHOW  _ 2 \n    BACK  _ Backspace/Esc");
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Clear();
                    garaj.Buy();
                   
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Clear();
                    garaj.Show();
                    Console.ReadKey();
                    break;
                case ConsoleKey.Escape:
                case ConsoleKey.Backspace:
                default:
                    MainMenu();
                    break;
            }
        }
        static public CarType ChooseCarType()
        {
            try
            {
                Console.WriteLine($"Choose the type of car by pressing corresponding key: \n");
                CarType[] carTypeChoise = new CarType[Car.DicChoose.Count];
                int k = 0;
                foreach (CarType item in Car.DicChoose.Keys)
                {
                    Console.WriteLine($"    {item} _ {k}");
                    carTypeChoise[k] = item;
                    k++;
                }
                k = int.Parse(Console.ReadLine());
                return carTypeChoise[k];

            }
            catch (IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Press the right key!");
                return ChooseCarType();
            }
            catch(Exception)
            {
                Console.Clear();
                Console.WriteLine("Press the right key!");
                return ChooseCarType();
            }           
        }

        static public Marka ChooseMarka(CarType CarType)
        {
            try
            {
                Console.WriteLine($"Choose the Mark of car by pressing corresponding key: \n");
                Marka[] carMarkChoise = new Marka[Car.DicChoose[CarType].Count];
                int k = 0;
                foreach (Marka item in Car.DicChoose[CarType].Keys)
                {
                    Console.WriteLine($"    {item} _ {k}");
                    carMarkChoise[k] = item;
                    k++;
                }
                k = int.Parse(Console.ReadLine());
                return carMarkChoise[k];
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Press the right key!");
                return ChooseMarka(CarType);
            }
            
        }

        static public Models ChooseModel(CarType CarType, Marka Marka)
        {
            try
            {
                Console.WriteLine($"Choose the Model of car by pressing corresponding key: \n");
                Models[] carModelsChoise = new Models[Car.DicChoose[CarType][Marka].Count];
                int k = 0;
                foreach (Models item in Car.DicChoose[CarType][Marka])
                {
                    Console.WriteLine($"    {item} _ {k}");
                    carModelsChoise[k] = item;
                    k++;
                }
                k = int.Parse(Console.ReadLine());

                return carModelsChoise[k];
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Press the right key!");
                return ChooseModel(CarType, Marka);
            }
            
        }
    }
}

