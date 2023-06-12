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
            if (Session.LoggedClient == null) throw new SessionException("Client needs to be logged in to create new model");
            logToAdd.Client = Session.LoggedClient;
            return _repository.Add(logToAdd);
        }

        public IList<Log> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
