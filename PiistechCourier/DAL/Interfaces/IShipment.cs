using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IShipment<TClass>
    {
        TClass Create(TClass obj);

        List<TClass> Read();

        TClass Read(string id);

        TClass Update(TClass obj);

        bool Delete(string id);


    }
}
