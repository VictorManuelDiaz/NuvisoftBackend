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
    public class SubjectScheduleController : ControllerBase
    {
        [NonAction]
        public SubjectScheduleUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            SubjectScheduleRepository repository = new SubjectScheduleRepository(db);
            SubjectScheduleUseCase service = new SubjectScheduleUseCase(repository);

            return service;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<SubjectSchedule> Post([FromBody] SubjectSchedule subjectSchedule)
        {
            SubjectScheduleUseCase service = CreateService();

            var result = service.Create(subjectSchedule);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] SubjectSchedule subjectSchedule)
        {
            SubjectScheduleUseCase service = CreateService();
            subjectSchedule.subject_schedule_id = id;
            service.Update(subjectSchedule);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            SubjectScheduleUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
