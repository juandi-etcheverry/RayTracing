using System;

namespace Domain
{
    public class Log
    {
        public Log()
        {
            RenderDate = DateTime.Now;
        }

        public int Id { get; set; }
        public Client Client { get; set; }
        public int RenderingTimeInSeconds { get; set; }
        public DateTime RenderDate { get; set; }
        public string RenderWindow { get; set; }
        public string SceneName { get; set; }
        public int NumberOfModels { get; set; }
    }
}