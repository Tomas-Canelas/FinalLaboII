namespace Clases
{

    public class Combate
    {
        private static Random random;
        private IJugador jugadorAtacante;
        private IJugador jugadorAtacado;

        static Combate()
        {
            random = new Random();
        }

        public Combate(IJugador jugador1, IJugador jugador2)
        {
            jugadorAtacante = SeleccionarPrimerAtacante(jugador1, jugador2);
            jugadorAtacado = jugadorAtacante == jugador1 ? jugador2 : jugador1;
        }

        public event Action<IJugador, IJugador> RondaIniciada;
        public event Action<IJugador> CombateFinalizado;

        public static IJugador SeleccionarJugadorAleatoriamente(IJugador jugador1, IJugador jugador2)
        {
            return random.Next(2) == 0 ? jugador1 : jugador2;
        }

        public static IJugador SeleccionarPrimerAtacante(IJugador jugador1, IJugador jugador2)
        {
            if (jugador1.Nivel != jugador2.Nivel)
            {
                return jugador1.Nivel < jugador2.Nivel ? jugador1 : jugador2;
            }
            return SeleccionarJugadorAleatoriamente(jugador1, jugador2);
        }

        public void IniciarRonda()
        {
            RondaIniciada?.Invoke(jugadorAtacante, jugadorAtacado);

            // Genera un ataque del jugador atacante
            int puntosAtaque = jugadorAtacante.Atacar();
            jugadorAtacado.RecibirAtaque(puntosAtaque);

            IJugador ganador = EvaluarGanador();
            if (ganador != null)
            {
                CombateFinalizado?.Invoke(ganador);
            }
        }

        public IJugador EvaluarGanador()
        {
            if (jugadorAtacado.PuntosDeVida == 0)
            {
                return jugadorAtacante;
            }
            // Intercambiar roles
            var temp = jugadorAtacante;
            jugadorAtacante = jugadorAtacado;
            jugadorAtacado = temp;

            return null;
        }

        public void Combatir()
        {
            while (true)
            {
                IniciarRonda();
                if (EvaluarGanador() != null) break;
            }
        }

        public Task IniciarCombate()
        {
            return Task.Run(() => Combatir());
        }
    }
}

