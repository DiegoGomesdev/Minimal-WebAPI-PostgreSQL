using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Equipamentos.Models
{
    [Keyless]
    public class Equipment_model_state_hourly_earnings
    {
        [ForeignKey("Equipment_model_id")]
        public Guid Equipment_model_id { get; set; }
        
        [ForeignKey("Equipment_state_id")]
        public Guid Equipment_state_id { get; set; }
        public int Value { get; set; }


    }
}
