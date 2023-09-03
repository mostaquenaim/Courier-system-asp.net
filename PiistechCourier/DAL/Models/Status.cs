using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Shipment> shipments { get; set; }

        public Status()
        {
            shipments = new List<Shipment>();
        }
    }
}
