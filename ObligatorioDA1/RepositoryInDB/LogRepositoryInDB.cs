using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain;
using IRepository;

namespace RepositoryInDB
{
    public class LogRepositoryInDB: IRepositoryLog
    {
        public Log Add(Log log)
        {
            using (var context = new BusinessContext())
            {
                Client loggedClient = context.Clients.FirstOrDefault(c => c.Name == log.Client.Name);
                log.Client = loggedClient;

                context.Logs.Add(log);
                context.SaveChanges();
                return log;
            }
        }

        public IList<Log> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Logs
                            .Include(l => l.Client)
                            .ToList();
            }
        }
    }
}
