namespace Geo.Models
{
    public class Materie
    {
        public int ID { get; set; }
        public string Materiipecaresaleiau { get; set; }
        public ICollection<Todolist>? Lists { get; set; }
    }
}
