using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pokemon
{

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int IdPokemon { get; set; }

    public ICollection<int> IdEvolucioPrevia { get; set; } = [];

    public ICollection<int> IdEvolucioSeguent { get; set; } = [];



    public ICollection<Pokemon> EvolucioPrevia { get; set; } = [];

    public ICollection<Pokemon> EvolucioSeguent { get; set; } = [];

	[Range(1, 100)]
	public int? NivellEvolucio { get; set; }

	[Required]
    [StringLength(50)]
    public string Nom { get; set; } = null!;

	[Required]
	[EnumDataType(typeof(TipusPokemon))]
    public TipusPokemon Tipus { get; set; }

	[Range(1, 100)]
    public int Nivell { get; set; } = 5;

    [Required]
    [Range(0, int.MaxValue)]
    public int _puntsVida = 50;

    public int PuntsVida
    {
        get => _puntsVida;
        set
        {
            _puntsVida = Math.Max(0, value);
            EstaDebilitat = _puntsVida == 0;
        }
    }

    [Required]
    [Range(1, int.MaxValue)]
    public int PuntsVidaMaxims { get; set; } = 50;

    [Range(0, int.MaxValue)]
    public int _experiencia = 0;

    public int Experiencia
    {
        get => _experiencia;
        set
        {
            _experiencia += Math.Max(0, value);
            if (_experiencia / 100 > 0)
            {
				int NivellsPujats = (_experiencia / 100);
				Nivell += NivellsPujats;
                PuntsVidaMaxims += 10 * NivellsPujats;
                PuntsVida = PuntsVidaMaxims;
                _experiencia = Nivell % 100;
			}

        }
    }

    public bool EstaDebilitat { get; set; } = false;

	public int? EntrenadorId { get; set; } = null;

	public Entrenador? Entrenador { get; set; } = null;

    [MaxLength(4)]
    public ICollection<Moviment> Moviments { get; set; } = [];
}

public enum TipusPokemon
{
    FOC,
    AIGUA,
    PLANTA,
    ELECTRIC,
    NORMAL,
    TERRA,
    VOLADOR,
    PSÍQUIC,
    LLUITA,
    ACERO,
    DRAC,
    SINIESTRE,
    FANTASMA,
    ROCA,
    VERI,
    INSECTE,
    HADA,
    GEL
}