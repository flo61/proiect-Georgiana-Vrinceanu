using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Geo.Models
{
    public class Todolist
    {
        public int ID { get; set; }
        public string Movies { get; set; }
        public string Countries { get; set; }
        public decimal Rude { get; set; }
        public string Goals { get; set; }
        [DataType(DataType.Date)]
        public DateTime Thedate { get; set; }
        public int? CountriestovisitID { get; set; }
        public Countriestovisit? Countriestovisit { get; set; }
        public int? ObiectiveID { get; set; }
        public Obiective? Obiective { get; set; }
        public int? CarteID { get; set; }
        public Carte? Carte { get; set; }
        public int? MaterieID { get; set; }
        public Materie? Materie { get; set; }
        public int? IncredereID { get; set; }
        public Incredere? Incredere { get; set; }

    }
}
