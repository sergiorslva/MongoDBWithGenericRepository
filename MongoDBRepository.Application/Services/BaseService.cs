using MongoDBRepository.Domain.Entities;
using MongoDBRepository.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace MongoDBRepository.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            this._baseRepository = baseRepository;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await _baseRepository.FindAsync(filterExpression);
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            return await _baseRepository.FindByIdAsync(id);
        }

        public async Task InsertOneAsync(T document)
        {
            await _baseRepository.InsertOneAsync(document);
        }

        public async Task ReplaceOneAsync(T document)
        {
            await _baseRepository.ReplaceOneAsync(document);
        }
    }
}
