using Microsoft.AspNetCore.Mvc;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.Dtos;

namespace MundoBalloonApi.web.Controllers
{
    [Route("api/v1/sites")]
    public class SitesController : Controller
    {
    
        private readonly ISiteService _service;

        public SitesController(ISiteService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Produces("application/json", Type = typeof(Site))]
        public IActionResult GetAllSiteProducts()
        {
            var site = _service.GetAllSiteProducts(true, true, true, true);
            return new ObjectResult(site);
        }
    }
}