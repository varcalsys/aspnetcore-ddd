using Microsoft.AspNetCore.Mvc;
using NucleoCompartilhado.DomainEvents.Notifications.DomainNotifications;

namespace Api.Controllers
{
    public abstract class BaseController: Controller
    {
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        protected BaseController(IDomainNotificationHandler domainNotificationHandler)
        {
            _domainNotificationHandler = domainNotificationHandler;
        }

        public virtual IActionResult CreateResponse(object result)
        {
            if (_domainNotificationHandler.HasNotification())
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _domainNotificationHandler.GetNotifications()
                });
            }

            return Ok(new
            {
                success = true,
                data = result
            });
        }
    }
}
