using System.Net.Http;

namespace BusinessLogic
{
    public class Shape
    {
        private string _name { get; set; }
        public string Name { get; set; }
        public string Owner {  get;  private set; }
    }
}