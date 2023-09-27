using Microsoft.AspNetCore.Mvc;
using MongoDBRepository.Domain.Entities;
using MongoDBRepository.Domain.Interfaces.Repositories;

namespace MongoDBRepository.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {      

        private readonly ILogger<ClassController> _logger;
        private readonly IClassService _classService;

        public ClassController(ILogger<ClassController> logger, IClassService classService)
        {
            _logger = logger;
            this._classService = classService;
        }

        [HttpPost]
        public void Post([FromBody] Class classModel)
        {
            _classService.InsertOneAsync(classModel);
        }
    }
}