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
        void Add(Tissue tissue);
        void Delete(Tissue tissue);
        void Update(Tissue tissue);
        IResult<List<Tissue>> GetAll();
        List<Tissue> Get();
        List<ProductDetailDto> GetDetail();

    }
}
