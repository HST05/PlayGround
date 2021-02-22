using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TissuesController : ControllerBase
    {
        ITissueService _tissueService;

        public TissuesController(ITissueService tissueService)
        {
            _tissueService = tissueService;
        }

        [HttpGet]
        public List<Tissue> GetAll()
        {
            var result = _tissueService.GetAll();
            return result;
        }
    }
}
