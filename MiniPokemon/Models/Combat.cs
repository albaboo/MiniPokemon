using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Combat {

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int IdCombat { get; set; }

	[Required]
	public int? IdEntrenador1 { get; set; }

	[Required]
	public int? IdEntrenador2 { get; set; }

	public int? IdGuanyador { get; set; } = null;

	[Range(1, int.MaxValue)]
	public int Torn { get; set; } = 1;

	[EnumDataType(typeof(EstatCombat))]
	public EstatCombat EstatCombat { get; set; } = EstatCombat.EN_CURS;

	[NotMapped]
	[EnumDataType(typeof(TipusPokemon))]
	public TipusPokemon TipusPokemon { get; set; }


	[Required]
	[StringLength(50)]
	public string Tipus
	{
		get => TipusPokemon.ToString();
		set => TipusPokemon = (TipusPokemon)Enum.Parse(typeof(TipusPokemon), value);
	}

	[Required]
	public DateTime DataInici { get; set; }

	public DateTime? DataFi { get; set; } = null;

}

public enum EstatCombat
{
	EN_CURS,
	FINALITZAT
}