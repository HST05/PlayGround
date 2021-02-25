using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Abstract;
using Business.Consts;
using Core.Utilities.BusinessRules;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TissueImageManager : ITissueImageService
    {
        private ITissueImageDal _tissueImageDal;

        public TissueImageManager(ITissueImageDal tissueImageDal)
        {
            _tissueImageDal = tissueImageDal;
        }

        public IResult<TissueImage> Add(TissueImage tissueImage)
        {
            var result = BusinessRules<TissueImage>.Checker(ImageCountChecker(3));

            if (result != null)
            {
                foreach (var error in result)
                {
                    return new FailResult<TissueImage>(error.Message);
                }
            }

            _tissueImageDal.AddImage(tissueImage);
            return new SuccessResult<TissueImage>(Messages.success);
        }

        public IResult<TissueImage> Delete(TissueImage tissueImage)
        {
            _tissueImageDal.Delete(tissueImage);
            return new SuccessResult<TissueImage>(Messages.success);
        }

        public IResult<List<TissueImage>> GetImagesPerTissue(int tissueId)
        {
            var result = BusinessRules<TissueImage>.Checker(IfImageExistCheck(tissueId));

            if (result!=null)
            {
                foreach (var error in result)
                {
                    return new FailResult<List<TissueImage>>(error.Message); default bir foto gelicek buraya.
                }
            }
            return new SuccessResult<List<TissueImage>>(Messages.success, _tissueImageDal.GetAll(p=>p.TissueId==tissueId));
        }

        public IResult<TissueImage> Update(TissueImage tissueImage)
        {
            _tissueImageDal.UpdateImage(tissueImage);
            return new SuccessResult<TissueImage>(Messages.success);
        }

        private IResult<TissueImage> ImageCountChecker(int tissueid)
        {
            var result = _tissueImageDal.GetAll(p=>p.TissueId==tissueid).Count;

            if (result==5)
            {
                return new FailResult<TissueImage>(Messages.imageCountExceed);
            }
            return new SuccessResult<TissueImage>(Messages.success);
        }

        private IResult<TissueImage> IfImageExistCheck(int tissueId)
        {
            var result = _tissueImageDal.GetAll(p=>p.TissueId==tissueId).Count;

            if (result==0)
            {
                return new FailResult<TissueImage>(Messages.imageCountExceed);
            }
            return new SuccessResult<TissueImage>(Messages.success);
        }
    }
}
