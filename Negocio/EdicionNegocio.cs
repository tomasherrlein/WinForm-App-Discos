﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EdicionNegocio
    {
        List<DatoDisco> lista = new List<DatoDisco>();
        AccesoDatos datos = new AccesoDatos();

        public List<DatoDisco> Listar()
        {
            try
            {
                datos.SetearConsulta("Select Id, Descripcion from TIPOSEDICION");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    DatoDisco aux = new DatoDisco();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
    }
}
