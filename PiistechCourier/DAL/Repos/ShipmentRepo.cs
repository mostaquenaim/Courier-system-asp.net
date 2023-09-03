using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ShipmentRepo : Repo, IShipment<Shipment>
    {
        public Shipment Create(Shipment obj)
        {
            db.Shipments.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Shipments.Remove(ex);
            return db.SaveChanges() > 0;

        }

        public List<Shipment> Read()
        {
            return db.Shipments.ToList();
        }

        public Shipment Read(string id)
        {
            return db.Shipments.FirstOrDefault(s => s.TrackingToken == id);
        }

        public Shipment Update(Shipment obj)
        {
            var ex = Read(obj.TrackingToken);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;

        }

    }
}
