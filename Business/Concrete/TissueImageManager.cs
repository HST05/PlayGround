using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Business.Validations.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Concrete.Files;
using Core.Utilities.BusinessRules;
using Core.Utilities.Filing.Database;
using Core.Utilities.Filing.Local;
using Core.Utilities.Guids;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TissueImageManager : ITissueImageService
    {
        private ITissueImageDal _tissueImageDal;
        private LocalFileSystem _localFileSystem;
        private DatabaseFileSytem _databaseFileSytem;

        public TissueImageManager(ITissueImageDal tissueImageDal)
        {
            _tissueImageDal = tissueImageDal;
            _localFileSystem = new ImageLocalFiling();
            _databaseFileSytem = new ImageDbFiling();
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(TissueImageValidator))]
        public IResult<TissueImage> Add(Image file, int tissueId)
        {
            var result = BusinessRules<TissueImage>.Checker(ImageCountChecker(tissueId));

            TissueImage tissueImage = new TissueImage()
            {
                ImagePath = _localFileSystem.Path,
                Guid = new GuidGenerator().Generator(),
                Date = DateTime.Now,
                TissueId = tissueId,
                Image = _databaseFileSytem.FileToBytes(file)
            };

            if (result != null)
            {
                foreach (var error in result)
                {
                    return new FailResult<TissueImage>(error.Message);
                }
            }

            _localFileSystem.Filing(file, tissueImage.Guid);
            _tissueImageDal.Add(tissueImage);
            return new SuccessResult<TissueImage>(Messages.success);
        }

        public IResult<TissueImage> Delete(TissueImage tissueImage)
        {
            _tissueImageDal.Delete(tissueImage);
            return new SuccessResult<TissueImage>(Messages.success);
        }

        public IResult<List<string>> GetImagesPerTissue(int tissueId)
        {
            var stringImages = new List<string>();
            var result = BusinessRules<TissueImage>.Checker(IfImageExistCheck(tissueId));

            //code refactor lazım, diğer rule'ları bundan ayırıp if içinde if şeklinde(belki ?). (Tüm hataları gezip eğer başka hata varsa durdur.)
            if (!result[0].Success)
            {
                var defaultByteImage =_tissueImageDal.Get(p => p.TissueId == 5);
                var stringImage = ((ImageDbFiling) _databaseFileSytem).BytesToImage(defaultByteImage.Image);
                stringImages.Add(stringImage);
                return new SuccessResult<List<string>>(Messages.success, stringImages);
            }

            var byteImages = _tissueImageDal.GetAll(p => p.TissueId == tissueId);
            foreach (var byteImage in byteImages)
            {
                var addedImage = ((ImageDbFiling)_databaseFileSytem).BytesToImage(byteImage.Image);
                stringImages.Add(addedImage);
            }

            return new SuccessResult<List<string>>(Messages.success, stringImages);
        }

        public IResult<TissueImage> Update(TissueImage tissueImage)
        {
            tissueImage.Date = DateTime.Now;
            _tissueImageDal.Update(tissueImage);
            return new SuccessResult<TissueImage>(Messages.success);
        }

        private IResult<TissueImage> ImageCountChecker(int tissueid)
        {
            var result = _tissueImageDal.GetAll(p => p.TissueId == tissueid).Count;

            if (result == 5)
            {
                return new FailResult<TissueImage>(Messages.imageCountExceed);
            }
            return new SuccessResult<TissueImage>(Messages.success);
        }

        private IResult<TissueImage> IfImageExistCheck(int tissueId)
        {
            var result = _tissueImageDal.GetAll(p => p.TissueId == tissueId).Count;

            if (result == 0)
            {
                return new FailResult<TissueImage>(Messages.imageNotExists);
            }
            return new SuccessResult<TissueImage>(Messages.success);
        }
    }
}
