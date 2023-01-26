using Microsoft.AspNetCore.Mvc;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Contexts;
using NuvisoftBackend.Core.Application.UseCases;
using NuvisoftBackend.Core.Domain.Models;
using NuvisoftBackend.Core.Infraestructure.Repository.Concrete;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NuvisoftBackend.Ports.API.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private string ConnectionString;
        public QuestionController(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("SqlServer");
        }
        [NonAction]
        public QuestionUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB(ConnectionString);
            QuestionRepository repository = new QuestionRepository(db);
            QuestionUseCase service = new QuestionUseCase(repository);

            return service;
        }

        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<Question>> Get()
        {
            QuestionUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<Question> Get(Guid id)
        {
            QuestionUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Question> Post([FromBody] Question question)
        {
            QuestionUseCase service = CreateService();

            var result = service.Create(question);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] Question question)
        {
            QuestionUseCase service = CreateService();
            question.question_id = id;
            service.Update(question);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            QuestionUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
