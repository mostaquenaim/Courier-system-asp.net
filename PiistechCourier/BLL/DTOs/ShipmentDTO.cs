using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShipmentDTO
    {
        public int Id { get; set; }

        public int ShipperId { get; set; }

        public int CustomerId { get; set; }

        public int ReceiverId { get; set; }

        [Required]
        public string Destination { get; set; }

        public string From { get; set; }

        public DateTime EstimatedDeliveryTime { get; set; }

        public int StatusId { get; set; }

        public string TrackingToken { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
