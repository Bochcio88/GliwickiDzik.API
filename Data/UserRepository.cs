using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GliwickiDzik.Data;
using GliwickiDzik.Models;
using Microsoft.EntityFrameworkCore;

namespace GliwickiDzik.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(UserModel entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<UserModel> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> FindAsync(Expression<Func<UserModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserModel>> GetUsersForRecords()
        {
            return await _context.UserModel.OrderByDescending(u => u.BicepsSize).ToListAsync();
        }
        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public void Remove(UserModel entity)
        {
            _context.UserModel.Remove(entity);
        }

        public void RemoveRange(IEnumerable<UserModel> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}