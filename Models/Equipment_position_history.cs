using System.ComponentModel.DataAnnotations;

namespace WebAPI_Equipamentos.Models
{
    public class Equipment_position_history
    {

        [Key]
        public Guid Equipment_id { get; set; }
        public DateTime Date { get; set; }
        public int Lat { get; set; }
        public int Lon { get; set; }

    }
}
