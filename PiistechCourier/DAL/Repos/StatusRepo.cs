using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class StatusRepo : Repo, IRepo<Status>
    {
        public Status Create(Status obj)
        {
            db.Statuses.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Statuses.Remove(ex);
            return db.SaveChanges() > 0;

        }

        public List<Status> Read()
        {
            return db.Statuses.ToList();
        }

        public Status Read(int id)
        {
            return db.Statuses.Find(id);
        }

        public Status Update(Status obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;

        }

    }
}
