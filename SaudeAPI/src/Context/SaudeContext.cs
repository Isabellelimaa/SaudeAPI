using Microsoft.EntityFrameworkCore;
using SaudeAPI.Models.Db;

namespace SaudeAPI.Context
{
    public partial class SaudeContext : DbContext
    {
        public SaudeContext()
        {
        }

        public SaudeContext(DbContextOptions<SaudeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Endrco> Endrco { get; set; }
        public virtual DbSet<Enfrmdade> Enfrmdade { get; set; }
        public virtual DbSet<Exame> Exame { get; set; }
        public virtual DbSet<Hsptal> Hsptal { get; set; }
        public virtual DbSet<HsptalRefrncia> HsptalRefrncia { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Refrncia> Refrncia { get; set; }
        public virtual DbSet<RefrnciaEnfrmdade> RefrnciaEnfrmdade { get; set; }
        public virtual DbSet<Slctcao> Slctcao { get; set; }
        public virtual DbSet<SlctcaoEnfrmdade> SlctcaoEnfrmdade { get; set; }
        public virtual DbSet<SlctcaoExame> SlctcaoExame { get; set; }
        public virtual DbSet<SlctcaoObs> SlctcaoObs { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}