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
        public List<TissueDetailDto> GetDetailByFilter(int? id, int? sortId, int? regionId)
        {
            using (AnatomyDB context = new AnatomyDB())
            {
                var result = from t in context.Tissues
                             join r in context.Regions on t.RegionId equals r.Id
                             join s in context.Sorts on t.SortId equals s.Id
                             where ((id != null) ? t.Id == id : true)
                             where ((sortId != null) ? s.Id == sortId : true)
                             where ((regionId != null) ? r.Id == regionId : true)
                             select new TissueDetailDto
                             {
                                 Id = t.Id,
                                 Region = r.Name,
                                 Name = t.Name,
                                 Gender = t.Gender,
                                 Sort = s.Name,
                                 Origin = s.Origin
                             };
                return result.ToList();
            }
        }
    }
}
