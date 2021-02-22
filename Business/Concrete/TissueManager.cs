using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Consts;
using Core.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TissueManager : ITissueService
    {
        ITissueDal _tissueDal;

        public TissueManager(ITissueDal tissueDal)
        {
            _tissueDal = tissueDal;
        }

        public void Add(Tissue tissue)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tissue tissue)
        {
            throw new NotImplementedException();
        }

        public void Update(Tissue tissue)
        {
            throw new NotImplementedException();
        }

        public List<Tissue> Get()
        {
            throw new NotImplementedException();
        }

        public IResult<List<Tissue>> GetAll()
        {
            if (DateTime.Now.Hour==17)
            {
                return new FailResult<List<Tissue>>(Messages.fail);
            }
            return new SuccessResult<List<Tissue>>(_tissueDal.GetAll(), Messages.success);
        }

        public List<ProductDetailDto> GetDetail()
        {
            return _tissueDal.GetDetail();
        }
    }
}
