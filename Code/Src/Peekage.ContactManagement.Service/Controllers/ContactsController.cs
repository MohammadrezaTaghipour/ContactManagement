using Microsoft.AspNetCore.Mvc;
using Peekage.ContactManagement.Service.Application.Contacts;
using Peekage.ContactManagement.Service.Framework;
using Peekage.ContactManagement.Service.Infrastructure.Query;
using System.Threading.Tasks;

namespace Peekage.ContactManagement.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        ICommandBus _bus;
        IContactsQueryService _queryService;

        public ContactsController(ICommandBus bus,
            IContactsQueryService queryService)
        {
            _bus = bus;
            _queryService = queryService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(DefineContactCommand command)
        {
            await _bus.Dispatch(command);
            return Ok(command.Id);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(SearchContactQuery query)
        {
            var result = await _queryService.Search(query);
            return Ok(result);
        }
    }
}