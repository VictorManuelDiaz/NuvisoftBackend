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
    public class SubjectController : ControllerBase
    {
        [NonAction]
        public SubjectUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            SubjectRepository repository = new SubjectRepository(db);
            SubjectUseCase service = new SubjectUseCase(repository);

            return service;
        }

        // GET: api/<SubjectController>
        [HttpGet]
        public ActionResult<IEnumerable<Subject>> Get()
        {
            SubjectUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public ActionResult<Subject> Get(Guid id)
        {
            SubjectUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<SubjectController>
        [HttpPost]
        public ActionResult<Subject> Post([FromBody] Subject subject)
        {
            SubjectUseCase service = CreateService();

            var result = service.Create(subject);

            return Ok(result);
        }

        // PUT api/<SubjectController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Subject subject)
        {
            SubjectUseCase service = CreateService();
            subject.subject_id = id;
            service.Update(subject);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<SubjectController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            SubjectUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
