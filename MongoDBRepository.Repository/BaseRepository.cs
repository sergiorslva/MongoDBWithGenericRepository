using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBRepository.Domain.Entities;
using MongoDBRepository.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace MongoDBRepository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;
        public BaseRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<T>(typeof(T).Name);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await _collection.Find(filterExpression).FirstOrDefaultAsync();            
        }

        public async Task<T> FindByIdAsync(Guid id)
        {            
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(doc => doc.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task InsertOneAsync(T document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task ReplaceOneAsync(T document)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.ReplaceOneAsync(filter, document);
        }
    }
}
