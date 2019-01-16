// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Maestro.Data;
using Maestro.Web.Api.v2019_01_15.Models;
using Microsoft.AspNetCore.ApiVersioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace Maestro.Web.Api.v2019_01_15.Controllers
{
    [Route("builds")]
    [ApiVersion("2019-01-15")]
    public class BuildsController : Maestro.Web.Api.v2018_07_16.Controllers.BuildsController
    {
        public BuildsController(BuildAssetRegistryContext context) : base(context)
        {
        }

        [HttpPost]
        [SwaggerResponse((int) HttpStatusCode.Created, Type = typeof(Models.Build))]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody] BuildData build)
        {
            Maestro.Data.Models.Build buildModel = build.ToDb();
            buildModel.DateProduced = DateTimeOffset.UtcNow;
            buildModel.Dependencies = build.Dependencies != null
                ? await _context.Builds.Where(b => build.Dependencies.Contains(b.Id)).ToListAsync()
                : null;
            await _context.Builds.AddAsync(buildModel);
            await _context.SaveChangesAsync();
            return CreatedAtRoute(
                new
                {
                    action = "GetBuild",
                    id = buildModel.Id
                },
                new Models.Build(buildModel));
        }
    }
}
