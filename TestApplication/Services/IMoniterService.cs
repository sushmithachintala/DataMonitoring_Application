using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Services
{
   public interface IMoniterService
    {
        List<MoniterViewModel> GetMoniterData();
    }
}
