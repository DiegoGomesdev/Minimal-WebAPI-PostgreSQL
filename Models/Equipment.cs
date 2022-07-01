using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Equipamentos.Models
{
    public class Equipment
    {
        public Guid Id { get; set; }
        public Guid Equipment_model_id { get; set; }
        public string? Name { get; set; }
    }
}
