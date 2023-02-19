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
    public class SchoolController : ControllerBase
    {
        [NonAction]
        public SchoolUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            SchoolRepository repository = new SchoolRepository(db);
            SchoolUseCase service = new SchoolUseCase(repository);

            return service;
        }

        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<School>> Get()
        {
            SchoolUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<School> Get(Guid id)
        {
            SchoolUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<School> Post([FromBody] School school)
        {
            SchoolUseCase service = CreateService();

            var result = service.Create(school);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] School school)
        {
            SchoolUseCase service = CreateService();
            school.school_id = id;
            service.Update(school);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            SchoolUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
