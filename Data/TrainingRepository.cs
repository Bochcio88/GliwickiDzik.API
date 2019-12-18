using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GliwickiDzik.API.Models;
using GliwickiDzik.Data;
using Microsoft.EntityFrameworkCore;

namespace GliwickiDzik.API.Data
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly DataContext _context;

        public TrainingRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(TrainingPlanModel entity)
        {
            _context.TrainingPlanModel.Add(entity);
        }

        public void Add(TrainingModel entity)
        {
            _context.TrainingModel.Add(entity);
        }

        public void Add(ExerciseForTrainingModel entity)
        {
            _context.ExerciseForTrainingModel.Add(entity);
        }

        public void AddRange(IEnumerable<TrainingPlanModel> entities)
        {
            _context.TrainingPlanModel.AddRange(entities);
        }

        public void AddRange(IEnumerable<TrainingModel> entities)
        {
            _context.TrainingModel.AddRange(entities);
        }

        public void AddRange(IEnumerable<ExerciseForTrainingModel> entities)
        {
            _context.ExerciseForTrainingModel.AddRange(entities);
        }

        public Task<IEnumerable<TrainingPlanModel>> FindAsync(Expression<Func<TrainingPlanModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrainingModel>> FindAsync(Expression<Func<TrainingModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ExerciseForTrainingModel>> FindAsync(Expression<Func<ExerciseForTrainingModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TrainingPlanModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TrainingPlanModel> GetByIdAsync(int id)
        {
            return await _context.TrainingPlanModel.FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Remove(TrainingPlanModel entity)
        {
            _context.TrainingPlanModel.Remove(entity);
        }

        public void Remove(TrainingModel entity)
        {
            _context.TrainingModel.Remove(entity);
        }

        public void Remove(ExerciseForTrainingModel entity)
        {
             _context.ExerciseForTrainingModel.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TrainingPlanModel> entities)
        {
             _context.TrainingPlanModel.RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<TrainingModel> entities)
        {
            _context.TrainingModel.RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<ExerciseForTrainingModel> entities)
        {
            _context.ExerciseForTrainingModel.RemoveRange(entities);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        Task<IEnumerable<TrainingModel>> IGenericRepository<TrainingModel>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ExerciseForTrainingModel>> IGenericRepository<ExerciseForTrainingModel>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<TrainingModel> IGenericRepository<TrainingModel>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ExerciseForTrainingModel> IGenericRepository<ExerciseForTrainingModel>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}