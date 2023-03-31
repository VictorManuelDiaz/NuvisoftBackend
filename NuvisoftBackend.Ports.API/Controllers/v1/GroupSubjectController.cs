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
    public class GroupSubjectController : ControllerBase
    {
        [NonAction]
        public GroupSubjectUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            GroupSubjectRepository repository = new GroupSubjectRepository(db);
            GroupSubjectUseCase service = new GroupSubjectUseCase(repository);

            return service;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<GroupSubject> Post([FromBody] GroupSubject groupSubject)
        {
            GroupSubjectUseCase service = CreateService();

            var result = service.Create(groupSubject);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] GroupSubject groupSubject)
        {
            GroupSubjectUseCase service = CreateService();
            groupSubject.group_subject_id = id;
            service.Update(groupSubject);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            GroupSubjectUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
