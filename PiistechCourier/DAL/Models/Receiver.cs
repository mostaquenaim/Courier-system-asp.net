using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Receiver
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        public string Email { get; set; }

        public List<Shipment> shipments { get; set; }

        public Receiver()
        {
            shipments = new List<Shipment>();
        }

    }
}
