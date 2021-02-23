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

        public ChangeLogController(
            ChangeLogService changelogService
        )
        {
            _changelogService = changelogService;
        }
    }
}
