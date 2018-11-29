using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Maestro.Data;
using Microsoft.AspNetCore.ApiVersioning;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Maestro.Web.Api.v2018_11_28.Controllers
{
    public class BuildsController : v2018_07_16.Controllers.BuildsController
    {
        public BuildsController(BuildAssetRegistryContext context) : base(context)
        {
        }

        [ApiRemoved]
        public override Task<IActionResult> Create(v2018_07_16.Models.BuildData build)
        {
            throw new NotSupportedException();
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(v2018_07_16.Models.Build))]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody] Models.BuildData build)
        {
            Data.Models.Build dataModel = build.ToDb();
            dataModel.DateProduced = DateTimeOffset.UtcNow;
            await _context.BuildDependencies.AddRangeAsync(build.Dependencies.Select(b => new Data.Models.BuildDependency
            {
                Build = dataModel,
                DependentBuildId = b.BuildId,
                IsProduct = b.IsProduct,
            }));

            await _context.Builds.AddAsync(dataModel);
            await _context.SaveChangesAsync();
            return CreatedAtRoute(
                new
                {
                    action = "GetBuild",
                    id = dataModel.Id
                },
                new v2018_07_16.Models.Build(dataModel));

        }
    }
}
