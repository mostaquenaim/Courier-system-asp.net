using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Admin> AdminData()
        {
            return new AdminRepo();
        }
        public static IRepo<Customer> CustomerData()
        {
            return new CustomerRepo();
        }
        public static IRepo<Status> StatusData()
        {
            return new StatusRepo();
        }
        public static IRepo<Shipper> ShipperData()
        {
            return new ShipperRepo();
        }
        public static IRepo<Receiver> ReceiverData()
        {
            return new ReceiverRepo();
        }
        public static IShipment<Shipment> ShipmentData()
        {
            return new ShipmentRepo();
        }

        public static IAuth<Admin> AuthData()
        {
            return new AdminRepo();
        }

        public static IToken<Token> TokenData()
        {
            return new TokenRepo();
        }
    }
}
