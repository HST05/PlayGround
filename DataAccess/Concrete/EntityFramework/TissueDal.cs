using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class TissueDal : EFEntityRepositoryBase<AnatomyDB, Tissue>, ITissueDal
    {
        public List<ProductDetailDto> GetDetail()
        {
            using (AnatomyDB context = new AnatomyDB())
            {
                var result = from ti in context.Tissues
                             join r in context.Regions on ti.RegionId equals r.Id
                             join ty in context.Types on ti.TypeId equals ty.Id                                                
                    select new ProductDetailDto {Id = ti.Id, Region = r.Name, Name = ti.Name, Gender = ti.Gender, Type = ty.Name, Origin = ty.Origin};
                return result.ToList();
            }

        }
        
    }
}
