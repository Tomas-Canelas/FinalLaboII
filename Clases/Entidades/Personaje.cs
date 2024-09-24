namespace Clases
{
    using System;
    public abstract class Personaje : IJugador
    {
        private static Random random;

        public decimal Id { get; private set; }
        public short Nivel { get; set; }
        public int PuntosDeVida { get; set; }
        public int PuntosDeDefensa { get; set; }
        public string Titulo { get; set; }

        static Personaje()
        {
            random = new Random();
        }

        public Personaje(decimal id, string nombre, short nivel = 1)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser nulo ni estar en blanco.");
            }

            this.Id = id;
            this.Titulo = nombre.Trim();

            const short maxNivel = 100;
            const short minNivel = 1;

            if (nivel < minNivel || nivel > maxNivel)
            {
                throw new BusinessException($"El nivel debe estar entre {minNivel} y {maxNivel}.");
            }

            this.Nivel = nivel;
            this.PuntosDeDefensa = 100;
            this.PuntosDeVida = 500 * Nivel; // 500 puntos por cada nivel
        }

        public abstract void AplicarBeneficiosDeClase();

        public event Action<Personaje, int> AtaqueLanzado;
        public event Action<Personaje, int> AtaqueRecibido;

        public int Atacar()
        {
            int porcentaje = random.Next(10, 101); // 10% a 100%
            int puntosDeAtaque = (PuntosDeVida / 100) * porcentaje;

            System.Threading.Thread.Sleep(random.Next(1000, 5001)); // Entre 1 y 5 segundos

            AtaqueLanzado?.Invoke(this, puntosDeAtaque);
            return puntosDeAtaque;
        }

        public void RecibirAtaque(int puntosDeAtaque)
        {
            int porcentaje = random.Next(10, 101); // 10% a 100%
            int puntosDefensaRecibidos = (PuntosDeDefensa / 100) * porcentaje;

            int puntosEfectivos = puntosDeAtaque - puntosDefensaRecibidos;
            if (puntosEfectivos > 0)
            {
                PuntosDeVida -= puntosEfectivos;
                if (PuntosDeVida < 0)
                {
                    PuntosDeVida = 0;
                }
            }

            AtaqueRecibido?.Invoke(this, puntosEfectivos > 0 ? puntosEfectivos : 0);
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Titulo) ? $"{Id}" : $"{Titulo}, {Id}";
        }

        public override bool Equals(object obj)
        {
            return obj is Personaje otro && Id == otro.Id;
        }

        public override int GetHashCode()
        {
            return (int)Id;
        }

        public static bool operator ==(Personaje p1, Personaje p2)
        {
            return p1?.Id == p2?.Id;
        }

        public static bool operator !=(Personaje p1, Personaje p2)
        {
            return !(p1 == p2);
        }
    }
}