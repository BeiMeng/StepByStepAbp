using Abp.Runtime.Validation;
using BeiDream.SbsAbp.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Users.Dto
{
    public class GetUsersInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {
        public int? Role { get; set; }
        public bool OnlyLockedUsers { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Name,Surname";
            }

            Filter = Filter?.Trim();
        }
    }
}
