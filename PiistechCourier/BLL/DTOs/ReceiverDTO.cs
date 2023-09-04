﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReceiverDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        
        public string Address { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }
    }
}
