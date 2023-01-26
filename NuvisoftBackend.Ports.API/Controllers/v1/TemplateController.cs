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
        private string ConnectionString;
        public TemplateController(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("SqlServer");
        }
        [NonAction]
        public TemplateUseCase CreateService()
        {
            NuvisoftDB db = new NuvisoftDB(ConnectionString);
            TemplateRepository repository = new TemplateRepository(db);
            TemplateUseCase service = new TemplateUseCase(repository);

            return service;
        }
        // GET: api/<TemplateController>
        [HttpGet]
        public ActionResult<IEnumerable<Template>> Get()
        {
            TemplateUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<TemplateController>/5
        [HttpGet("{id}")]
        public ActionResult<Template> Get(Guid id)
        {
            TemplateUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<TemplateController>
        [HttpPost]
        public ActionResult<Template> Post([FromBody] Template template)
        {
            TemplateUseCase service = CreateService();

            var result = service.Create(template);

            return Ok(result);
        }

        // PUT api/<TemplateController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Template template)
        {
            TemplateUseCase service = CreateService();
            template.template_id = id;
            service.Update(template);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<TemplateController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            TemplateUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
