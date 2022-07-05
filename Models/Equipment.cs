using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Equipamentos.Models
{
    public class Equipment
    {
        [Key]
        public Guid Id { get; set; }
        
        [ForeignKey("Equipment_model_id")]
        public Guid Equipment_model_id { get; set; }
        public string? Name { get; set; }
    }
}
