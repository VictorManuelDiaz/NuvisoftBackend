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
    public class JobController : ControllerBase
    {
        [NonAction]
        public JobUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            JobRepository repository = new JobRepository(db);
            JobUseCase service = new JobUseCase(repository);

            return service;
        }

        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<Job>> Get()
        {
            JobUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<Job> Get(Guid id)
        {
            JobUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Job> Post([FromBody] Job job)
        {
            JobUseCase service = CreateService();

            var result = service.Create(job);

            return Ok(result);
        }


        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] Job job)
        {
            JobUseCase service = CreateService();
            job.job_id = id;
            service.Update(job);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            JobUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
