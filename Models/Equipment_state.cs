using System.ComponentModel.DataAnnotations;

namespace WebAPI_Equipamentos.Models
{
    public class Equipment_state
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
    }
}
