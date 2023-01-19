namespace Geo.Models
{
    public class Countriestovisit
    {
        public int ID { get; set; }
        public string CountryName { get; set; }
        public ICollection<Todolist>? Lists { get; set; }
    }
}
