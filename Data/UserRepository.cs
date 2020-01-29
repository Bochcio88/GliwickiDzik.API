using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GliwickiDzik.API.Helpers;
using GliwickiDzik.API.Models;
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

        #region = "USER"
        public void Add(UserModel entity)
        {
            _context.UserModel.Add(entity);
        }
        public void AddRange(IEnumerable<UserModel> entities)
        {
            throw new NotImplementedException();
        }
        public async Task<PagedList<UserModel>> GetAllUsersForRecords(UserParams userParams)
        {
            var users = _context.UserModel.OrderByDescending(u => u.BicepsSize);

            if(!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch(userParams.OrderBy)
                {
                    case "LastActive":
                        users = users.OrderByDescending(u => u.LastActive);
                        break;

                    case "LastCreated":
                        users = users.OrderByDescending(u => u.DateOfCreated);
                        break;
                        
                    default:
                        users = users.OrderByDescending(u => u.BicepsSize);
                        break;
                }
            }
            return await PagedList<UserModel>.CreateListAsync(users, userParams.PageSize, userParams.PageNumber);
        }
        public async Task<UserModel> GetOneUserAsync(int userId)
        {
            return await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == userId);
        }
        public void Remove(UserModel entity)
        {
            _context.UserModel.Remove(entity);
        }
        public void RemoveRange(IEnumerable<UserModel> entities)
        {
            throw new NotImplementedException();
        }
        
        #endregion


        #region = "LIKE"

        public void Add(LikeModel entity)
        {
            _context.LikeModel.Add(entity);
        }
        public void AddRange(IEnumerable<LikeModel> entities)
        {
            throw new NotImplementedException();
        }
        public async Task<LikeModel> GetLikeAsync(int userId, int trainingPlanId)
        {
            return await _context.LikeModel.FirstOrDefaultAsync(l => l.UserIdLikesPlanId == userId && l.PlanIdIsLikedByUserId == trainingPlanId);
        }
        public void Remove(LikeModel entity)
        {
            _context.LikeModel.Remove(entity);
        }
        public void RemoveRange(IEnumerable<LikeModel> entities)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> IsLikedAsync(int userId, int trainingPlanId)
        {
            var isLike = await _context.LikeModel.FirstOrDefaultAsync(u => u.UserIdLikesPlanId == userId && u.PlanIdIsLikedByUserId == trainingPlanId);
            
            if (isLike != null)
                return true;
            
            return false;
        }

        #endregion
        
        public async Task<bool> SaveAllUserContent()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<UserModel>> GetConvUsersAsync(int userId)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == userId);
            var convList = user.Conversation;
            
            var listOfUsers = new List<UserModel>();
            
            foreach (var item in convList)
            {
                var userToList = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == item);
                listOfUsers.Add(userToList);
            }
            
            return listOfUsers;
        }
    }
}