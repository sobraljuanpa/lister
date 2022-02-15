using DataAccess.IRepositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IRepository<User>
    {
        readonly ListerContext context;

        public UserRepository(ListerContext context)
        {
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return context.Users;
        }

        public User Get(int id)
        {
            return context.Users.Find(id);
        }

        public void Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Users.Remove(Get(id));
            context.SaveChanges();
        }

        public void Update(int id, User user)
        {
            // TODO => Revisar si aca puedo simplemente asignar a una var el get y anda igual
            Get(id).Email = user.Email;
            Get(id).Name = user.Name;
            Get(id).Password = user.Password;
            Get(id).IsEnabled = user.IsEnabled;
            context.SaveChanges();
        }
    }
}
