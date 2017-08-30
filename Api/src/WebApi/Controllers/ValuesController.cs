using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NucleoCompartilhado.DomainEvents.Events;
using NucleoCompartilhado.DomainEvents.Notifications.DomainNotifications;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        public ValuesController(IDomainNotificationHandler domainNotificationHandler) 
            : base(domainNotificationHandler)
        {

        }


        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           DomainEvent.RaiseEvent(new DomainNotification("Teste", "teste"));

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
