using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Entity
{
    public class DataInitlizer
    {
        DataInitlizer()
        {          
        }
        public static void LoadUsers(EFCoreInMemory context)
        {          
            var users = System.IO.File.ReadAllText(Directory.GetCurrentDirectory()+"\\Data\\Account.json");
            var list = JsonConvert.DeserializeObject<List<UserLogin>>(users);
            context.UserLogin.AddRange(list);
            context.SaveChanges();
        }
    }
}
