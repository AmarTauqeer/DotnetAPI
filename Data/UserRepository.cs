using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetAPI.Data;
using DotnetAPI.Models;

namespace DotnetAPI.Data
{
    public class UserRepository:IUserRepository
    {
        DataContextEF _entityFramework;

        public UserRepository(IConfiguration config)
        {
            _entityFramework = new DataContextEF(config);

        }
        public bool SaveChanges()
        {
            return _entityFramework.SaveChanges() > 0;
        }
        public void AddEntity<T>(T entityToAdd)
        {
            if (entityToAdd != null)
            {
                _entityFramework.Add(entityToAdd);
            }

        }
        public void RemoveEntity<T>(T entityToRemove)
        {
            if (entityToRemove != null)
            {
                _entityFramework.Remove(entityToRemove);
            }

        }
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = _entityFramework.Users.ToList<User>();
            return users;
        }
        public User GetSingleUser(int userId)
        {
            User? user = _entityFramework.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            throw new Exception("Faild to Get User.");
        }
    }
}