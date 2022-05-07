using System;
using Cars.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Track:Car
    {
        public int Capacity { get; set; }
        public Track(Marka Mark, Models Model, int Capacity):base(Mark, Model)
        {
            this.Capacity = Capacity;
        }

        public override object Clone()
        {           
            return new Track(this.Mark, this.Model, this.Capacity);
        }
        public override int CompareTo(object obj)
        {
            Track car = obj as Track;
            int result = 1;
            if (car!=null)
            {               
                result = car.Mark.ToString().CompareTo(this.Mark.ToString());
                if (result==0)
                {
                    result = car.Mark.ToString().CompareTo(this.Mark.ToString());
                    if (result==0)
                    {
                        result = car.Capacity.CompareTo(this.Capacity);
                        return result;
                    }
                }
            }
            return result;
        }
        
    }
}
