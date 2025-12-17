namespace MiniPokemon.Data
{
    public class CombatService
    {
        private MiniPokemonContext _context;

        public CombatService(MiniPokemonContext ctx)
        {
            _context = ctx;

        }

        public Combat? IniciarCombat(int idEntrenador1, int idEntrenador2)
        {
            EntrenadorService _entrenador = new EntrenadorService(_context);
            var equip1 = _entrenador.EquipActiu(idEntrenador1);
            var equip2 = _entrenador.EquipActiu(idEntrenador2);

            if (!equip1.Any() || !equip2.Any()) return null;

            var combat = new Combat
            {
                Entrenador1 = _context.Entrenadors.Find(idEntrenador1),
                Entrenador2 = _context.Entrenadors.Find(idEntrenador2),
                Torn = new Random().Next(1, 3),
                EstatCombat = EstatCombat.EN_CURS,
                DataInici = DateTime.Now,
                DataFi = null,
                IdGuanyador = null
            };

            _context.Combats.Add(combat);
            _context.SaveChanges();
            return combat;
        }

        public string UsarMoviment(int idCombat, int idPokemonAtacant, int idPokemonDefensor, int idMoviment)
        {
            var pokemonAtacant = _context.Pokemons.Find(idPokemonAtacant);
            var pokemonDefensor = _context.Pokemons.Find(idPokemonDefensor);
            var moviment = _context.Moviments.Find(idMoviment);


            MovimentService _moviment = new MovimentService(_context);
            PokemonService _pokemon = new PokemonService(_context);

            if (pokemonAtacant == null || pokemonDefensor == null || moviment == null)
                return "Error en el moviment";

            if (!pokemonAtacant.Moviments.Contains(moviment))
                return "El Pokémon no coneix aquest moviment";

            if (pokemonAtacant.EstaDebilitat || pokemonDefensor.EstaDebilitat)
                return "Un dels Pokémon està debilitat";

            Random rnd = new Random();

            if (rnd.Next(0, 101) > moviment.Precisio)
                return "L'atac ha fallat!";

            double danyBase = (moviment.Potencia * pokemonAtacant.Nivell) / 10.0;
            double efectivitat = _moviment.CalcularEfectivitat(moviment.Tipus, pokemonDefensor.Tipus);
            int danyFinal = (int)Math.Round(danyBase * efectivitat);

            _pokemon.RebreDany(idPokemonDefensor, danyFinal);

            string efecte = efectivitat > 1 ? " És súper efectiu" : "";
            string resultat = $"{pokemonAtacant.Nom} usa {moviment.Nom}. Causa {danyFinal} de dany {efecte}";

            if (pokemonDefensor.EstaDebilitat)
            {
                int exp = pokemonDefensor.Nivell * 50;
                _pokemon.GuanyarExperiencia(idPokemonAtacant, exp);
            }

            _context.SaveChanges();
            return resultat;
        }

        public bool CanviarPokemon(int idCombat, int idEntrenador, int idPokemonNou)
        {
            var combat = _context.Combats.Find(idCombat);
            var pokemon = _context.Pokemons.Find(idPokemonNou);

            if (combat == null || pokemon == null)
                return false;

            if (pokemon.EntrenadorId != idEntrenador || pokemon.EstaDebilitat)
                return false;

            if (combat.IdEntrenador1 == idEntrenador)
                combat.IdPokemon1Actiu = idPokemonNou;
            else if (combat.IdEntrenador2 == idEntrenador)
                combat.IdPokemon2Actiu = idPokemonNou;
            else return false;

            _context.SaveChanges();
            return true;
        }

        public bool ComprovarFiCombat(int idCombat)
        {

            EntrenadorService _entrenador = new EntrenadorService(_context);

            var combat = _context.Combats.Find(idCombat);
            if (combat == null) return false;

            var equip1 = _entrenador.EquipActiu(combat.IdEntrenador1);
            var equip2 = _entrenador.EquipActiu(combat.IdEntrenador2);

            if (!equip1.Any())
            {
                AssignarGuanyador(idCombat, combat.IdEntrenador2);
                return true;
            }
            else if (!equip2.Any())
            {
                AssignarGuanyador(idCombat, combat.IdEntrenador1);
                return true;
            }

            return false;
        }

        public void AssignarGuanyador(int idCombat, int idEntrenador)
        {
            var combat = _context.Combats.Find(idCombat);
            var perdedorId = (combat.IdEntrenador1 == idEntrenador) ? combat.IdEntrenador2 : combat.IdEntrenador1;

            combat.IdGuanyador = idEntrenador;
            combat.EstatCombat = EstatCombat.FINALITZAT;
            combat.DataFi = DateTime.Now;

            var guanyador = _context.Entrenadors.Find(idEntrenador);
            var perdedor = _context.Entrenadors.Find(perdedorId);

            guanyador.Medalles += 1;

            if (perdedor != null && perdedor.Pokemons.Any())
            {
                double nivellMitja = perdedor.Pokemons.Average(p => p.Nivell);
                guanyador.DinersPokedollars += (int)(500 * nivellMitja);
            }

            _context.SaveChanges();
        }

		public void PassarTorn(int idCombat)
		{
			var combat = _context.Combats.Find(idCombat);
			if (combat == null) 
                return;

			combat.Torn = combat.Torn == 1 ? 2 : 1;
			_context.SaveChanges();
		}
	}
}
