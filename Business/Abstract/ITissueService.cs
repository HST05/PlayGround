using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Consts;
using Entities;
using Core.Utilities.Result;

namespace Business.Abstract
{
    public interface ITissueService
    {
        IResult<object> Add(Tissue tissue);
        IResult<object> Delete(Tissue tissue);
        IResult<object> Update(Tissue tissue);
        IResult<List<Tissue>> GetAll();
        IResult<Tissue> GetById(int id);
        IResult<List<ProductDetailDto>> GetDetail();

    }
}
