using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CourierContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Receiver> Receivers { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Status> Statuses { get; set; }

        public DbSet<Token> Tokens { get; set; }

    }
}
