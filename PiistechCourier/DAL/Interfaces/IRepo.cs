using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepo<TClass>
    {
        TClass Create(TClass obj);

        List<TClass> Read();

        TClass Read(int id);

        TClass Update(TClass obj);

        bool Delete(int id);
    }
}
