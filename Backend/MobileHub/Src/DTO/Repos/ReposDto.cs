using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileHub.Src.DTO.Repos
{
    public class ReposDto
    {
        public string Name { get; set; } = null!;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public int CommitCount { get; set; } = 0;
    }
}