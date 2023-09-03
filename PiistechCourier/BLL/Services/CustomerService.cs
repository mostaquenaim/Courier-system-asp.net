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
    public class CustomerService
    {
        public static List<CustomerDTO> Get()
        {
            //get all Customers
            var data = DataAccessFactory.CustomerData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<CustomerDTO>>(data);
            return mapped;
        }

        //get with id
        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Customer, CustomerDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<CustomerDTO>(data);
            return mapped;
        }

        //delete Customer
        public static bool DeleteCustomer(int id)
        {
            var res = DataAccessFactory.CustomerData().Delete(id);
            return res;
        }

        //create customer
        public static CustomerDTO Create(CustomerDTO dto)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDTO, Customer>());

            var mapper = new Mapper(config);

            var dbObj = mapper.Map<Customer>(dto);

            var ret = DataAccessFactory.CustomerData().Create(dbObj);

            return Get(ret.Id);

        }
    }
}
