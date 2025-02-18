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
                comando.CommandText = "SELECT D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, E.Descripcion AS Genero, D.UrlImagenTapa, T.Descripcion AS Edicion, D.IdEstilo, D.IdTipoEdicion FROM DISCOS D, ESTILOS E, TIPOSEDICION T WHERE D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id AND Activo = 1";
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

        public void EliminarFisico(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("delete from DISCOS where id = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarLogico(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("update DISCOS set Activo = 0 where Id = @id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Disco> Filtrar(string campo, string criterio, string filtro)
        {
            List<Disco> discos = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, E.Descripcion AS Genero, D.UrlImagenTapa, T.Descripcion AS Edicion, D.IdEstilo, D.IdTipoEdicion FROM DISCOS D, ESTILOS E, TIPOSEDICION T WHERE D.IdEstilo = E.Id AND D.IdTipoEdicion = T.Id AND Activo = 1 AND ";

                switch (campo)
                {
                    case "Titulo":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "D.Titulo LIKE @filtro";
                                break;
                            case "Termina con":
                                consulta += "D.Titulo LIKE @filtro";
                                break;
                            case "Contiene":
                                consulta += "D.Titulo LIKE @filtro";
                                break;
                        }
                        break;

                    case "Estilo":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Genero LIKE @filtro";
                                break;
                            case "Termina con":
                                consulta += "Genero LIKE @filtro";
                                break;
                            case "Contiene":
                                consulta += "Genero LIKE @filtro";
                                break;
                        }
                        break;

                    case "Edicion":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Edicion LIKE @filtro";
                                break;
                            case "Termina con":
                                consulta += "Edicion LIKE @filtro";
                                break;
                            case "Contiene":
                                consulta += "Edicion LIKE @filtro";
                                break;
                        }
                        break;
                    case "Cantidad de canciones":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "D.CantidadCanciones > @filtro";
                                break;
                            case "Menor a":
                                consulta += "D.CantidadCanciones < @filtro";
                                break;
                            case "Igual a":
                                consulta += "D.CantidadCanciones = @filtro";
                                break;
                        }
                        break;
                }

                datos.SetearConsulta(consulta);
                datos.SetearParametro("@filtro", filtro);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];

                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagenTapa"];

                    aux.Estilo = new DatoDisco();
                    aux.Estilo.Id = (int)datos.Lector["IdEstilo"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Genero"];
                    aux.Edicion = new DatoDisco();
                    aux.Edicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    aux.Edicion.Descripcion = (string)datos.Lector["Edicion"];

                    discos.Add(aux);
                }

                datos.CerrarConexion();

                return discos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
