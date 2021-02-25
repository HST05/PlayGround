using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ITissueImageService
    {
        IResult<TissueImage> Add(TissueImage tissueImage);
        IResult<TissueImage> Delete(TissueImage tissueImage);
        IResult<TissueImage> Update(TissueImage tissueImage);
        IResult<List<TissueImage>> GetImagesPerTissue(int tissueId);
    }
}
