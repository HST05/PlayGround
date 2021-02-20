using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Tissue:IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
    }
}
