using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstract;

namespace Entities.Concrete
{
    public class TissueImage : IEntity
    {
        public int Id { get; set; }
        public int TissueId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public byte[] Image { get; set; }
        public string Guid { get; set; }
    }
}
