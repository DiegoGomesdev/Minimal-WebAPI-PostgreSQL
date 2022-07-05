using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Equipamentos.Models
{
    [Keyless]
    public class Equipment_position_history
    {
        [ForeignKey("Equipment_id")]
        public Guid Equipment_id { get; set; }
        public DateTime Date { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

    }
}
