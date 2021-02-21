using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Abstract;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TissueManager : ITissueService
    {
        private ITissueDal _tissueDal;

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

        public List<Tissue> GetAll()
        {
            return _tissueDal.GetAll();
        }

        public List<ProductDetailDto> GetDetail()
        {
            return _tissueDal.GetDetail();
        }
    }
}
