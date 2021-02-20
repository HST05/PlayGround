using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Consts;

namespace Business.Abstract
{
    interface ITissueService
    {
        void Add(Tissue tissue);
        void Delete(Tissue tissue);
        void Update(Tissue tissue);
        List<Tissue> GetAll();
        List<Tissue> Get();


    }
}
