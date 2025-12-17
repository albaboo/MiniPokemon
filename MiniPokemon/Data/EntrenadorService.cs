using System.Linq;

namespace MiniPokemon.Data
{
	public class EntrenadorService
	{

		private MiniPokemonContext _context;

		public EntrenadorService(MiniPokemonContext ctx)
		{
			_context = ctx;
		}

		public bool AddPokemon(int? idEntrenador, Pokemon Pokemon)
		{
			if (idEntrenador == null)
			{
				return false;
			}
			var Entrenador = _context.Entrenadors.Find(idEntrenador);
			if (Entrenador == null || Entrenador.Pokemons.Count() >= 6)
			{
				return false;
			}
			Pokemon.EntrenadorId = idEntrenador;
			Pokemon.Entrenador = Entrenador;

			Entrenador.Pokemons.Add(Pokemon);
			_context.SaveChanges();
			return true;
		}

		public bool RemovePokemon(int? idEntrenador, Pokemon Pokemon)
		{
			if (idEntrenador == null)
			{
				return false;
			}
			var Entrenador = _context.Entrenadors.Find(idEntrenador);
			if (Entrenador == null || !Entrenador.Pokemons.Contains(Pokemon))
			{
				return false;
			}
			Entrenador.Pokemons.Remove(Pokemon);
			Pokemon.EntrenadorId = null;
			Pokemon.Entrenador = null;
			_context.SaveChanges();
			return true;
		}

		public List<Pokemon> EquipActiu(int idEntrenador)
		{
			var Entrenador = _context.Entrenadors.Find(idEntrenador);
			if (Entrenador == null)
			{
				return [];
			}
			return Entrenador.Pokemons.Where(p => !p.EstaDebilitat).ToList();
		}

		public Pokemon? PokemonActiu(int idEntrenador, int idCombat)
		{
			var combat = _context.Combats.Find(idCombat);
			if (combat == null) 
				return null;

			if (combat.IdEntrenador1 == idEntrenador)
				return _context.Pokemons.Find(combat.IdPokemon1Actiu);
			else if (combat.IdEntrenador2 == idEntrenador)
				return _context.Pokemons.Find(combat.IdPokemon2Actiu);

			return null;
		}

	}

}
