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
        IResult<List<Region>> GetAll();
        IResult<Region> GetById(int id);
    }
}
