using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Domain;
using IRepository;
using RepositoryInDB;

namespace BusinessLogic
{
    public class RenderLogLogic
    {
        private readonly IRepositoryLog _repository = new LogRepositoryInDB();


        public Log Add(Log logToAdd)
        {
            AssignLogToClient(logToAdd);
            return _repository.Add(logToAdd);
        }

        public IList<Log> GetAll()
        {
            return _repository.GetAll();
        }

        public Log Get(string sceneName, string clientName)
        {
            return _repository.Get(sceneName, clientName);
        }

        public int GetAverageRenderTime()
        {
            return Convert.ToInt32(Math.Floor(GetAll().Select(l => l.RenderingTimeInSeconds).Average()));
        }

        public int GetTotalRenderTimeInMinutes()
        {
            return Convert.ToInt32(Math.Floor(GetAll().Select(l => l.RenderingTimeInSeconds).Sum() / 60.0));
        }

        public (Client Client, int AccumulatedRenderTime) GetClientWithMaxRenderTime()
        {
            var result = GetAll()
                .GroupBy(l => l.Client)
                .Select(g => new
                {
                    Client = g.Key,
                    AccumulatedRenderTime = g.Sum(lr => lr.RenderingTimeInSeconds)
                })
                .OrderByDescending(g => g.AccumulatedRenderTime)
                .FirstOrDefault();

            if (result is null) throw new NullReferenceException("There are no rendered scenes");

            return (result.Client, result.AccumulatedRenderTime);
        }

        private void AssignLogToClient(Log log)
        {
            if (Session.LoggedClient == null)
                throw new SessionException("Client needs to be logged in to create new model");
            log.Client = Session.LoggedClient;
        }
    }
}