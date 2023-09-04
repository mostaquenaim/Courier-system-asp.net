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
    public class ShipmentService
    {
        public static List<ShipmentDTO> Get()
        {
            //get all Shipments
            var data = DataAccessFactory.ShipmentData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Shipment, ShipmentDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ShipmentDTO>>(data);
            return mapped;
        }

        //get with tracking id
        public static ShipmentDTO Get(string id)
        {
            var data = DataAccessFactory.ShipmentData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Shipment, ShipmentDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ShipmentDTO>(data);
            return mapped;
        }

        //delete Shipment
        public static bool DeleteShipment(string id)
        {
            var res = DataAccessFactory.ShipmentData().Delete(id);
            return res;
        }

        //add shipment
        public static ShipmentDTO Create(ShipmentDTO dto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShipmentDTO, Shipment>());

            var mapper = new Mapper(config);

            var dbObj = mapper.Map<Shipment>(dto);

            var ret = DataAccessFactory.ShipmentData().Create(dbObj);

            return Get(ret.TrackingToken);

        }

        //update shipment
        public static ShipmentDTO Update(ShipmentDTO dto)
        {
            var existingShipment = DataAccessFactory.ShipmentData().Read(dto.TrackingToken);

            if (existingShipment == null)
            {
                throw new Exception("Shipment not found");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ShipmentDTO, Shipment>());
            var mapper = new Mapper(config);
            mapper.Map(dto, existingShipment);
           // mapper.Map<ShipmentDTO>(existingShipment);
            var updatedShipment = DataAccessFactory.ShipmentData().Update(existingShipment);

            return Get(updatedShipment.TrackingToken); ;
        }

    }
}
