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
    public class TemplateController : ControllerBase
    {
        [NonAction]
        public TemplateUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB();
            TemplateRepository repository = new TemplateRepository(db);
            TemplateUseCase service = new TemplateUseCase(repository);

            return service;
        }
        [HttpGet]
        [Route("get_all")]
        public ActionResult<IEnumerable<Template>> Get()
        {
            TemplateUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        [HttpGet]
        [Route("get_by_id/{id}")]
        public ActionResult<Template> Get(Guid id)
        {
            TemplateUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<Template> Post([FromBody] Template template)
        {
            TemplateUseCase service = CreateService();

            var result = service.Create(template);

            return Ok(result);
        }

        [HttpPut]
        [Route("update/{id}")]
        public ActionResult Put(Guid id, [FromBody] Template template)
        {
            TemplateUseCase service = CreateService();
            template.template_id = id;
            service.Update(template);

            return Ok("Editado exitosamente");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            TemplateUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
