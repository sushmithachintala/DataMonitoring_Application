using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestApplication.Models;

namespace TestApplication.Entity
{
    public class EFCoreInMemory: DbContext
    {
       public EFCoreInMemory(DbContextOptions<EFCoreInMemory> options):base(options)
        {
            LoadUsers();
            LoadQueue();
            LoadMoniter();
        }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<QueueModel> QueueModel { get; set; }
        public DbSet<MoniterModel> MoniterModel { get; set; }

        public void LoadUsers()
        {
            var users = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\\Data\\Account.json");
            var list = JsonConvert.DeserializeObject<List<UserLogin>>(users);
            UserLogin.AddRange(list);           
        }
        public void LoadQueue()
        {
            var queue = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\\Data\\QueueGroup.json");
            var list = JsonConvert.DeserializeObject<List<QueueModel>>(queue);
            QueueModel.AddRange(list);
        }
        public void LoadMoniter()
        {
            var queue = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + "\\Data\\MonitorData.json");
            var list = JsonConvert.DeserializeObject<List<MoniterModel>>(queue);
            MoniterModel.AddRange(list);
        }
        public List<UserLogin> GetUsers()
        {
            return UserLogin.Local.ToList<UserLogin>();
        }
        public List<MoniterModel> GetMoniter()
        {
            return MoniterModel.Local.ToList<MoniterModel>();
        }
        public List<QueueModel> GetQueue()
        {
            return QueueModel.Local.ToList<QueueModel>();
        }
    }
}
