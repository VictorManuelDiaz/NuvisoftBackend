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
    public class PrivilegeSubjectController : ControllerBase
    {
        [NonAction]
        public PrivilegeSubjectUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            PrivilegeSubjectRepository repository = new PrivilegeSubjectRepository(db);
            PrivilegeSubjectUseCase service = new PrivilegeSubjectUseCase(repository);

            return service;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<PrivilegeSubject> Post([FromBody] PrivilegeSubject privilegeSubject)
        {
            PrivilegeSubjectUseCase service = CreateService();

            var result = service.Create(privilegeSubject);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] PrivilegeSubject privilegeSubject)
        {
            PrivilegeSubjectUseCase service = CreateService();
            privilegeSubject.privilege_subject_id = id;
            service.Update(privilegeSubject);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            PrivilegeSubjectUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
