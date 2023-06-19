using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Deliveries
    {
        [Key]
        public int Deliveries_id { get; set; }
        public int? Customer_id { get; set; }
        public DateTime Date { get; set; }
    }
}
