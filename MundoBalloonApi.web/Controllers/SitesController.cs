using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Models;

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
        public async Task<IActionResult> GetAllSiteProducts()
        {
            var site = await _service.GetSite(true, true, true, true);
            return new ObjectResult(site);
        }
    }
}