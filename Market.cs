using System;
using Cars.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Market: Ishowable
    {       
        public static Dictionary<int, Car> DicCars = new Dictionary<int, Car>();
        private IBazaSaverReaderCloser bazaManager = new BazaManagerJson();        
        public static string path = @"D:\C#HW\Cars\MarketBaza.txt";
        public Market()
        {

        }
        public void AddCar()
        {
            CarType CarType = Meneger.ChooseCarType();
            Marka CarMarka = Meneger.ChooseMarka(CarType);
            Models CarModel = Meneger.ChooseModel(CarType, CarMarka);
            int ID = 0;
            if (DicCars.Count > 0)
            {
                ID = DicCars.Last().Key;
            }

            if (CarType == CarType.Sedan)
            {
                Console.WriteLine("Input the Number of seets: ");
                int NumberSeets = int.Parse(Console.ReadLine());
               
                DicCars.Add(ID + 1, new Sedan(CarMarka, CarModel, NumberSeets));
                bazaManager.CleanBazaFile(path);
                bazaManager.SaveBaza(path, DicCars);
            }
            else
            {
                Console.WriteLine("Input the Capasity of Track: ");
                int Capacity = int.Parse(Console.ReadLine());
                DicCars.Add(ID + 1, new Track(CarMarka, CarModel, Capacity));
                bazaManager.CleanBazaFile(path);
                bazaManager.SaveBaza(path, DicCars);

            }
        }
        public void DeleteCar()
        {
            Show();
            Console.WriteLine("Input the ID of car, you want to Delete: ");
            int id = int.Parse(Console.ReadLine());
            if (DicCars.ContainsKey(id))
            {
                DicCars.Remove(id);
                bazaManager.CleanBazaFile(path);
               
                bazaManager.ReadBaza(path);
            }
            else
            {
                Console.WriteLine("ID Not Present");
                return;
            }
        }
        public void Show()
        {
            foreach (KeyValuePair<int, Car> item in DicCars)
            {
                if (item.Value is Sedan)
                {
                    Sedan obj = (Sedan)item.Value;
                    Console.WriteLine($"  ID: {item.Key}, Mark: {obj.Mark}, Model: {obj.Model},  Number of seets: {obj.NumberSets}");
                }
                if (item.Value is Track)
                {
                    Track obj = (Track)item.Value;
                    Console.WriteLine($"  ID: {item.Key}, Mark: {obj.Mark}, Model: {obj.Model},  Capacity: {obj.Capacity}");
                }
            }
        } 
    }
}
