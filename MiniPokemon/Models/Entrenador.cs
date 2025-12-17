using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Entrenador
{

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int IdEntrenador { get; set; }

    [Required]
    [StringLength(50)]
    public string Nom { get; set; } = null!;

	[Required]
    [StringLength(100)]
    public string Cognoms { get; set; } = null!;

	[Range(0, int.MaxValue)]
    public int Medalles { get; set; } = 0;

    [Range(0, int.MaxValue)]
    public int DinersPokedollars { get; set; } = 0;

	public ICollection<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

}
