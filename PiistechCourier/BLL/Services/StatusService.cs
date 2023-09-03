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
    public class StatusService
    {

        //get all status
       public static List<StatusDTO> Get()
        {
            var data = DataAccessFactory.StatusData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Status, StatusDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<StatusDTO>>(data);
            return mapped;
        }

        //get status with id
        public static StatusDTO Get(int id)
        {
            var data = DataAccessFactory.StatusData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Status, StatusDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<StatusDTO>(data);
            return mapped;
        }

        //delete status
        public static bool DeleteStatus(int id)
        {
            var res = DataAccessFactory.StatusData().Delete(id);
            return res;
        }
    }
}
