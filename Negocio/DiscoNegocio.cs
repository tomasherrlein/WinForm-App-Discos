using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Dominio;


namespace Negocio
{
    public class DiscoNegocio
    {
        public List<Disco> Listar()
        {
            List<Disco> discos = new List<Disco>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, E.Descripcion AS Genero, D.UrlImagenTapa, T.Descripcion AS Edicion, D.IdEstilo, D.IdTipoEdicion FROM DISCOS D, ESTILOS E, TIPOSEDICION T WHERE D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];

                    if (!(lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagenTapa"];

                    aux.Estilo = new DatoDisco();
                    aux.Estilo.Id = (int)lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)lector["Genero"];
                    aux.Edicion = new DatoDisco();
                    aux.Edicion.Id = (int)lector["IdTipoEdicion"];
                    aux.Edicion.Descripcion = (string)lector["Edicion"];

                    discos.Add(aux);
                }

                conexion.Close();
                return discos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, IdEstilo, IdTipoEdicion, UrlImagenTapa) values (@titulo, @fechaLanzamiento, @cantidadCanciones, @idEstilo, @idTipoEdicion, @urlImagen)");
                datos.SetearParametro("@titulo", disco.Titulo);
                datos.SetearParametro("@fechaLanzamiento", disco.FechaLanzamiento);
                datos.SetearParametro("@cantidadCanciones", disco.CantidadCanciones);
                datos.SetearParametro("@idEstilo", disco.Estilo.Id);
                datos.SetearParametro("@idTipoEdicion", disco.Edicion.Id);
                datos.SetearParametro("@urlImagen", disco.UrlImagen);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fechaLanzamiento, CantidadCanciones = @cantidadCanciones, UrlImagenTapa = @urlImagen, IdEstilo = @idEstilo, IdTipoEdicion = @idTipoEdicion where Id = @id");
                datos.SetearParametro("@titulo", disco.Titulo);
                datos.SetearParametro("@fechaLanzamiento", disco.FechaLanzamiento);
                datos.SetearParametro("@cantidadCanciones", disco.CantidadCanciones);
                datos.SetearParametro("@idEstilo", disco.Estilo.Id);
                datos.SetearParametro("@idTipoEdicion", disco.Edicion.Id);
                datos.SetearParametro("@urlImagen", disco.UrlImagen);
                datos.SetearParametro("@id", disco.Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
