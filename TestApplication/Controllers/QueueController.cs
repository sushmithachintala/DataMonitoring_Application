using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Services;

namespace TestApplication.Controllers
{
    public class QueueController : Controller
    {
        private IMoniterService iMoniterService;
        public QueueController(IMoniterService _iMoniterService)
        {
            iMoniterService = _iMoniterService;
        }
        public JsonResult GetMoniterData()
        {
            return new JsonResult(iMoniterService.GetMoniterData());
        }
    }
}
