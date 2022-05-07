using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Sedan : Car
    {
       
        public int NumberSets { get; set; }
        
        public Sedan(Enums.Marka Mark, Enums.Models Model, int NumberSets) : base(Mark, Model)
        {  
            this.NumberSets = NumberSets;                    
        }

        public override object Clone()
        {            
            return new Sedan( this.Mark, this.Model, this.NumberSets);
        }
        public override int CompareTo(object obj)
        {
            Sedan car = obj as Sedan;
            int result = 1;
            if (car != null)
            {
                result = car.Mark.ToString().CompareTo(this.Mark.ToString());
                if (result == 0)
                {
                    result = car.Mark.ToString().CompareTo(this.Mark.ToString());
                    if (result == 0)
                    {
                        result = car.NumberSets.CompareTo(this.NumberSets);
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
