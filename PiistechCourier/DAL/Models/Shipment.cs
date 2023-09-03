using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Shipment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Shipper")]
        public int ShipperId { get; set; }
        public virtual Shipper Shipper { get; set; }

        [Required, ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required, ForeignKey("Receiver")]
        public int ReceiverId { get; set; }
        public virtual Receiver Receiver { get; set; }

        [Required]
        public string Destination { get; set; }

        public string From { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime EstimatedDeliveryTime { get; set; }

        [Required]
        public string TrackingToken { get; set; }

        [Required, ForeignKey("Status")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }


    }
}
