using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Log
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int RenderingTimeInSeconds { get; set; }
        public DateTime RenderDate { get; set; }
        public string RenderWindow { get; set; }
        public string SceneName { get; set; }
        public int NumberOfModels { get; set; }

        public Log()
        {
            RenderDate = DateTime.Now;
        }
    }   
}
