namespace Geo.Models
{
    public class Carte
    {
        public int ID { get; set; }
        public string DenumireCarte { get; set; }
        public ICollection<Todolist>? Lists { get; set; }
    }
}
