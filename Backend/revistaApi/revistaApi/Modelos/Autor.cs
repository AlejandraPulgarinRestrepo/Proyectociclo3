using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace revistaApi.Modelos
{
    public class Autor
    {
        string cedula;
        string nombre_uno;
        string nombre_dos;
        string apellido_uno;
        string apellido_dos;
        string clave;
        string correo_electronico;
        int edad;
        NpgsqlConnection cone;

        public Autor(string cedula, string nombre_uno, string nombre_dos, string apellido_uno, string apellido_dos, string clave, string correo_electronico, int edad)
        {
            this.cedula = cedula;
            this.nombre_uno = nombre_uno;
            this.nombre_dos = nombre_dos;
            this.apellido_uno = apellido_uno;
            this.apellido_dos = apellido_dos;
            this.clave = clave;
            this.correo_electronico = correo_electronico;
            this.edad = edad;
        }

        public void conectar()//Metodo para conectarme a la base de datos
        {
            this.cone = new NpgsqlConnection("Server= 127.0.0.1;User Id=user40;Password=123456;Database=Revista ");
            this.cone.Open();
        }

        public String ingresar() //Metodo para ingresar datos de las tablas
        {
            String mensaje = "";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String sql = "INSERT INTO autores VALUES ('" + this.cedula + "','" + this.nombre_uno + "','" + this.nombre_dos + "','" + this.apellido_uno + "','" + this.apellido_dos + "','" + this.clave + "','" + this.correo_electronico + "'," + this.edad + ")";
                cmd = new NpgsqlCommand(sql, this.cone);
                cmd.ExecuteNonQuery();
                mensaje = "se ingreso con exito el autor.BIENVENIDO.";

            }
            catch (Exception E)
            {


                mensaje = "" + E;
            }
            return mensaje;
        }

        public String autenticar()//metodo para autenticar entrada al sistema de autores
        {
            String Mensaje = "";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();
                String sql = "select * from autores where cedula='" + this.cedula + "' and clave='" + this.clave + "'";


                var reader = new NpgsqlCommand(sql, this.cone).ExecuteReader();
                this.cedula = null;
                while (reader.Read())
                {
                    this.cedula = reader.GetString(0);
                    this.clave = reader.GetString(5);

                }
                reader.Close();
                if (this.cedula != null)
                {
                    return "si";
                }
                Mensaje = "Su cedula o clave son incorrectas, por favor intentelo nuevamente";
                return Mensaje;
            }
            catch (Exception E)

            {
                Mensaje = "Error" + E;
            }
            return Mensaje;
        }

    }

}
