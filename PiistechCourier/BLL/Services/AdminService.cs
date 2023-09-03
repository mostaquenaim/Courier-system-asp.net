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
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {
            //get all admins
            var data = DataAccessFactory.AdminData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdminDTO>>(data);
            return mapped;
        }

        //get with id
        public static AdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdminDTO>(data);
            return mapped;
        }

        //delete Admin
        public static bool DeleteAdmin(int id)
        {
            var res = DataAccessFactory.AdminData().Delete(id);
            return res;
        }


    }
}
