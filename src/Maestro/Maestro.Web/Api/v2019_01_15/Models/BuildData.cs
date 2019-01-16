// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Maestro.Web.Api.v2019_01_15.Models
{
    public class BuildData : Maestro.Web.Api.v2018_07_16.Models.BuildData
    {
        //[Required] // making non required just for test
        public string BuildId { get; set; }

        public new Data.Models.Build ToDb()
        {
            return new Data.Models.Build
            {
                Repository = Repository,
                Branch = Branch,
                Commit = Commit,
                BuildNumber = BuildNumber,
                BuildId = BuildId,
                Assets = Assets.Select(a => a.ToDb()).ToList()
            };
        }
    }
}
