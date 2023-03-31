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
    public class GroupController : ControllerBase
    {
        [NonAction]
        public GroupUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            GroupRepository repository = new GroupRepository(db);
            GroupUseCase service = new GroupUseCase(repository);

            return service;
        }

        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<Group>> Get()
        {
            GroupUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<Group> Get(Guid id)
        {
            GroupUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Group> Post([FromBody] Group group)
        {
            GroupUseCase service = CreateService();

            var result = service.Create(group);

            return Ok(result);
        }


        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] Group group)
        {
            GroupUseCase service = CreateService();
            group.group_id = id;
            service.Update(group);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            GroupUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
