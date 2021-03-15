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
    public class RegionManager : IRegionService
    {
        private IRegionDal _regionDal;

        public RegionManager(IRegionDal regionDal)
        {
            _regionDal = regionDal;
        }

        public IResult<Region> Add(Region region)
        {
            throw new NotImplementedException();
        }

        public IResult<Region> Delete(Region region)
        {
            throw new NotImplementedException();
        }

        public IResult<List<Region>> GetAll()
        {
            return new SuccessResult<List<Region>>(Messages.success,_regionDal.GetAll());
        }

        public IResult<Region> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult<List<TissueDetailDto>> GetDetail()
        {
            throw new NotImplementedException();
        }

        public IResult<Region> Update(Region region)
        {
            throw new NotImplementedException();
        }
    }
}
