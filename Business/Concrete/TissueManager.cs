using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Business.Validations.FluentValidation;
using Core.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class TissueManager : ITissueService
    {
        ITissueDal _tissueDal;
        private ISortService _sortService;

        public TissueManager(ITissueDal tissueDal, ISortService sortService)
        {
            _tissueDal = tissueDal;
            _sortService = sortService;
        }

        [ValidationAspect(typeof(TissueValidator))]
        public IResult<Tissue> Add(Tissue tissue)
        {
            //ValidationTool.Validate(new TissueValidator(), tissue);
            var result = BusinessRules<Tissue>.Checker(DuplicateNameChecker(tissue.Name), SortLimitExceedChecker(3));

            if (result != null)
            {
                foreach (var error in result)
                {
                    return new FailResult<Tissue>(error.Message);
                }
            }

            _tissueDal.Add(tissue);
            return new SuccessResult<Tissue>(Messages.success, tissue);
        }

        [CacheRemoveAspect("ITissueService.GetById")]
        public IResult<Tissue> Delete(Tissue tissue)
        {
            return new SuccessResult<Tissue>(Messages.success, tissue);
        }

        [CacheRemoveAspect("ITissueService.GetById")]
        public IResult<Tissue> Update(Tissue tissue)
        {
            return new SuccessResult<Tissue>(Messages.success, tissue);
        }

        [SecuredOperation("product.add,admin")]
        [CacheAspect]
        public IResult<Tissue> GetById(int id)
        {
            return new SuccessResult<Tissue>(Messages.success, _tissueDal.Get(p => p.Id == id));
        }

        public IResult<List<Tissue>> GetAll()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new FailResult<List<Tissue>>(Messages.fail);
            }
            return new SuccessResult<List<Tissue>>(Messages.success, _tissueDal.GetAll());
        }

        public IResult<List<ProductDetailDto>> GetDetail()
        {
            return new SuccessResult<List<ProductDetailDto>>(Messages.success, _tissueDal.GetDetail());
        }

        private IResult<Tissue> DuplicateNameChecker(string productName)
        {
            var result = _tissueDal.GetAll(p => p.Name == productName).Any();

            if (!result)
            {
                return new FailResult<Tissue>(Messages.duplicateName);
            }
            return new SuccessResult<Tissue>(Messages.success);
        }

        private IResult<Tissue> SortLimitExceedChecker(int sortId)
        {
            var result = _sortService.GetAll().Data.Count;

            if (result>15)
            {
                return new FailResult<Tissue>(Messages.sortLimit);
            }
            return new SuccessResult<Tissue>(Messages.success);
        }
    }
}
