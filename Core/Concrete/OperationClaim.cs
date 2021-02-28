using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstract;

namespace Core.Concrete
{
    public class OperationClaim:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
