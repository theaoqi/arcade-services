// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Maestro.Web.Api.v2018_11_28.Models
{
    public class BuildData
    {
        [Required]
        public string Repository { get; set; }

        public string Branch { get; set; }

        [Required]
        public string Commit { get; set; }

        [Required]
        public string BuildNumber { get; set; }

        public List<v2018_07_16.Models.AssetData> Assets { get; set; }

        public List<BuildRef> Dependencies { get; set; }

        public Data.Models.Build ToDb()
        {
            return new Data.Models.Build
            {
                Repository = Repository,
                Branch = Branch,
                Commit = Commit,
                BuildNumber = BuildNumber,
                Assets = Assets.Select(a => a.ToDb()).ToList(),
            };
        }
    }

    public class BuildRef
    {
        public BuildRef(int buildId, bool isProduct)
        {
            IsProduct = isProduct;
            BuildId = buildId;
        }

        public bool IsProduct { get; }
        public int BuildId { get; }
    }
}
