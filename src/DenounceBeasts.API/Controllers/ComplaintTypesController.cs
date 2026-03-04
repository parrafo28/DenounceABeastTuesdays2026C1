using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ComplaintTypesController : BaseCatalogController<ComplaintType>
    {

        public ComplaintTypesController(DenounceBeastsContext context) : base(context)
        {

        }


    }
}
