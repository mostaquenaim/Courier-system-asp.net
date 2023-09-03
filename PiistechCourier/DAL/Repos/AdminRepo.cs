﻿using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<Admin>, IAuth<Admin>
    {
        public Admin Authenticate(string email, string password)
        {
            var data = db.Admins.FirstOrDefault(x => x.Email == email && x.Password == password);
            return data;
        }

        public Admin Create(Admin obj)
        {
            db.Admins.Add(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Admins.Remove(ex);
            return db.SaveChanges() > 0;

        }

        public List<Admin> Read()
        {
            return db.Admins.ToList();
        }

        public Admin Read(int id)
        {
            return db.Admins.Find(id);
        }

        public Admin Update(Admin obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;

        }

    }
}
