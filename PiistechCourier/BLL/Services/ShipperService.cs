using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ShipperService
    {
        public static List<ShipperDTO> Get()
        {
            //get all Shippers
            var data = DataAccessFactory.ShipperData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Shipper, ShipperDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ShipperDTO>>(data);
            return mapped;
        }

        //get with id
        public static ShipperDTO Get(int id)
        {
            var data = DataAccessFactory.ShipperData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Shipper, ShipperDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ShipperDTO>(data);
            return mapped;
        }

        //delete Shipper
        public static bool DeleteShipper(int id)
        {
            var res = DataAccessFactory.ShipperData().Delete(id);
            return res;
        }
    }
}
