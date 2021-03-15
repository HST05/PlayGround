using Core.Utilities.Result;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRegionService
    {
        IResult<Region> Add(Region region);
        IResult<Region> Delete(Region region);
        IResult<Region> Update(Region region);
        IResult<List<Region>> GetAll();
        IResult<Region> GetById(int id);
        IResult<List<TissueDetailDto>> GetDetail();
    }
}
