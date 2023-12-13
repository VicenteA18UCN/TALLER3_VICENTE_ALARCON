using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileHub.Src.DTO.Repos
{
    public class ReposDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Language { get; set; } = null!;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public string HtmlUrl { get; set; } = null!;
        public int CommitCount { get; set; } = 0;
    }
}