using System.Linq.Expressions;

namespace MongoDBRepository.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        Task InsertOneAsync(T document);
        Task<T> FindByIdAsync(Guid id);
        Task<T> FindAsync(Expression<Func<T, bool>> filterExpression);
        Task ReplaceOneAsync(T document);
    }
}
