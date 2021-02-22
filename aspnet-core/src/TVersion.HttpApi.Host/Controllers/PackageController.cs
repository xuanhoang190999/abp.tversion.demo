using TVersion.Services;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TVersion.Models;
using System.Collections.Generic;

namespace TVersion.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly PackageService _packageService;

        public PackageController(
            PackageService packageService
        ){
            _packageService = packageService;
        }

        [HttpGet]
        [Route("getall")]
        public List<Package> GetAll()
        {
            var result = _packageService.GetAll();

            return result;
        }
    }
}
