using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Geo.Models
{
    public class Incredere
    {
        public int ID { get; set; }
        public int? WhocanseeID { get; set; }
        public Whocansee? Whocansee { get; set; }
        public int? TodolistID { get; set; }
        public Todolist? Todolist { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
