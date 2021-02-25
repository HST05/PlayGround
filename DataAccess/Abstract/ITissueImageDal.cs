using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ITissueImageDal:IEntityRepository<TissueImage>
    {
        void AddImage(TissueImage tissueImage);
        void UpdateImage(TissueImage tissueImage);
    }
}
