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
    public class PrivilegeController : ControllerBase
    {
        [NonAction]
        public PrivilegeUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            PrivilegeRepository repository = new PrivilegeRepository(db);
            PrivilegeUseCase service = new PrivilegeUseCase(repository);

            return service;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Privilege> Post([FromBody] Privilege privilege)
        {
            PrivilegeUseCase service = CreateService();

            var result = service.Create(privilege);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] Privilege privilege)
        {
            PrivilegeUseCase service = CreateService();
            privilege.privilege_id = id;
            service.Update(privilege);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            PrivilegeUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
