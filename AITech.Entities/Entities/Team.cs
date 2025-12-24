using AITech.Entities.Entities;
using AITech.Entities.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Entity.Entities
{
    public class Team:BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public ICollection<Social> Socials { get; set; }
    }
}
