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
    public class AnswerController : ControllerBase
    {
 
        [NonAction]
        public AnswerUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            AnswerRepository repository = new AnswerRepository(db);
            AnswerUseCase service = new AnswerUseCase(repository);

            return service;
        }
        
        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<Answer>> Get()
        {
            AnswerUseCase service = CreateService();
            return Ok(service.GetAll());
        }


        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<Answer> Get(Guid id)
        {
            AnswerUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        
        [HttpPost]
        [Route("create")]
        public ActionResult<Answer> Post([FromBody] Answer answer)
        {
            AnswerUseCase service = CreateService();

            var result = service.Create(answer);

            return Ok(result);
        }

        
        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] Answer answer)
        {
            AnswerUseCase service = CreateService();
            answer.answer_id = id;
            service.Update(answer);

            return Ok("Editado exitosamente");
        }

        
        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            AnswerUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
