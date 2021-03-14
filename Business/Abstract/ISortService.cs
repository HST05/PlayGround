using Core.Utilities.Result;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISortService
    {
        IResult<Sort> Add(Sort sort);
        IResult<Sort> Delete(Sort sort);
        IResult<Sort> Update(Sort sort);
        IResult<List<Sort>> GetAll();
        IResult<Sort> GetById(int id);
        IResult<List<TissueDetailDto>> GetDetail();
    }
}
