using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grados
{
    public class Estadisticas
    {
        public Estadisticas()
        {
            NotaMasAlta = 0;
            NotaMasBaja = float.MaxValue;//el maximo valor posible para float 
        }
        public float Promedio;
        public float NotaMasAlta;
        public float NotaMasBaja;
        public string CalificacionFinal
        {
            get
            {
                string resultado;
                if (Promedio >= 90)
                { resultado = "Excelente"; }
                else if (Promedio >= 80)
                {
                    resultado = "Muy Buena";
                }
                else if (Promedio >= 70)
                {
                    resultado = "Buena";
                }
                else if (Promedio >= 60)
                {
                    resultado = "Aceptable";
                }
                else
                {
                    resultado = "Insuficiente";
                }
                int[] array1 = { 0, 1, 2, 3, 4, 5 };
                foreach (int n in array1)
                {
                    Console.WriteLine(n);
                }
                int x = 0;
                while (x<6)
                {
                    Console.WriteLine();
                }
                return resultado;
            }
        }
        public string LetraCalificacionFinal
        {
            get
            {
                char resultado;
                var variable = CalificacionFinal;
                switch (variable)
                {
                    case "Excelente":
                        resultado = 'E';
                        break;
                    case "Muy Buena":
                        resultado = 'M';
                        break;
                    case "Bueno":
                        resultado = 'B';
                        break;
                    case "Aceptable":
                        resultado = 'A';
                        break;
                    default:
                        resultado = 'T';
                        break;
                }
                return resultado.ToString();
            }
        }
    }
}
