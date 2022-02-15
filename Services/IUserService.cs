using Domain;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        public string Authenticate(CredentialsDTO credentials);
        public User GetUser(int id);
        public IQueryable<User> GetAllUsers();
        public void AddUser(UserDTO userDTO);
        public void DeleteUser(int id);
        public void UpdateUser(int id, UserDTO userDTO);
    }
}
