namespace Geo.Models
{
    public class Obiective
    {
        public int ID { get; set; }
        public string ObiectivulMeu { get; set; }
        public ICollection<Todolist>? Lists { get; set; }
    }
}
