using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class TissueImageDal:EFEntityRepositoryBase<AnatomyDB,TissueImage>,ITissueImageDal
    {
        public void AddImage(TissueImage tissueImage)
        {
            using (AnatomyDB context = new AnatomyDB())
            {
                tissueImage.Date=DateTime.Now;

                var addedEntity = context.Entry(tissueImage);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateImage(TissueImage tissueImage)
        {
            using (AnatomyDB context = new AnatomyDB())
            {
                tissueImage.Date=DateTime.Now;

                var updatedEntity = context.Entry(tissueImage);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
