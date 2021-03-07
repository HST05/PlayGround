using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstract;
using Core.Concrete.Files;
using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ITissueImageService
    {
        IResult<TissueImage> Add(Image file, int tissueId);
        IResult<TissueImage> Delete(TissueImage tissueImage);
        IResult<TissueImage> Update(TissueImage tissueImage);
        IResult<List<string>> GetImagesPerTissue(int tissueId);
    }
}
