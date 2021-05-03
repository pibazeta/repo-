using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {


        public int Id { get; set; }
        public string Descripcion { get; set; }


        public Marca(string descripcion) //sirve de constructor para el lector
        {
            Descripcion = descripcion;


        }

        public Marca(int id, string descripcion) //para el constructor de lectura en MarcaNegocio.cs
        {
            Id = id;
            Descripcion = descripcion;

        }



        public override string ToString()
        {
            return Descripcion;
        }

    }
}
