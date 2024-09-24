using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Aleatorio
{
    private static Random random = new Random();

    // Método que retorna de forma aleatoria "Cara" o "Ceca"
    public static LadosMoneda TirarUnaMoneda()
    {
        int valor = random.Next(1, 3); // Genera un número entre 1 y 2
        return (LadosMoneda)valor; // Retorna el valor correspondiente del enumerado
    }
}

