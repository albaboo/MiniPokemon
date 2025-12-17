
using MiniPokemon.Data;

namespace MiniPokemon
{
	class Program
	{

		static void Main(string[] args)
		{
			using (var ctx = new MiniPokemonContext())
			{

				var entrenador1 = new Entrenador
				{
					Nom = "Ash",
					Cognoms = "Ketchum",
					Medalles = 8,
					DinersPokedollars = 1500
				};

				var entrenador2 = new Entrenador
				{
					Nom = "Misty",
					Cognoms = "Waterflower",
					Medalles = 5,
					DinersPokedollars = 1200
				};

				var entrenador3 = new Entrenador
				{
					Nom = "Brock",
					Cognoms = "Harrison",
					Medalles = 7,
					DinersPokedollars = 1300
				};

				var entrenador4 = new Entrenador
				{
					Nom = "Gary",
					Cognoms = "Oak",
					Medalles = 6,
					DinersPokedollars = 1400
				};

				var entrenador5 = new Entrenador
				{
					Nom = "May",
					Cognoms = "Maple",
					Medalles = 4,
					DinersPokedollars = 1100
				};

				var entrenador6 = new Entrenador
				{
					Nom = "Dawn",
					Cognoms = "Breeze",
					Medalles = 3,
					DinersPokedollars = 1000
				};

				var entrenador7 = new Entrenador
				{
					Nom = "Cynthia",
					Cognoms = "Smith",
					Medalles = 9,
					DinersPokedollars = 1600
				};

				var entrenador8 = new Entrenador
				{
					Nom = "Serena",
					Cognoms = "Rose",
					Medalles = 2,
					DinersPokedollars = 900
				};

				var entrenador9 = new Entrenador
				{
					Nom = "Lance",
					Cognoms = "Dragon",
					Medalles = 10,
					DinersPokedollars = 1700
				};

				var entrenador10 = new Entrenador
				{
					Nom = "Red",
					Cognoms = "Hero",
					Medalles = 11,
					DinersPokedollars = 1800
				};

				ctx.Entrenadors.AddRange([entrenador1, entrenador2, entrenador3, entrenador4, entrenador5,
					entrenador6, entrenador7, entrenador8, entrenador9, entrenador10]);

				ctx.SaveChanges();

				var Pokemon1 = new Pokemon
				{
					Nom = "Pichu",
					Tipus = TipusPokemon.ELECTRIC,
					Nivell = 1,
					Entrenador = entrenador1,
					NivellEvolucio = 5
				};

				var Evolution1 = new Pokemon
				{
					Nom = "Pikachu",
					Tipus = TipusPokemon.ELECTRIC,
					Nivell = 5,
					NivellEvolucio = 20
				};

				var Evolution2 = new Pokemon
				{
					Nom = "Raichu",
					Tipus = TipusPokemon.ELECTRIC,
					Nivell = 20
				};

				Pokemon1.EvolucioSeguent.Add(Evolution1);
				Evolution1.EvolucioPrevia.Add(Pokemon1);
				Evolution1.EvolucioSeguent.Add(Evolution2);
				Evolution2.EvolucioPrevia.Add(Evolution1);

				var Pokemon2 = new Pokemon
				{
					Nom = "Bulbasaur",
					Tipus = TipusPokemon.PLANTA,
					Nivell = 4,
					Entrenador = entrenador2,
					NivellEvolucio = 16
				};

				var Evolution3 = new Pokemon
				{
					Nom = "Ivysaur",
					Tipus = TipusPokemon.PLANTA,
					Nivell = 16,
					NivellEvolucio = 32
				};

				var Evolution4 = new Pokemon
				{
					Nom = "Venusaur",
					Tipus = TipusPokemon.PLANTA,
					Nivell = 32
				};

				Pokemon2.EvolucioSeguent.Add(Evolution3);
				Evolution3.EvolucioPrevia.Add(Pokemon2);
				Evolution3.EvolucioSeguent.Add(Evolution4);
				Evolution4.EvolucioPrevia.Add(Evolution3);

				var Pokemon3 = new Pokemon
				{
					Nom = "Charmander",
					Tipus = TipusPokemon.FOC,
					Nivell = 6,
					Entrenador = entrenador3,
					NivellEvolucio = 16
				};

				var Evolution5 = new Pokemon
				{
					Nom = "Charmeleon",
					Tipus = TipusPokemon.FOC,
					Nivell = 16,
					NivellEvolucio = 36
				};

				var Evolution6 = new Pokemon
				{
					Nom = "Charizard",
					Tipus = TipusPokemon.FOC,
					Nivell = 36
				};

				Pokemon3.EvolucioSeguent.Add(Evolution5);
				Evolution5.EvolucioPrevia.Add(Pokemon3);
				Evolution5.EvolucioSeguent.Add(Evolution6);
				Evolution6.EvolucioPrevia.Add(Evolution5);

				var Pokemon4 = new Pokemon
				{
					Nom = "Squirtle",
					Tipus = TipusPokemon.AIGUA,
					Nivell = 8,
					Entrenador = entrenador4,
					NivellEvolucio = 16
				};

				var Evolution7 = new Pokemon
				{
					Nom = "Wartortle",
					Tipus = TipusPokemon.AIGUA,
					Nivell = 16,
					NivellEvolucio = 36
				};

				var Evolution8 = new Pokemon
				{
					Nom = "Blastoise",
					Tipus = TipusPokemon.AIGUA,
					Nivell = 36
				};

				Pokemon4.EvolucioSeguent.Add(Evolution7);
				Evolution7.EvolucioPrevia.Add(Pokemon4);
				Evolution7.EvolucioSeguent.Add(Evolution8);
				Evolution8.EvolucioPrevia.Add(Evolution7);

				var Pokemon5 = new Pokemon
				{
					Nom = "Igglybuff",
					Tipus = TipusPokemon.HADA,
					Nivell = 7,
					Entrenador = entrenador5,
					NivellEvolucio = 14
				};

				var Evolution9 = new Pokemon
				{
					Nom = "Jigglypuff",
					Tipus = TipusPokemon.HADA,
					Nivell = 14,
					NivellEvolucio = 30
				};

				var Evolution10 = new Pokemon
				{
					Nom = "Wigglytuff",
					Tipus = TipusPokemon.HADA,
					Nivell = 30
				};

				Pokemon5.EvolucioSeguent.Add(Evolution9);
				Evolution9.EvolucioPrevia.Add(Pokemon5);
				Evolution9.EvolucioPrevia.Add(Evolution10);
				Evolution10.EvolucioSeguent.Add(Evolution9);

				var Pokemon6 = new Pokemon
				{
					Nom = "Psyduck",
					Tipus = TipusPokemon.AIGUA,
					Nivell = 10,
					Entrenador = entrenador6,
					NivellEvolucio = 33
				};

				var Evolution11 = new Pokemon
				{
					Nom = "Golduck",
					Tipus = TipusPokemon.AIGUA,
					Nivell = 33
				};

				Pokemon6.EvolucioSeguent.Add(Evolution11);
				Evolution11.EvolucioPrevia.Add(Pokemon6);

				var Pokemon7 = new Pokemon
				{
					Nom = "Gastly",
					Tipus = TipusPokemon.FANTASMA,
					Nivell = 12,
					Entrenador = entrenador7,
					NivellEvolucio = 25
				};

				var Evolution12 = new Pokemon
				{
					Nom = "Haunter",
					Tipus = TipusPokemon.FANTASMA,
					Nivell = 25,
					NivellEvolucio = 30
				};

				var Evolution13 = new Pokemon
				{
					Nom = "Gengar",
					Tipus = TipusPokemon.FANTASMA,
					Nivell = 30
				};

				Pokemon7.EvolucioSeguent.Add(Evolution12);
				Evolution12.EvolucioPrevia.Add(Pokemon7);
				Evolution12.EvolucioSeguent.Add(Evolution13);
				Evolution13.EvolucioPrevia.Add(Evolution12);

				var Pokemon8 = new Pokemon
				{
					Nom = "Eevee",
					Tipus = TipusPokemon.NORMAL,
					Nivell = 11,
					Entrenador = entrenador8,
					NivellEvolucio = 16
				};

				var Evolution14 = new Pokemon
				{
					Nom = "Vaporeon",
					Tipus = TipusPokemon.AIGUA,
					Nivell = 16
				};

				var Evolution15 = new Pokemon
				{
					Nom = "Jolteon",
					Tipus = TipusPokemon.ELECTRIC,
					Nivell = 16
				};

				var Evolution16 = new Pokemon
				{
					Nom = "Flareon",
					Tipus = TipusPokemon.FOC,
					Nivell = 16
				};

				var Evolution17 = new Pokemon
				{
					Nom = "Espeon",
					Tipus = TipusPokemon.PSÍQUIC,
					Nivell = 16
				};

				var Evolution18 = new Pokemon
				{
					Nom = "Umbreon",
					Tipus = TipusPokemon.SINIESTRE,
					Nivell = 16
				};

				var Evolution19 = new Pokemon
				{
					Nom = "Leafeon",
					Tipus = TipusPokemon.PLANTA,
					Nivell = 16
				};

				var Evolution20 = new Pokemon
				{
					Nom = "Glaceon",
					Tipus = TipusPokemon.GEL,
					Nivell = 16
				};

				var Evolution21 = new Pokemon
				{
					Nom = "Sylveon",
					Tipus = TipusPokemon.HADA,
					Nivell = 16
				};

				Pokemon8.EvolucioSeguent.Add(Evolution14);
				Pokemon8.EvolucioSeguent.Add(Evolution15);
				Pokemon8.EvolucioSeguent.Add(Evolution16);
				Pokemon8.EvolucioSeguent.Add(Evolution17);
				Pokemon8.EvolucioSeguent.Add(Evolution18);
				Pokemon8.EvolucioSeguent.Add(Evolution19);
				Pokemon8.EvolucioSeguent.Add(Evolution20);
				Pokemon8.EvolucioSeguent.Add(Evolution21);
				Evolution14.EvolucioPrevia.Add(Pokemon8);
				Evolution15.EvolucioPrevia.Add(Pokemon8);
				Evolution16.EvolucioPrevia.Add(Pokemon8);
				Evolution17.EvolucioPrevia.Add(Pokemon8);
				Evolution18.EvolucioPrevia.Add(Pokemon8);
				Evolution19.EvolucioPrevia.Add(Pokemon8);
				Evolution20.EvolucioPrevia.Add(Pokemon8);
				Evolution21.EvolucioPrevia.Add(Pokemon8);

				var Pokemon9 = new Pokemon
				{
					Nom = "Dratini",
					Tipus = TipusPokemon.DRAC,
					Nivell = 20,
					Entrenador = entrenador9,
					NivellEvolucio = 55
				};


				var Evolution22 = new Pokemon
				{
					Nom = "Dragonair",
					Tipus = TipusPokemon.DRAC,
					Nivell = 55,
					NivellEvolucio = 60
				};

				var Evolution23 = new Pokemon
				{
					Nom = "Dragonite",
					Tipus = TipusPokemon.DRAC,
					Nivell = 60
				};

				Pokemon9.EvolucioSeguent.Add(Evolution22);
				Evolution22.EvolucioPrevia.Add(Pokemon9);
				Evolution22.EvolucioSeguent.Add(Evolution23);
				Evolution23.EvolucioPrevia.Add(Evolution22);

				var Pokemon10 = new Pokemon
				{
					Nom = "Mewtwo",
					Tipus = TipusPokemon.PSÍQUIC,
					Nivell = 70,
					Entrenador = entrenador10
				};

				ctx.Pokemons.AddRange([
					Pokemon1, Pokemon2, Pokemon3, Pokemon4, Pokemon5, Pokemon6, 
					Pokemon7, Pokemon8, Pokemon9, Pokemon10, Evolution1, 
					Evolution2, Evolution3, Evolution4, Evolution5, Evolution6, 
					Evolution7, Evolution8, Evolution9, Evolution10, Evolution11, 
					Evolution12, Evolution13, Evolution14, Evolution15, Evolution16,
					Evolution17, Evolution18, Evolution19, Evolution20, Evolution21
					]);

				ctx.SaveChanges();

				EntrenadorService _entrenador = new EntrenadorService(ctx);
				PokemonService _pokemon = new PokemonService(ctx);

				Console.WriteLine("Adding Pokemons to Trainers' active teams:");
				Console.Write("Adding Pikachu to Ash: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador1.IdEntrenador, Pokemon1));
				Console.Write("Adding Bulbasaur to Ash: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador1.IdEntrenador, Pokemon2));
				Console.Write("Adding Charmander to Ash: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador1.IdEntrenador, Pokemon3));
				Console.Write("Adding Squirtle to Ash: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador1.IdEntrenador, Pokemon4));
				Console.Write("Adding Jigglypuff to Ash: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador1.IdEntrenador, Pokemon5));
				Console.Write("Adding Psyduck to Ash: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador1.IdEntrenador, Pokemon6));
				Console.Write("Adding Gengar to Ash: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador1.IdEntrenador, Pokemon7));
				Console.Write("Adding Eevee to Misty: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador2.IdEntrenador, Pokemon8));
				Console.Write("Adding Dragonite to Brock: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador3.IdEntrenador, Pokemon9));
				Console.Write("Adding Mewtwo to Gary: ");
				Console.WriteLine(_entrenador.AddPokemon(entrenador4.IdEntrenador, Pokemon10));
				Console.WriteLine("Current active team of Ash:");
				foreach (var item in _entrenador.EquipActiu(entrenador1.IdEntrenador))
				{
					Console.WriteLine(item.Nom + " - HP: " + item.PuntsVida + " - Fainted: " + item.EstaDebilitat);
				}
				Console.WriteLine("Pikachu gains 500 experience points:");
				_pokemon.GuanyarExperiencia(Pokemon1.IdPokemon, 500);
				Console.Write("Pikachu's experience: ");
				Console.WriteLine(Pokemon1.Experiencia);
				Console.Write("Pikachu's level: ");
				Console.WriteLine(Pokemon1.Nivell);
				Console.WriteLine("Current active team of Ash:");
				foreach (var item in _entrenador.EquipActiu(entrenador1.IdEntrenador))
				{
					Console.WriteLine(item.Nom + " - HP: " + item.PuntsVida + " - Fainted: " + item.EstaDebilitat);
				}
				Console.WriteLine("Bulbasaur takes 30 damage:");
				_pokemon.RebreDany(Pokemon2.IdPokemon, 30);
				Console.Write("Bulbasaur's HP: ");
				Console.WriteLine(Pokemon2.PuntsVida);
				Console.Write("Is Bulbasaur fainted? ");
				Console.WriteLine(Pokemon2.EstaDebilitat);
				Console.WriteLine("Bulbasaur takes damage equal to its current HP:");
				_pokemon.RebreDany(Pokemon2.IdPokemon, Pokemon2.PuntsVida);
				Console.Write("Bulbasaur's HP: ");
				Console.WriteLine(Pokemon2.PuntsVida);
				Console.Write("Is Bulbasaur fainted? ");
				Console.WriteLine(Pokemon2.EstaDebilitat);
				Console.WriteLine("Current active team of Ash:");
				foreach(var item in _entrenador.EquipActiu(entrenador1.IdEntrenador))
				{
					Console.WriteLine(item.Nom + " - HP: " + item.PuntsVida + " - Fainted: " + item.EstaDebilitat);
				}
				_pokemon.Curar(Pokemon2.IdPokemon);
				Console.WriteLine("Bulbasaur is healed:");
				Console.Write("Bulbasaur's HP: ");
				Console.WriteLine(Pokemon2.PuntsVida);
				Console.Write("Is Bulbasaur fainted? ");
				Console.WriteLine(Pokemon2.EstaDebilitat);
				Console.WriteLine("Current active team of Ash:");
				foreach (var item in _entrenador.EquipActiu(entrenador1.IdEntrenador))
				{
					Console.WriteLine(item.Nom + " - HP: " + item.PuntsVida + " - Fainted: " + item.EstaDebilitat);
				}

			}
		}

	}

}
