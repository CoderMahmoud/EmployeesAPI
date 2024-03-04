using EmployeesAPI.Data.DbContexts;
using EmployeesAPI.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmployeesAPI.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext;
        protected ILogger<GenericRepository<T>> _logger;
        public GenericRepository(ILogger<GenericRepository<T>> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<bool> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var isAdded = false;

            try
            {
                await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
                isAdded = await _dbContext.SaveChangesAsync(cancellationToken) > 0;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }
            return isAdded;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var isDeleted = false;

            try
            {
                var existingEntity = await _dbContext.Set<T>().FindAsync(id, cancellationToken);

                if (existingEntity is not null)
                {
                    _dbContext.Set<T>().Remove(existingEntity);
                    isDeleted = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }

            return isDeleted;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FindAsync(id, cancellationToken);
        }

        public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            var isUpdated = false;

            try
            {
                _dbContext.Set<T>().Update(entity);
                isUpdated = await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw;
            }

            return isUpdated;

        }
    }
}
