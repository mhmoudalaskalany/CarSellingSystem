using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace CarSellingSystem.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
        public Make()
        {
            //initialize the models collection to avoid creating new Collection in every call on make class
            //also avoid null reference exception
            Models = new Collection<Models>();
        }
    }
}