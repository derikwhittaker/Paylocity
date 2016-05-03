using System.Web.Http;
using MediatR;

namespace Paylocity.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IMediator Mediator { get; }

        public BaseApiController( IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}