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
                var result = from t in context.Tissues
                             join r in context.Regions on t.RegionId equals r.Id
                             join s in context.Sorts on t.SortId equals s.Id                                                
                    select new ProductDetailDto {Id = t.Id, Region = r.Name, Name = t.Name, Gender = t.Gender, Sort = s.Name, Origin = s.Origin};
                return result.ToList();
            }

        }
        
    }
}
