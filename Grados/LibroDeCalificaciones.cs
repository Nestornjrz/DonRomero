using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grados
{
    public class LibroDeCalificaciones
    {
        #region constructores
        public LibroDeCalificaciones ()
            : this ("Sin nombre")
        {
            Apellido = "hhhh";
        }
        public LibroDeCalificaciones(string nombre)
        {
            _nombre = nombre;
            this.calificaciones = new List<float>();
        }
        #endregion
        #region metodos
        /// <summary>
        /// Este metodo permite agregar las calificaciones de los alumnos/as
        /// </summary>
        /// <param name="calificacion">Es la calificacion individual a agregar</param>
        public void AddCalificacion(float calificacion)
        {
            if (calificacion >= 0 && calificacion <= 100)
            {
                calificaciones.Add(calificacion);
            }

        }
        public Estadisticas GenerarEstadistica()
        {
            Estadisticas estadisticas = new Estadisticas();
            float suma = 0f;

            foreach (var calificacion in calificaciones)
            {
                estadisticas.NotaMasAlta = Math.Max(calificacion, estadisticas.NotaMasAlta);
                estadisticas.NotaMasBaja = Math.Min(calificacion, estadisticas.NotaMasBaja);
                var l = (float)Math.Round(calificacion, 1);
                suma += calificacion;
            }

            estadisticas.Promedio = suma / calificaciones.Count;
            return estadisticas;
        }
        #endregion
        #region campos estaticos
        public static float MinimaCalificacion = 0;
        public static float MaximaCalificacion = 100;
        #endregion
        #region campos
        private List<float> calificaciones;

        private string _nombre;
        public string Apellido { private get;  set; }
        #endregion
        public string Nombre
        {
            get { return "pepito"; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("El nombre no puede ser nulo o vacio");
                }
                if (!string.IsNullOrEmpty(value))
                {
                    var nombreViejo= _nombre;
                    _nombre = value;
                    if (NombreCambio !=null)
                    {
                        NombreCambio(nombreViejo, value);     
                    }
                   
                }
            }
        }
        
        public event NombreCambioDelegado NombreCambio;
        /// <summary>
        /// Escribe uno por uno las calificaciones probando del derecho y del reves
        /// </summary>
        /// <param name="textWriter">Es la instancia de la clase TextWriter para poder escribir</param>
        public void EscribirCalificaciones(TextWriter textWriter)
        {
            textWriter.WriteLine("calificaciones");
            foreach (float calificacion in calificaciones)
            {
                textWriter.WriteLine(calificacion);
            }
            textWriter.WriteLine("*************");

            for (int i = calificaciones.Count-1; i >= 0; i--)
            {
                textWriter.WriteLine(calificaciones[i]);
            }

            for (int i = 0; i < calificaciones.Count; i++)
            {
                textWriter.WriteLine(calificaciones[i]);
            }
            textWriter.WriteLine("Calificaciones: Mediante While");
            int x = 0;
            while (x < calificaciones.Count)
            {
                textWriter.WriteLine(calificaciones[x]);
                x++;
            }
            textWriter.WriteLine("*************");
            textWriter.WriteLine("Calificaciones: Mediante do While");
            x = 0;
            do
            {
                textWriter.WriteLine(calificaciones[x]);
                x++;
            }while (x < calificaciones.Count);
             textWriter.WriteLine("*************");
        }
    }
}
