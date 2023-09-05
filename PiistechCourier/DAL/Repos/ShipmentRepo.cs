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

        public List<Shipment> ReadBySearch(string item, string value)
        {
            try
            {
                
                    IQueryable<Shipment> query = db.Shipments;

                    switch (item.ToLower())
                    {
                        case "trackingtoken":
                            query = query.Where(s => s.TrackingToken == value);
                            break;
                        case "statusname":
                            query = query.Where(s => s.Status.Name == value);
                            break;
                        case "customerid":
                            if (int.TryParse(value, out int customerIdValue))
                            {
                                query = query.Where(s => s.CustomerId == customerIdValue);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid integer format for 'customerid'");
                            }
                            break;
                        case "receiverid":
                            if (int.TryParse(value, out int receiverIdValue))
                            {
                                query = query.Where(s => s.ReceiverId == receiverIdValue);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid integer format for 'ReceiverId'");
                            }
                            break;
                        case "shipperid":
                            if (int.TryParse(value, out int shipperIdValue))
                            {
                                query = query.Where(s => s.ShipperId == shipperIdValue);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid integer format for 'ShipperId'");
                            }
                            break;
                        case "destination":
                            query = query.Where(s => s.Destination == value);
                            break;
                        case "from":
                            query = query.Where(s => s.From == value);
                            break;
                        case "estimateddeliverytime":
                            DateTime estimatedDeliveryTime;
                            if (DateTime.TryParse(value, out estimatedDeliveryTime))
                            {
                                query = query.Where(s => s.EstimatedDeliveryTime == estimatedDeliveryTime);
                            }
                            else
                            {
                                throw new ArgumentException("Invalid date format for 'estimateddeliverytime'");
                            }
                            break;
                        default:
                            throw new ArgumentException("Unknown search criteria: " + item);
                    }

                    List<Shipment> result = query.ToList();
                    return result;
                
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Some is wrong: " + ex); 
            }
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
