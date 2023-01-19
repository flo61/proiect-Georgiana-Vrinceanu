using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Geo.Models
{
    public class Whocansee
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Adress { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        [Display(Name = "Nume")]
        public string? Nume
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Incredere>? Trust { get; set; }
    }
}
