using AITech.Entities.Entities.Common;
using AITech.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Entities.Entities
{
    public class Social:BaseEntity
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
