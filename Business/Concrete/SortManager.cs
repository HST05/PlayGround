using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Consts;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SortManager : ISortService
    {
        private ISortDal _sortDal;

        public SortManager(ISortDal sortDal)
        {
            _sortDal = sortDal;
        }

        public IResult<List<Sort>> GetAll()
        {
            return new SuccessResult<List<Sort>>(Messages.success, _sortDal.GetAll());
        }

        public IResult<Sort> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
