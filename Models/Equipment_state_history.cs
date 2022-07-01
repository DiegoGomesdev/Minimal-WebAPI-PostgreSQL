using System.ComponentModel.DataAnnotations;

namespace WebAPI_Equipamentos.Models
{
    public class Equipment_state_history
    {
        [Key]
        public Guid Equipment_id { get; set; }
        public DateTime Date { get; set; }
        public Guid Equipment_state_id { get; set; }
    }
}
