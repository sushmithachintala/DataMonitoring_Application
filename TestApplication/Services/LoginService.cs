using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Entity;

namespace TestApplication.Services
{
    public class LoginService: ILoginService
    {
        private readonly EFCoreInMemory _context;
       
        public LoginService(EFCoreInMemory context)
        {
            _context = context;
        }
        public bool IsUserValid(string userName,string password)
        {
           return _context.GetUsers().Where(s => s.UserName.ToLower() == userName.ToLower() && s.Password == password).Any();
        }
    }
}
