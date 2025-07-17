using TaskManagerApp.Models;
using TaskManagerApp.Repositories;

namespace TaskManagerApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;
        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        #region GetAll
        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            var tasks = await _repository.GetAllAsync();
            return tasks ?? Enumerable.Empty<TaskItem>();
        }
        #endregion

        #region GetById
        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            var task = await _repository.GetTaskByIdAsync(id);
            if (task == null || !task.IsActive)
            {
                return null;
            }
            return task;
        }
        #endregion

        #region Add
        public async Task<bool> AddAsync(TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                return false;

            task.Id = Guid.NewGuid();
            task.IsActive = true;
            await _repository.AddAsync(task);
            return true;
        }
        #endregion

        #region Update
        public async Task<bool> UpdateAsync(TaskItem task)
        {
            var existing = await _repository.GetTaskByIdAsync(task.Id);
            if (existing == null || !existing.IsActive)
                return false;

            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.IsCompleted = task.IsCompleted;
            existing.DueDate = task.DueDate;

            await _repository.UpdateAsync(existing);
            return true;
        }
        #endregion

        #region Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _repository.GetTaskByIdAsync(id);
            if (task == null || !task.IsActive)
                return false;

            task.IsActive = false;
            await _repository.UpdateAsync(task);
            return true;
        }
        #endregion
    }
}
