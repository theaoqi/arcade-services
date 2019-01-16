// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Maestro.Web.Api.v2019_01_15.Models
{
    public class Build : Maestro.Web.Api.v2018_07_16.Models.Build
    {
        public Build([NotNull] Data.Models.Build other) : base(other)
        {
            BuildId = other.BuildId;
        }

        public string BuildId { get; }
    }
}
