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
    public class GroupStudentController : ControllerBase
    {
        [NonAction]
        public GroupStudentUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            GroupStudentRepository repository = new GroupStudentRepository(db);
            GroupStudentUseCase service = new GroupStudentUseCase(repository);

            return service;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<GroupStudent> Post([FromBody] GroupStudent groupStudent)
        {
            GroupStudentUseCase service = CreateService();

            var result = service.Create(groupStudent);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] GroupStudent groupStudent)
        {
            GroupStudentUseCase service = CreateService();
            groupStudent.group_student_id = id;
            service.Update(groupStudent);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            GroupStudentUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
