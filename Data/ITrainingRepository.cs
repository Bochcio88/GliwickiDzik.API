using System.Collections.Generic;
using System.Threading.Tasks;
using GliwickiDzik.API.Helpers;
using GliwickiDzik.API.Models;

namespace GliwickiDzik.API.Data
{
    public interface ITrainingRepository : IGenericRepository<TrainingPlanModel>, IGenericRepository<TrainingModel>, IGenericRepository<ExerciseForTrainingModel>
    {
         Task<TrainingPlanModel> GetOneTrainingPlanAsync(int trainingPlanId);
         Task<PagedList<TrainingPlanModel>> GetAllTrainingPlansAsync(TrainingPlanParams trainingPlanParams);
         Task<PagedList<TrainingPlanModel>> GetAllTrainingPlansForUserAsync(int userId, TrainingPlanParams trainingPlanParams);
         Task<TrainingModel> GetOneTrainingAsync(int trainingId);
         Task<IEnumerable<TrainingModel>> GetAllTrainingsForTrainingPlanAsync(int trainingPlanId);
         Task<ExerciseForTrainingModel> GetOneExerciseAsync(int exerciseId);
         Task<IEnumerable<ExerciseForTrainingModel>> GetAllExercisesForTrainingAsync(int trainingId);
         Task<bool> SaveAllTrainingContent();
    }
}