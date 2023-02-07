using DataBase.Configurations;
using DatabaseApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceConfigurationController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ServiceConfigurationController(DatabaseContext context)
            => _context = context;

        [HttpGet(Name = "GetConfigurationForService")]
        public async Task<ActionResult<IEnumerable<ServerViewModel>>> Get()
        {
            try
            {
                var result = await _context.Servers
                                .Include(e => e.DatabaseDefinitions).ThenInclude(d => d.BackUpTargets).ThenInclude(b => b.Storage)
                                .Include(e => e.DatabaseDefinitions).ThenInclude(d => d.ScheduleBackups)
                                .Include(e => e.DatabaseDefinitions).ThenInclude(std => std.Drive)
                                .Include(e => e.DatabaseDefinitions).ThenInclude(dd => dd.BackUpTargets).ThenInclude(bt => bt.Drive)
                                .ToListAsync();
                var config = result.Select(server => (ServerViewModel)server);
                
                return new OkObjectResult(config);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
