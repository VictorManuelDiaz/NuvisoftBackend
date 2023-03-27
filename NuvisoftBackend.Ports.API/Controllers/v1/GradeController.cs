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
    public class GradeController : ControllerBase
    {
        [NonAction]
        public GradeUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            GradeRepository repository = new GradeRepository(db);
            GradeUseCase service = new GradeUseCase(repository);

            return service;
        }

        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<Grade>> Get()
        {
            GradeUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<Grade> Get(Guid id)
        {
            GradeUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Grade> Post([FromBody] Grade grade)
        {
            GradeUseCase service = CreateService();

            var result = service.Create(grade);

            return Ok(result);
        }


        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] Grade grade)
        {
            GradeUseCase service = CreateService();
            grade.grade_id = id;
            service.Update(grade);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            GradeUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
