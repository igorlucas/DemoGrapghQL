using Domain.Entities;
using Infra.Contexts;
using Infra.IRepositories;
using System;
using System.Linq;
using System.Text;

namespace Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _db;

        public UserRepository(DataContext db) => _db = db;

        public string Authenticate(string email, string password)
        {
            //var user = _db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            var user = _db.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            return user != null ? GetBasicToken(user) : null;
        }

        public User Find(string email, string password)
            => _db.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            //_db.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

        public string GetBasicToken(User user)
        {
            byte[] encodedBytes = Encoding.Unicode.GetBytes($"{user.Email}:{user.Password}");
            return Convert.ToBase64String(encodedBytes);
        }

        public bool CheckToken(string token)
        {
            byte[] textAsBytes = Convert.FromBase64String(token);
            var payload = Encoding.Unicode.GetString(textAsBytes).Split(":");
            var checktoken = Authenticate(payload[0], payload[1]);
            return token == checktoken;
        }

        public User Create(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
            return user;
        }
    }
}
