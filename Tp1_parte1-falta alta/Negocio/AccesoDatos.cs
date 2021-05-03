using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace Negocio
{
     class AccesoDatos
    {


        //Atributo privado del tipo conexion
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //contructor

        public AccesoDatos()
        {

            conexion = new SqlConnection("data source =.\\SQLEXPRESS; initial catalog = CATALOGO_DB; integrated security = sspi");
            comando = new SqlCommand();



        }


        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            ///comando.CommandText = "select Numero, Nombre, P.Descripcion, UrlImagen, T.Descripcion Tipo, D.Descripcion Debilidad from POKEMONS P, ELEMENTOS T, ELEMENTOS D Where P.IdTipo = T.Id and P.IdDebilidad = D.Id";
            comando.CommandText = consulta;

        }

        public void ejecutarLectura()
        {

            //esto es todo privado,manejo todo interno
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        //Propiedad para hacer la lectura

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        internal void ejecutarAccion()
        {
            comando.Connection = conexion;
            conexion.Open();
            comando.ExecuteNonQuery();
        }


    }
}
