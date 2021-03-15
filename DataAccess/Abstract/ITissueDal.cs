using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstract;
using Entities;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ITissueDal:IEntityRepository<Tissue>
    {
        List<TissueDetailDto> GetDetailByFilter(int? id, int? sortId, int? regionId);

    }
}
