using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Combat
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCombat { get; set; }

    [Required]
    public int IdEntrenador1 { get; set; }

    [ForeignKey(nameof(IdEntrenador1))]
    public required Entrenador Entrenador1 { get; set; }

    [Required]
    public int IdEntrenador2 { get; set; }

    [ForeignKey(nameof(IdEntrenador2))]
    public required Entrenador Entrenador2 { get; set; }

    public int? IdGuanyador { get; set; } = null;

    [ForeignKey(nameof(IdGuanyador))]
    public Entrenador? Guanyador { get; set; }

    public int? IdPokemon1Actiu { get; set; }
    [ForeignKey(nameof(IdPokemon1Actiu))]
    public Pokemon? Pokemon1Actiu { get; set; }

    public int? IdPokemon2Actiu { get; set; }
    [ForeignKey(nameof(IdPokemon2Actiu))]
    public Pokemon? Pokemon2Actiu { get; set; }

    [Range(1, int.MaxValue)]
    public int Torn { get; set; } = 1;

    [EnumDataType(typeof(EstatCombat))]
    public EstatCombat EstatCombat { get; set; } = EstatCombat.EN_CURS;

    [Required]
    public DateTime DataInici { get; set; } = DateTime.Now;

    public DateTime? DataFi { get; set; } = null;

}

public enum EstatCombat
{
    EN_CURS,
    FINALITZAT
}