using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace revistaApi.Modelos
{
    public class Articulo
    {

        string cedula;
        string titulo_articulo;
        string descripcion_articulo;
        string fecha;
        string contenido_articulo;
        Boolean estado;
        NpgsqlConnection cone;

        public Articulo(string cedula, string titulo_articulo, string descripcion_articulo, string fecha, string contenido_articulo, bool estado)
        {

            this.cedula = cedula;
            this.titulo_articulo = titulo_articulo;
            this.descripcion_articulo = descripcion_articulo;
            this.fecha = fecha;
            this.contenido_articulo = contenido_articulo;
            this.estado = estado;
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

                String sql = "INSERT INTO articulos VALUES (default,'" + this.cedula + "','" + this.titulo_articulo + "','" + this.descripcion_articulo + "','" + this.fecha + "','" + this.contenido_articulo + "','" + this.estado + "')";
                cmd = new NpgsqlCommand(sql, this.cone);
                cmd.ExecuteNonQuery();
                mensaje = "Se ingreso con exito su articulo. Espero el mensaje de confirmanción de la publicación del mismo.GRACIAS.";

            }
            catch (Exception E)
            {


                mensaje = "" + E;
            }
            return mensaje;
        }
        public String borrar() //Metodo para borrar articulos
        {
            String mensaje = "";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand();

                String sql = "delete from articulos where cedula ='" + this.cedula + "' and titulo_articulo= '" + this.titulo_articulo + "';";
                cmd = new NpgsqlCommand(sql, this.cone);
                cmd.ExecuteNonQuery();
                mensaje = "Se elimino con exito su articulo.";

            }
            catch (Exception E)
            {


                mensaje = "" + E;
            }
            return mensaje;
        }
    }



}
