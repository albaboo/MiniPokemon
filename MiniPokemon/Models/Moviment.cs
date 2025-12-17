using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Moviment
{

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int IdMoviment { get; set; }

	[Required]
	[StringLength(50)]
	public string Nom { get; set; }

	[Required]
	[EnumDataType(typeof(TipusPokemon))]
	public TipusPokemon Tipus { get; set; }

	[Range(10, 150)]
	public int Potencia { get; set; }

	[Range(50, 100)]
	public int Precisio { get; set; }
}
