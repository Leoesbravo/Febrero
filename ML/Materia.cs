using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; } //va a permitr valores nulos 
        public int IdSemestre { get; set; } //va a permitr valores nulos 
        public string Nombre { get; set; }
        public byte Creditos { get; set; }
        public decimal Costo { get; set; }

        //propiedad de navegacion
    }
}
