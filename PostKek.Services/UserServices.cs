using AutoMapper;
using PostKek.Data;
using PostKek.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostKek.Services
{
    public class UserServices : Service
    {
        public void AddUser(string identityId, string name, string email)
        {
            using (this.Context)
            {
                User toCreate = new User();
                toCreate.IdentityId = identityId;
                toCreate.Name = name;
                toCreate.Email = email;
                toCreate.IsBanned = false;
                this.Context.Users.Add(toCreate);
                this.Context.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            using (this.Context)
            {
                User toFind = this.Context.Users.Find(id);
                if (toFind != null)
                {
                    return toFind;
                }
                else return null;
            }
        }
        public User GetUserByLongId(string id)
        {
            using (this.Context)
            {
                User toFind = this.Context.Users.FirstOrDefault(a => a.IdentityId == id);
                if (toFind != null)
                {
                    return toFind;
                }
                else return null;

            } 
        }

        public IndexViewModel GetUserVmByLongId(string id)
        {
            using (this.Context)
            {
                User toFind = this.Context.Users.FirstOrDefault(a => a.IdentityId == id);
                if (toFind != null)
                {
                    return Mapper.Map<User, IndexViewModel>(toFind);
                }
                else return null;

            }
        }

    }
}
