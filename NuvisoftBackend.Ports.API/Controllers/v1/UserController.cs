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
    public class UserController : ControllerBase
    {
        [NonAction]
        public UserUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            UserRepository repository = new UserRepository(db);
            UserUseCase service = new UserUseCase(repository);

            return service;
        }

        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<User>> Get()
        {
            UserUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<User> Get(Guid id)
        {
            UserUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<User> Post([FromBody] User user)
        {
            UserUseCase service = CreateService();

            var result = service.Create(user);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] User user)
        {
            UserUseCase service = CreateService();
            user.user_id = id;
            service.Update(user);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            UserUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
