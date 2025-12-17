using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPokemon.Data
{
    public class PokemonService
    {
		private MiniPokemonContext _context;

		public PokemonService(MiniPokemonContext ctx)
		{
			_context = ctx;

		}

		public void GuanyarExperiencia(int idPokemon, int exp)
		{
			var pokemon = _context.Pokemons.Find(idPokemon);
			if (pokemon != null)
			{
				pokemon.Experiencia += exp;
				_context.SaveChanges();
				if(pokemon.Nivell >= pokemon.NivellEvolucio)
				{
					Evolucionar(idPokemon, pokemon.EntrenadorId);
				}
			}

		}

		public void Evolucionar(int idPokemon, int? idEntrenador)
		{
			if (idEntrenador == null)
			{
				return;
			}
			var pokemon = _context.Pokemons.Find(idPokemon);
			if (pokemon != null)
			{
				var entrenador = _context.Entrenadors.Find(idEntrenador);
				if (entrenador != null)
				{
					foreach (var evolucio in pokemon.EvolucioSeguent)
					{
						if (pokemon.Nivell >= pokemon.NivellEvolucio)
						{
							EntrenadorService _entrenador = new EntrenadorService(_context);
							_entrenador.RemovePokemon(idEntrenador, pokemon);
							_entrenador.AddPokemon(idEntrenador, evolucio);
							_context.Pokemons.Remove(pokemon);
							_context.SaveChanges();
							break;
						}
					}
				}
			}
		}

		public void RebreDany(int idPokemon, int dany)
		{ 			
			var pokemon = _context.Pokemons.Find(idPokemon);
			if (pokemon != null)
			{
				pokemon.PuntsVida -= dany;
				_context.SaveChanges();
			}
		}

		public void Curar(int idPokemon)
		{
			var pokemon = _context.Pokemons.Find(idPokemon);
			if (pokemon != null)
			{
				pokemon.PuntsVida = pokemon.PuntsVidaMaxims;
				_context.SaveChanges();
			}
		}

		public bool AprendreMoviment(int idPokemon, int idMoviment)
		{
			var pokemon = _context.Pokemons
				.Find(idPokemon);

			if (pokemon == null) return false;
			if (pokemon.Moviments.Count >= 4) return false;

			var moviment = _context.Moviments
				.Find(idMoviment);

			if (moviment == null) return false;

			pokemon.Moviments.Add(moviment);

			_context.SaveChanges();
			return true;
		}

		public bool OblidarMoviment(int idPokemon, int idMoviment)
		{
			var pokemon = _context.Pokemons
				.Find(idPokemon);

			if (pokemon == null) return false;

			var moviment = _context.Moviments
				.Find(idMoviment);

			if (moviment == null) return false;

			pokemon.Moviments.Remove(moviment);

			_context.SaveChanges();
			return true;
		}

		public bool PotEvolucionar(int idPokemon)
		{
			var p = _context.Pokemons.Find(idPokemon);
			return p != null &&
				   p.IdEvolucioSeguent != null &&
				   p.Nivell >= p.NivellEvolucio;
		}

		public List<Pokemon> CadenaEvolutiva(int idPokemon)
		{
			var actual = _context.Pokemons.Find(idPokemon);

			var cadena = new List<Pokemon>();

			foreach (var pokemon in actual.EvolucioPrevia)
			{
				cadena.Add(pokemon);
			}

			cadena.Add(actual);

			foreach (var pokemon in actual.EvolucioSeguent)
			{
				cadena.Add(pokemon);
			}

			return cadena;
		}
	}
}
