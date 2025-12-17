namespace MiniPokemon.Data
{
    public class MovimentService
    {

        private MiniPokemonContext _context;

        public MovimentService(MiniPokemonContext ctx)
        {
            _context = ctx;

        }

        public double CalcularEfectivitat(TipusPokemon atacant, TipusPokemon defensor)
        {

            switch (atacant, defensor)
            {
                case (TipusPokemon.ELECTRIC, TipusPokemon.AIGUA):
                    return 2.0;
                case (TipusPokemon.FOC, TipusPokemon.PLANTA):
                    return 2.0;
                case (TipusPokemon.AIGUA, TipusPokemon.FOC):
                    return 2.0;
                case (TipusPokemon.PLANTA, TipusPokemon.FOC):
                    return 0.5;
                case (TipusPokemon.FOC, TipusPokemon.AIGUA):
                    return 0.5;
                default:
                    return 1.0;
            }
        }
    }
}
