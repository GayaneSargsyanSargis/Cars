using System;
using System.IO;
using Cars.Enums;
using System.Collections.Generic;
using System.Text;


namespace Cars
{
    public class BazaManager : IBazaSaverReaderCloser
    {
        public void ReadBaza(string path)
        {
            FileStream file = new FileStream(@path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            while (file.Position < file.Length)
            {
                int key = file.ReadByte();
                Console.WriteLine(key);
                int CarType = file.ReadByte();

                if (CarType == 1)//Track
                {
                    int count = file.ReadByte();
                    byte[] buffer = new byte[count];
                    file.Read(buffer, 0, buffer.Length);
                    string TrackMark = Encoding.Default.GetString(buffer);
                    Enum.TryParse(TrackMark, out Marka marka);

                    int count1 = file.ReadByte();
                    byte[] buffer1 = new byte[count1];
                    file.Read(buffer1, 0, buffer1.Length);
                    string TrackModel = Encoding.Default.GetString(buffer1);
                    Enum.TryParse(TrackModel, out Models model);
                    int Capacity = file.ReadByte();

                    if (path == @"D:\C#HW\Cars\MarketBaza.txt")
                    {
                        Track track = new Track(marka, model, Capacity);
                        Market.DicCars.Add(key, track);

                    }
                    else if (path == @"D:\C#HW\Cars\GarajBaza.txt")
                    {
                        Track track = new Track(marka, model, Capacity);
                        if (!Garaj.DicCars.ContainsKey(key))
                        {
                            Garaj.DicCars.Add(key, track);
                        }
                    }
                }
                else if (CarType == 2)//Sedan
                {
                    int count = file.ReadByte();
                    byte[] buffer = new byte[count];
                    file.Read(buffer, 0, buffer.Length);
                    string SedanMark = Encoding.Default.GetString(buffer);
                    Enum.TryParse(SedanMark, out Marka marka);

                    int count1 = file.ReadByte();
                    byte[] buffer1 = new byte[count1];
                    file.Read(buffer1, 0, buffer1.Length);
                    string SedanModel = Encoding.Default.GetString(buffer1);
                    Enum.TryParse(SedanModel, out Models model);

                    int numberSets = file.ReadByte();

                    if (path == Market.path)
                    {
                        Sedan track = new Sedan(marka, model, numberSets);
                        Market.DicCars.Add(key, track);
                    }

                    else if (path == Garaj.path)
                    {
                        Sedan track = new Sedan(marka, model, numberSets);
                        Garaj.DicCars.Add(key, track);
                    }
                }
            }
            file.Close();
        }

        public void SaveBaza(string path, Dictionary<int, Car> DicCars)
        {
            if (DicCars.Count > 0)
            {
                foreach (var item in DicCars)
                {
                    SaveBazaItem(path, DicCars, item.Key);
                }
            }
        }
        public void SaveBazaItem(string path, Dictionary<int, Car> DicCars, int key)
        {
            FileStream file = new FileStream(@path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            if (DicCars.Count > 0)
            {
                var value = DicCars[key];
                file.Position = file.Length;
                byte byteKey = Convert.ToByte(key);
                file.WriteByte(byteKey);

                if (value is Track)
                {
                    Track obj = (Track)value;
                    byte byteCarType = Convert.ToByte(1);
                    file.WriteByte(byteCarType);

                    string TrackMark = obj.Mark.ToString();
                    byte Count = Convert.ToByte(TrackMark.Length);
                    file.WriteByte(Count);
                    byte[] buffer1 = Encoding.Default.GetBytes(TrackMark);
                    file.Write(buffer1, 0, buffer1.Length);

                    string TrackModel = obj.Model.ToString();
                    Count = Convert.ToByte(TrackModel.Length);
                    file.WriteByte(Count);
                    byte[] buffer2 = Encoding.Default.GetBytes(TrackModel);
                    file.Write(buffer2, 0, buffer2.Length);

                    byte Capacity = Convert.ToByte(obj.Capacity);
                    file.WriteByte(Capacity);
                }
                else
                {
                    Sedan obj = (Sedan)value;
                    byte byteCarType = Convert.ToByte(2);
                    file.WriteByte(byteCarType);

                    string SedanMark = obj.Mark.ToString();
                    byte Count = Convert.ToByte(SedanMark.Length);
                    file.WriteByte(Count);
                    byte[] buffer1 = Encoding.Default.GetBytes(SedanMark);
                    file.Write(buffer1, 0, buffer1.Length);
                    string SedanModel = obj.Model.ToString();
                    Count = Convert.ToByte(SedanModel.Length);
                    file.WriteByte(Count);
                    byte[] buffer2 = Encoding.Default.GetBytes(SedanModel);
                    file.Write(buffer2, 0, buffer2.Length);

                    byte numberSets = Convert.ToByte(obj.NumberSets);
                    file.WriteByte(numberSets);
                }
            }
            file.Close();
        }

        public void CleanBazaFile(string path)
        {
            File.WriteAllText(path, string.Empty);
        }


    }
}
