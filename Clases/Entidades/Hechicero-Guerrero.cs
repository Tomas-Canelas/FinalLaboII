namespace Clases
{
    public class Guerrero : Personaje
    {
        public Guerrero(decimal id, string nombre, short nivel = 1)
            : base(id, nombre, nivel)
        {
            // Inicialización adicional si es necesario
        }

        public override void AplicarBeneficiosDeClase()
        {
            // Aumentar los puntos de defensa en un 10%
            int bonificacionDefensa = (int)(PuntosDeDefensa * 0.1m);
            PuntosDeDefensa += bonificacionDefensa;
        }
    }

    public class Hechicero : Personaje
    {
        public Hechicero(decimal id, string nombre, short nivel = 1)
            : base(id, nombre, nivel)
        {
            // Inicialización adicional si es necesario
        }

        public override void AplicarBeneficiosDeClase()
        {
            // Aumentar los puntos de vida en un 10%
            int bonificacionVida = (int)(PuntosDeVida * 0.1m);
            PuntosDeVida += bonificacionVida;
        }
    }
}