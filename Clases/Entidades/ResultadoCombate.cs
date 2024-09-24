using System;
namespace Clases
{
    public class ResultadoCombate
    {
        public DateTime fechaCombate { get; set; }
        public string nombreGanador { get; set; }
        public string nombrePerdedor { get; set; }

        public DateTime Fecha { get; set; }
        public string Ganador { get; set; }
        public string Perdedor { get; set; }

        public ResultadoCombate(string nombreGanador, string nombrePerdedor, DateTime fecha)
        {
            this.nombreGanador = nombreGanador;
            this.nombrePerdedor = nombrePerdedor;
            this.fechaCombate = fecha;
        }
    }
}

