using System;
using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private CodenationContext _context;

        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _context.Candidates
                .Where(c => c.Acceleration.Name == name)
                .Select(c => c.User)
                .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _context.Candidates
               .Where(c => c.CompanyId == companyId)
               .Select(c => c.User)
               .Distinct()
               .ToList();
        }

        public User FindById(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }

        public User Save(User user)
        {
            if (user.Id == 0)
                _context.Users.Add(user);
            else
                _context.Users.Update(user);
                _context.SaveChanges();

            return user;
        }
    }
}
