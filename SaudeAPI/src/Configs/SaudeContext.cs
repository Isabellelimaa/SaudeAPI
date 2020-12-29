namespace SaudeAPI.Configs
{
   public class SaudeContext : DbContext
   {
        public SaudeContext(DbContextOptions<SaudeContext> options)
            : base(options)
        {
        }

       public DbSet<Endrco> Endrco { get; set; }
       public DbSet<Enfrmdade> Enfrmdade { get; set; }
       public DbSet<Exame> Exame { get; set; }
       public DbSet<Hsptal> Hsptal { get; set; }
       public DbSet<HsptalRefrncia> HsptalRefrncia { get; set; }
       public DbSet<Paciente> Paciente { get; set; }
       public DbSet<Refrncia> Refrncia { get; set; }
       public DbSet<RefrnciaEnfrmdade> RefrnciaEnfrmdade { get; set; }
       public DbSet<Slctcao> Slctcao { get; set; }
       public DbSet<SlctcaoEnfrmdade> SlctcaoEnfrmdade { get; set; }
       public DbSet<SlctcaoExame> SlctcaoExame { get; set; }
       public DbSet<SlctcaoObs> SlctcaoObs { get; set; }
       public DbSet<Status> Status { get; set; }
       public DbSet<Usuario> Usuario { get; set; }

    }
}   