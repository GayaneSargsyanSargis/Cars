using System;
using Cars.Enums;
using System.Collections.Generic;

namespace Cars
{
    public abstract class Car: ICloneable, IComparable
    {
        public static Dictionary<CarType, Dictionary<Marka, List<Models>>> DicChoose = new Dictionary<CarType, Dictionary<Marka, List<Models>>>()
        {
             {
                 CarType.Sedan, new Dictionary<Marka, List<Models>>()
                 {
                     {
                         Marka.Mersedes, new List<Models>()
                         {
                             Models.AClass,
                             Models.EClass,
                             Models.VClass
                         }
                     },

                     {
                         Marka.Kia, new List<Models>()
                         {
                             Models.Forte,
                             Models.Sorento
                         }
                     },
                     {
                         Marka.Opel, new List<Models>()
                         {
                             Models.Astra,
                             Models.Zafira
                         }
                     }
                 }
             },

             {
                  CarType.Track, new Dictionary<Marka, List<Models>>()
                  {
                      {
                          Marka.Renualt, new List<Models>()
                          {
                              Models.D,
                              Models.K
                          }
                      },

                      {
                          Marka.Kamaz, new List<Models>()
                          {
                              Models.KB,
                              Models.KD
                          }
                      },

                  }
             }

        };
        public Marka Mark { get; set; }
        public Models Model { get; set; }      
       
        public Car(Marka Mark, Models Model)
        {
            this.Mark = Mark;
            this.Model = Model;                    
        }
        public abstract object Clone();
        public abstract int CompareTo(object obj);
       
    }
}
