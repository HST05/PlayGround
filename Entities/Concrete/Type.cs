using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    class Type:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
    }
}
