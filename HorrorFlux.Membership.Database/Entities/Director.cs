using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorrorFlux.Membership.Database.Entities
{
    public class Director : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
