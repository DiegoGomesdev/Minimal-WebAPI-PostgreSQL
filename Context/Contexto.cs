using Microsoft.EntityFrameworkCore;
using WebAPI_Equipamentos.Models;

namespace WebAPI_Equipamentos.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) => Database.EnsureCreated();

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Equipment_model> Equipment_model { get; set; }
        public DbSet<Equipment_model_state_hourly_earnings> Equipment_model_state_hourly_earnings { get; set; }
        public DbSet<Equipment_position_history> Equipment_position_history { get; set; }
        public DbSet<Equipment_state> Equipment_state { get; set; }
        public DbSet<Equipment_state_history> Equipment_state_history { get; set; }

    }
}
