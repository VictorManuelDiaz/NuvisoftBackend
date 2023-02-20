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
    public class ScheduleController : ControllerBase
    {
        [NonAction]
        public ScheduleUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            ScheduleRepository repository = new ScheduleRepository(db);
            ScheduleUseCase service = new ScheduleUseCase(repository);

            return service;
        }

        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<Schedule>> Get()
        {
            ScheduleUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<Schedule> Get(Guid id)
        {
            ScheduleUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Schedule> Post([FromBody] Schedule schedule)
        {
            ScheduleUseCase service = CreateService();

            var result = service.Create(schedule);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] Schedule schedule)
        {
            ScheduleUseCase service = CreateService();
            schedule.schedule_id = id;
            service.Update(schedule);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            ScheduleUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
