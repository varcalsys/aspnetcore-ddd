using System.Net.Mime;
using System.Threading.Tasks;
using Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using NucleoCompartilhado.DomainEvents.Events;
using NucleoCompartilhado.DomainEvents.Notifications.DomainNotifications;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValuesController : BaseController
    {
        private readonly ITesteAppService _testeAppService;

        public ValuesController(IDomainNotificationHandler domainNotificationHandler, ITesteAppService testeAppService) 
            : base(domainNotificationHandler)
        {
            _testeAppService = testeAppService;
        }


        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           _testeAppService.Salvar();

           return CreateResponse(new {teste = "teste"});
        } 

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            DomainEvent.RaiseEvent(new DomainNotification("Teste", "teste"));
            return CreateResponse(new {teste = "teste"});
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
