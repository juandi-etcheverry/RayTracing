using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            AssignSceneToClient(logToAdd);
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

        private void AssignSceneToClient(Log log)
        {
            if (Session.LoggedClient == null) throw new SessionException("Client needs to be logged in to create new model");
            log.Client = Session.LoggedClient;
        }
    }
}
