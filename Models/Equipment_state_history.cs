using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Equipamentos.Models
{
    [Keyless]
    public class Equipment_state_history
    {
        [ForeignKey("Equipment_id")]
        public Guid Equipment_id { get; set; }
        public DateTime Date { get; set; }
        
        [ForeignKey("Equipment_state_id")]
        public Guid Equipment_state_id { get; set; }
    }
}
