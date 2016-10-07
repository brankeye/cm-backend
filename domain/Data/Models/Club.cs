using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cm.backend.domain.Data.Interfaces;

namespace cm.backend.domain.Data.Models
{
    public class Club : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
