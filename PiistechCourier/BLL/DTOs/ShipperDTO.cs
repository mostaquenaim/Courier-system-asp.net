﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ShipperDTO
    {
        public int ID { get; set; }

       
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
