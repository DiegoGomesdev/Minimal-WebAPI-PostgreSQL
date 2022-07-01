using System.ComponentModel.DataAnnotations;

namespace WebAPI_Equipamentos.Models
{
    public class Equipment_model_state_hourly_earnings
    {
        [Key]
        public Guid Equipment_model_id { get; set; }
        public Guid Equipment_state_id { get; set; }
        public int Value { get; set; }


    }
}
