using System.Collections.Generic;

namespace Maestro.Web.Api.v2018_07_16.Models
{
    public class BuildTree
    {
        public BuildTree(IEnumerable<Build> builds)
        {
            Builds = builds;
        }

        public IEnumerable<Build> Builds { get; }
    }
}
