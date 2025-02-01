using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ejemplo_ado_net
{
    internal class DiscoNegocio
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
                comando.CommandText = "Select D.Id, D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, E.Descripcion Genero, D.UrlImagenTapa, T.Descripcion Edicion from DISCOS D, ESTILOS E, TIPOSEDICION T where IdEstilo = E.Id AND T.Id = D.Id";
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
                    aux.UrlImagen = (string)lector["UrlImagenTapa"];
                    aux.Estilo = new DatoDisco();
                    aux.Estilo.Descripcion = (string)lector["Genero"];
                    aux.Edicion = new DatoDisco();
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
    }
}
