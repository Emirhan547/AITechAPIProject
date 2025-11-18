using AITech.Entities.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Entities.Entities
{
    public class Feature:BaseEntity
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
    }
}
