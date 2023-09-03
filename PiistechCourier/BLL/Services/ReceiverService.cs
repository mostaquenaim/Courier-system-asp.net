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
    public class ReceiverService
    {
        public static List<ReceiverDTO> Get()
        {
            //get all Receivers
            var data = DataAccessFactory.ReceiverData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Receiver, ReceiverDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ReceiverDTO>>(data);
            return mapped;
        }

        //get with id
        public static ReceiverDTO Get(int id)
        {
            var data = DataAccessFactory.ReceiverData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Receiver, ReceiverDTO>();
            }
            );
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ReceiverDTO>(data);
            return mapped;
        }

        //delete Receiver
        public static bool DeleteReceiver(int id)
        {
            var res = DataAccessFactory.ReceiverData().Delete(id);
            return res;
        }

        //create Receiver
        public static ReceiverDTO Create(ReceiverDTO dto)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReceiverDTO, Receiver>());

            var mapper = new Mapper(config);

            var dbObj = mapper.Map<Receiver>(dto);

            var ret = DataAccessFactory.ReceiverData().Create(dbObj);

            return Get(ret.Id);

        }
    }
}
