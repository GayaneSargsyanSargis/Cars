using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public interface IBazaSaverReaderCloser
    {
        void SaveBaza(string path, Dictionary<int, Car> DicCars); 
        void ReadBaza(string path);
        void CleanBazaFile(string path);

    }
}
