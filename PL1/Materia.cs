using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL1
{
    public class Materia
    {
        public static void Add()
        {
            ML.Materia materia = new ML.Materia(); //instancia de una clase

            Console.WriteLine("Ingrese el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese los creditos de la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct == true)
            {
                Console.WriteLine("Se ha agregado el registro");
            }
            else
            {
                Console.WriteLine("No se ha podido agregar el registro debido a: " + result.ErrorMessage);
            }
            Console.ReadKey();
        }
    }
}
