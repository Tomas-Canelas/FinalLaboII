namespace Clases
{
    using MySql.Data.MySqlClient;
    public static class PersonajeDAO
    {
        private static string connectionString = "Server=localhost;Database=combate_db;User ID=tu_usuario;Password=;";

        public static Personaje ObtenerPersonajePorId(int id)
        {
            Personaje personaje = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, nombre, nivel, clase FROM Personajes WHERE id = @id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Suponiendo que la columna 'clase' tiene 1 para Guerrero y 2 para Hechicero
                            int clase = reader.GetInt32("clase");
                            string nombre = reader.GetString("nombre").Trim();
                            short nivel = reader.GetInt16("nivel");

                            if (clase == 1)
                            {
                                personaje = new Guerrero(id, nombre, nivel);
                            }
                            else if (clase == 2)
                            {
                                personaje = new Hechicero(id, nombre, nivel);
                            }
                        }
                    }
                }
            }

            return personaje; // Retorna null si no se encuentra el personaje
        }
    }
}