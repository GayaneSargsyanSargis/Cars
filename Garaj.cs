using System;
using Cars.Enums;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
   
    public class Garaj:Ishowable
    {
        Market market = new Market();
        public static Dictionary<int, Car> DicCars = new Dictionary<int, Car>();
        private IBazaSaverReaderCloser bazaManager = new BazaManagerJson();       
        public static string path = @"D:\C#HW\Cars\GarajBaza.txt";

        public Garaj()
        {

        }
        public void Buy()
        {
            
            market.Show();
            Console.WriteLine("Input the ID of car, you want to buy: ");
            int id1 = int.Parse(Console.ReadLine());
            Car car;
            int ID = 0;
            if (DicCars.Count>0)
            {
                ID = DicCars.Last().Key;
            }
            if (Market.DicCars.ContainsKey(id1))
            {
                car = Market.DicCars[id1];
                DicCars.Add(ID + 1, car);
                Market.DicCars.Remove(id1);
                bazaManager.CleanBazaFile(Market.path);
                bazaManager.SaveBaza(Market.path, Market.DicCars);
                bazaManager.CleanBazaFile(path);
                bazaManager.SaveBaza(path, DicCars);
                             
            }
            else
            {
                Console.WriteLine("ID Not Present");
                return;
            }
        }

        public void Show()
        {
            Console.Clear();
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
