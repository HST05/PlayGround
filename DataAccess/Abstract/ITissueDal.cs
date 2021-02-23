using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstract;
using Core.DataAccess.EntityFramework;
using Entities;

namespace DataAccess.Abstract
{
    public interface ITissueDal:IEntityRepository<Tissue>
    {
        List<ProductDetailDto> GetDetail();
    }
}
