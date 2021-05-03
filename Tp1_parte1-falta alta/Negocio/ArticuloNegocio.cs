using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {


        public List<Articulo> listar()
        {

            ////select Nombre, P.Descripcion, UrlImagen, T.Descripcion Tipo, D.Descripcion Debilidad from POKEMONS P, ELEMENTOS T, ELEMENTOS D Where P.IdTipo = T.Id and P.IdDebilidad = D.Id


            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();


            try
            {

                datos.setearConsulta("select  A.Codigo CodigoArticulo , Nombre , A.Descripcion Descripcion  , M.Descripcion marca ,C.Descripcion categoria, A.ImagenUrl UrlImagen , A.Precio Precio from ARTICULOS A ,MARCAS M ,CATEGORIAS C WHERE A.IdMarca = M.Id and A.IdCategoria = C.Id");
                datos.ejecutarLectura();



                while (datos.Lector.Read())
                {

                    Articulo aux = new Articulo();
                    aux.CodigoArticulo = (string)datos.Lector["CodigoArticulo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.marca = new Marca((string)(datos.Lector["marca"]));

                    aux.categoria = new Categoria((string)(datos.Lector["categoria"]));

                    aux.UrlImagen = (string)datos.Lector["UrlImagen"];

                    aux.Precio = (decimal)datos.Lector["Precio"];
         




                    lista.Add(aux);




                }

                return lista; ///fundamental para devolver la lista (si no se pone el listar2 no anda)

            }

            catch (Exception ex)
            {

                throw ex;
            }

            ///Bloque de excepciones
            finally
            {
                datos.cerrarConexion();
            }

        }//Fin listar3()


        public void agregar(Articulo nuevo)
        {



            AccesoDatos datos = new AccesoDatos();

            try
            {


                string valores = "values(" + nuevo.CodigoArticulo + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', " + nuevo.marca.Id + ", " + nuevo.categoria.Id + ", '" + nuevo.UrlImagen + "', "+nuevo.Precio +" )";
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo , Nombre, Descripcion, IdMarca, IdCategoria,ImagenUrl,Precio)" + valores);


                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                
                datos.cerrarConexion();
            }





        }//fin agregar








    }
}
