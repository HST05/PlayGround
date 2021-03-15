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
        public List<TissueDetailDto> GetDetail()
        {
            using (AnatomyDB context = new AnatomyDB())
            {
                var result = from t in context.Tissues
                             join r in context.Regions on t.RegionId equals r.Id
                             join s in context.Sorts on t.SortId equals s.Id
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

        public List<TissueDetailDto> GetDetailByRegion(int regionId)
        {
            using (AnatomyDB context = new AnatomyDB())
            {
                var result = from t in context.Tissues
                    join r in context.Regions on t.RegionId equals r.Id
                    join s in context.Sorts on t.SortId equals s.Id
                    where (r.Id == regionId)
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

        public List<TissueDetailDto> GetDetailBySort(int sortId)
        {
            using (AnatomyDB context = new AnatomyDB())
            {
                var result = from t in context.Tissues
                             join r in context.Regions on t.RegionId equals r.Id
                             join s in context.Sorts on t.SortId equals s.Id
                             where (s.Id == sortId)
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

        public List<TissueDetailDto> GetDetailBySort_Region(int sortId, int regionId)
        {
            using (AnatomyDB context = new AnatomyDB())
            {
                var result = from t in context.Tissues
                             join r in context.Regions on t.RegionId equals r.Id
                             join s in context.Sorts on t.SortId equals s.Id
                             where s.Id == sortId
                             where r.Id == regionId
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
