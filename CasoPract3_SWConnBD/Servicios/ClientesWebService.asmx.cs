using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Data;

namespace CasoPract3_SWConnBD
{

    /// <summary>
    /// Descripción breve de ClientesWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientesWebService : System.Web.Services.WebService
    {
        static string connString = "server=localhost;port=3306;user id=root;password=;database=pruebaws;";
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader = null;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod(Description = "Inserta Datos en la tabla Libro")]
        public string AddCliente(string nombre, string autor, string editorial, string pais, string fecha)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand("INSERT INTO libros(nombre, autor, editoria, pais, fecha) VALUES ('"+nombre+"','"+autor+"','"+editorial+"','"+pais+"','"+fecha+"');", conn);
                reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (MySqlException e)
            {
                return e.ToString();
            }
            return "true";
        }
        [WebMethod (Description ="Edita los datos de un Libro")]
        public string ModCliente(string idLibro, string nombre, string autor, string editorial, string pais, string fecha)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand("UPDATE libros SET nombre='" + nombre + "',autor='" + autor + "',editoria='" + editorial + "',pais='" + pais + "',fecha='" + fecha + "' WHERE idLibro='" + idLibro + "';", conn);
                reader = cmd.ExecuteReader();
                conn.Close();

            }
            catch(MySqlException e)
            {
                return e.ToString();
            }
            return "true";
        }
        [WebMethod(Description ="Elimina los datos de un Libro")]
        public string DellCliente(string idLibro)
        {
            try
            {
                conn.Open();
                cmd = new MySqlCommand("DELETE FROM libros WHERE idLibro='" + idLibro + "'", conn);
                reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch(MySqlException e)
            {
                return e.ToString();
            }
            return "true";
        }
    }
}
