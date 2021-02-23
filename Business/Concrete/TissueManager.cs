using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Consts;
using Business.Validations.FluentValidation;
using Core.Abstract;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class TissueManager : ITissueService
    {
        ITissueDal _tissueDal;

        public TissueManager(ITissueDal tissueDal)
        {
            _tissueDal = tissueDal;
        }

        [ValidationAspect(typeof(TissueValidator))]
        public IResult<Tissue> Add(Tissue tissue)
        {
            //ValidationTool.Validate(new TissueValidator(), tissue);

            _tissueDal.Add(tissue);
            return new SuccessResult<Tissue>(Messages.success, tissue);
        }

        public IResult<Tissue> Delete(Tissue tissue)
        {
            return new SuccessResult<Tissue>(Messages.success, tissue);
        }

        public IResult<Tissue> Update(Tissue tissue)
        {
            return new SuccessResult<Tissue>(Messages.success, tissue);
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
