using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Services
{
   public interface ILoginService
    {
        bool IsUserValid(string userName, string password);
    }
}
