using System;
using MySql.Data.MySqlClient;


namespace SistemaNH.Models.DAO
{
    public class Conexion
    {
        private static Conexion instance;
        private readonly MySqlConnection _cnn;

        private Conexion() {
            var url = "server=localhost;port=3306;database=sisnh_bd;user=root;password=1234";
            _cnn = new MySqlConnection(url);
            try {
                _cnn.Open();
                Console.WriteLine("Conexión valida");
            } catch(Exception ex) {
                Console.WriteLine("Algo fallo!");
                Console.WriteLine(ex.ToString());
                _cnn.Close();
            }
        }

        public static Conexion GetInstance() {
            if (instance == null)
                instance = new Conexion();
            return instance;
        }

        public MySqlConnection GetConnection() {
            return _cnn;
        }
    }
}
