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
	}
}
