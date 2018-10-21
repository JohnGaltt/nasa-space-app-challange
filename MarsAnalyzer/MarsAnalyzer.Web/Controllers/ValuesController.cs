using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsAnalyzer.Data.Model;
using MarsAnalyzer.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace MarsAnalyzer.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PixelCondition> Get(int startPointX, int startPointY)
        {
            return DatabaseAccessLayerHelper.HeatMapHelper.GetAllPoints(startPointX, startPointY);
        }
    }
}