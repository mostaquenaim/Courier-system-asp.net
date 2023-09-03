﻿using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ShipperRepo : Repo, IRepo<Shipper>
    {
        public Shipper Create(Shipper obj)
        {
            db.Shippers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Shippers.Remove(ex);
            return db.SaveChanges() > 0;

        }

        public List<Shipper> Read()
        {
            return db.Shippers.ToList();
        }

        public Shipper Read(int id)
        {
            return db.Shippers.Find(id);
        }

        public Shipper Update(Shipper obj)
        {
            var ex = Read(obj.ID);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;

        }

    }
}
