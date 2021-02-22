using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TVersion.Services;
using TVersion.Models;

namespace TVersion.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ChangeLogController : ControllerBase
    {
        private readonly ChangeLogService _changelogService;
        private readonly IAbpAntiForgeryManager _antiForgeryManager;

        public ChangeLogController(
            ChangeLogService changelogService,
            IAbpAntiForgeryManager antiForgeryManager
        )
        {
            _changelogService = changelogService;
            _antiForgeryManager = antiForgeryManager;
        }

        [HttpGet]
        [Route("get-by-packageid/{id}")]
        public List<ChangeLog> GetAll(long id)
        {
            var result = _changelogService.GetByPackageId(id);

            return result;
        }
    }
}
