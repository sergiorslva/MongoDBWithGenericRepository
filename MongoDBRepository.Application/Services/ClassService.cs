using MongoDBRepository.Domain.Entities;
using MongoDBRepository.Domain.Interfaces.Repositories;

namespace MongoDBRepository.Application.Services
{
    public class ClassService : BaseService<Class>, IClassService
    {
        public ClassService(IBaseRepository<Class> baseRepository) : base(baseRepository)
        {
        }
    }
}
