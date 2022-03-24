using System.Web.Services;
using MySql.Data.MySqlClient;

namespace CasoPract3_SWConnBD
{

    /// <summary>
    /// Descripción breve de ClientesWebService
    /// CRUD de libros a travez de un servcicio web-SOAP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientesWebService : System.Web.Services.WebService
    {
        #region conexion
        static string connString = "server=localhost;port=3306;user id=root;password=;database=pruebaws;";
        MySqlConnection conn = new MySqlConnection(connString);
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader reader = null;
        #endregion
        /*
         * 
         * CRUD de usuarios.
         * 
         * 
         * */
        [WebMethod(Description = "Inserta un registro en la tabla Libros")]
        public string AddLibro(string nombre, string autor, string editorial, string pais, string fecha)
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
        [WebMethod (Description ="Edita un registro de la tabla Libros")]
        public string ModLibro(string idLibro, string nombre, string autor, string editorial, string pais, string fecha)
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
                return "error! " + e.ToString();
            }
            return "true";
        }
        [WebMethod(Description ="Elimina un registro de la tabla Libros")]
        public string DellLibro(string idLibro)
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
