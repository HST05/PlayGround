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

        public IResult<object> Add(Tissue tissue)
        {
            return new SuccessResult<object>(Messages.success);
        }

        public IResult<object> Delete(Tissue tissue)
        {
            return new SuccessResult<object>(Messages.success);
        }

        public IResult<object> Update(Tissue tissue)
        {
            return new SuccessResult<object>(Messages.success);
        }
        
        public IResult<Tissue> GetById(int id)
        {
            return new SuccessResult<Tissue>(Messages.success, _tissueDal.Get(p=>p.Id==id));
        }

        public IResult<List<Tissue>> GetAll()
        {
            if (DateTime.Now.Hour==17)
            {
                return new FailResult<List<Tissue>>(Messages.fail);
            }
            return new SuccessResult<List<Tissue>>(Messages.success, _tissueDal.GetAll());
        }

        public IResult<List<ProductDetailDto>> GetDetail()
        {
            return new SuccessResult<List<ProductDetailDto>>(Messages.success, _tissueDal.GetDetail());
        }
    }
}
