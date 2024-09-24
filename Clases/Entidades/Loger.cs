using System;
using System.IO;
namespace Clases
{
    public class Logger
    {
        private string logPath;

        public Logger(string ruta)
        {
            logPath = ruta;
        }

        public void GuardarLog(string mensaje)
        {
            try
            {
                // Agregar el mensaje al archivo, creando uno si no existe
                using (StreamWriter sw = new StreamWriter(logPath, true))
                {
                    sw.WriteLine($"{DateTime.Now}: {mensaje}");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al guardar el log
                Console.WriteLine($"Error al guardar el log: {ex.Message}");
            }
        }
    }
}
