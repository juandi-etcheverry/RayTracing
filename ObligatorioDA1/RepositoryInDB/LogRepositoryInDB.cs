using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using IRepository;

namespace RepositoryInDB
{
    public class LogRepositoryInDB : IRepositoryLog
    {
        public Log Add(Log log)
        {
            using (var context = new BusinessContext())
            {
                var loggedClient = context.Clients.FirstOrDefault(c => c.Name == log.Client.Name);
                log.Client = loggedClient;

                context.Logs.Add(log);
                context.SaveChanges();
                return log;
            }
        }

        public Log Get(string sceneName, string clientName)
        {
            using (var context = new BusinessContext())
            {
                return context.Logs
                    .Include(l => l.Client)
                    .FirstOrDefault(l => l.SceneName == sceneName && l.Client.Name == clientName);
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