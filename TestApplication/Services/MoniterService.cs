using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Entity;
using TestApplication.Models;

namespace TestApplication.Services
{
    public class MoniterService:IMoniterService
    {
        private readonly EFCoreInMemory _context;
        public MoniterService(EFCoreInMemory context)
        {
            _context = context;
        }
        public List<MoniterViewModel> GetMoniterData()
        {
            var res =
                from q in _context.GetQueue()
                join m in _context.GetMoniter() on q.ID equals m.QueueGroupID
                select new MoniterViewModel
                {
                    AfterCallWorkTime = m.AfterCallWorkTime,
                    Handled = m.Handled,
                    HandledWithinSL = m.HandledWithinSL,
                    Name = q.Name,
                    Offered = m.Offered,
                    QueueGroupID = q.ID,
                    SLA_Percent = q.SLA_Percent,
                    SLA_Time = q.SLA_Time,
                    TalkTime = m.TalkTime,
                    Color = ((m.HandledWithinSL/m.Offered)*100)>q.SLA_Percent? "color-green" : "color-red"
                };            
            return res.ToList();
        }
    }
}
