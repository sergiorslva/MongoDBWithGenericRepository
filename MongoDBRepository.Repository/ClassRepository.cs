using MongoDB.Driver;
using MongoDBRepository.Domain.Entities;
using MongoDBRepository.Domain.Interfaces.Repositories;

namespace MongoDBRepository.Repository
{
    public class ClassRepository : BaseRepository<Class>, IClassRepository
    {
        public ClassRepository(IMongoDatabase database) : base(database)
        {
        }
    }
}
