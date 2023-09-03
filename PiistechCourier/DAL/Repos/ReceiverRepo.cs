using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReceiverRepo : Repo, IRepo<Receiver>
    {
        public Receiver Create(Receiver obj)
        {
            db.Receivers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Receivers.Remove(ex);
            return db.SaveChanges() > 0;

        }

        public List<Receiver> Read()
        {
            return db.Receivers.ToList();
        }

        public Receiver Read(int id)
        {
            return db.Receivers.Find(id);
        }

        public Receiver Update(Receiver obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;

        }

    }
}
