using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Consts;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities;
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

        public IResult<Sort> Add(Sort sort)
        {
            throw new NotImplementedException();
        }

        public IResult<Sort> Delete(Sort sort)
        {
            throw new NotImplementedException();
        }

        public IResult<List<Sort>> GetAll()
        {
            return new SuccessResult<List<Sort>>(Messages.success,_sortDal.GetAll());
        }

        public IResult<Sort> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult<List<TissueDetailDto>> GetDetail()
        {
            throw new NotImplementedException();
        }

        public IResult<Sort> Update(Sort sort)
        {
            throw new NotImplementedException();
        }
    }
}
