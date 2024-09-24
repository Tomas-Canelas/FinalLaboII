namespace Clases
{ 
    public interface IJugador
    {
        short Nivel { get; }
        int PuntosDeVida { get; }
        int Atacar();
        void RecibirAtaque(int puntosDeDefensa);
    }
}

