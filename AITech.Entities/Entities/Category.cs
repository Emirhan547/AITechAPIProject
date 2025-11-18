using AITech.Entities.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AITech.Entities.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public IList<Project> Projects { get; set; }
    }
}
