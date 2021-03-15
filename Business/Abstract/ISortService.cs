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
        IResult<List<Sort>> GetAll();
        IResult<Sort> GetById(int id);
    }
}
