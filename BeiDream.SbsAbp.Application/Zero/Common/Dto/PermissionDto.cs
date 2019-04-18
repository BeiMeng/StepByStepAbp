using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Common.Dto
{
    public class PermissionDto
    {
        public string ParentName { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsGrantedByDefault { get; set; }
        public IReadOnlyList<PermissionDto> Children { get; set; }
    }
}
