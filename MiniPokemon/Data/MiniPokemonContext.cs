using System.Data.Entity;

public class MiniPokemonContext : DbContext
{
    public MiniPokemonContext() : base("MiniPokemonDB")
    {
        Entrenadors = Set<Entrenador>();
        Pokemons = Set<Pokemon>();
        Combats = Set<Combat>();
        Moviments = Set<Moviment>();

    }

    public DbSet<Entrenador> Entrenadors { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Combat> Combats { get; set; }
    public DbSet<Moviment> Moviments { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        Database.SetInitializer(new DropCreateDatabaseAlways<MiniPokemonContext>());

        modelBuilder.Entity<Pokemon>()
            .HasOptional(p => p.Entrenador)
            .WithMany(e => e.Pokemons)
            .HasForeignKey(p => p.EntrenadorId)
            .WillCascadeOnDelete(false);

        modelBuilder.Entity<Pokemon>()
            .HasMany(p => p.EvolucioPrevia)
            .WithMany()
            .Map(cfg =>
            {
                cfg.ToTable("EvolucionsPrevies");
                cfg.MapLeftKey("PokemonId");
                cfg.MapRightKey("EvolucioPreviaId");
            });

        modelBuilder.Entity<Pokemon>()
            .HasMany(p => p.EvolucioSeguent)
            .WithMany()
            .Map(cfg =>
            {
                cfg.ToTable("EvolucionsSeguents");
                cfg.MapLeftKey("PokemonId");
                cfg.MapRightKey("EvolucioSeguentId");
            });


        base.OnModelCreating(modelBuilder);
    }
}
