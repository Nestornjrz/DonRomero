using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;
namespace Grados
{
    class Program
    {
        static void Main(string[] args)
        {
            LibroDeCalificaciones libro = new LibroDeCalificaciones();
            //libro.AddCalificacion(97f);
            //libro.AddCalificacion(89.5f);
            //libro.AddCalificacion(75);
            try
            {
                string[] lineas = File.ReadAllLines("Calificaciones.txt");
            
                foreach (var elem in lineas)
                {
                    float calificacion = float.Parse(elem);
                    libro.AddCalificacion(calificacion);
                }

            }
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine("Detalle del error {0}{1}", ex.Message, ". Oprima Enter para continuar");
            //    Console.ReadKey();
            //    return;
            //}

            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Archivo no encontrado");
                Console.WriteLine("Detalle del error {0}{1}", ex.Message, ". Oprima Enter para continuar");
              //  Console.WriteLine("Oprima Enter para continuar");
                Console.ReadKey();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR no especificado");
                Console.WriteLine("Detalle del error {0}{1}", ex.Message, ". Oprima Enter para continuar");
                //  Console.WriteLine("Oprima Enter para continuar");
                Console.ReadKey();
                return;
            }
            libro.EscribirCalificaciones(Console.Out);
            Estadisticas est = libro.GenerarEstadistica();

            ////libro.NombreCambio += new NombreCambioDelegado(OnNombreCambio);
            ////libro.NombreCambio += OnNombreCambio;
            ////libro.NombreCambio += OnNombreCambio;
            ////libro.NombreCambio += OnNombreCambio2;
            ////libro.NombreCambio -= OnNombreCambio;
            try
            {
                Console.WriteLine("Por favor inserte el nombre para el libro");
                libro.Nombre = "";

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Nombre invalido");
            }
            Console.WriteLine("Nota mas alta" + est.NotaMasAlta);
            Console.WriteLine("Nota mas baja" + est.NotaMasBaja);
            Console.WriteLine("Promedio" + est.Promedio);
            //Console.WriteLine("calificacion final {0}", est.LetraCalificacionFinal);
            //int i= 3;           

            //BreakYContinue();
            //ProbandoGoto();
            ProbandoReturn();
        }

        #region metodos de program
        private static void ProbandoReturn()
        {
            int[] array1 = { 0, 1, 2, 3, 4, 5 };
            foreach (int n in array1)
            {
                if (n == 4) return;
                Console.WriteLine(n);
            }
        }
        static void RecuperarNombre(ref LibroDeCalificaciones libro)
        {
            libro = new LibroDeCalificaciones();
            libro.Nombre = "El libro de calificaciones";
        }
        static void IncrementarNumero(out int numero)
        {
            numero = 1;
        }


        private static void ProbandoGoto()
        {
            Console.WriteLine("Cafe: 1=Pequeño 2=Mediano 3=Grande");
            Console.WriteLine("Por favor selecciones el tamaño: ");
            string s = Console.ReadLine();
            int n = int.Parse(s);
            int costo = 0;
            switch (n)
            {
                case 1:
                    costo += 25;
                    break;
                case 2:
                    costo += 25;
                    goto case 1;
                case 3:
                    costo += 50;
                    goto case 1;
                default:
                    Console.WriteLine("Seleccion invalida");
                    break;
            }
            if (costo != 0)
            {
                Console.WriteLine("Por favor inserte {0} {1}. ", costo, "gs");
            }
            Console.WriteLine("Gracias por su compra");
            // Keep the console open in debug mode
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        private static void BreakYContinue()
        {
            Console.WriteLine("Probando brak");
            for (int i = 0; i <= 100; i++)
            {
                if (i == 5)
                {
                    break;
                }
                Console.WriteLine(i);
            }
            Console.WriteLine("Presione una tecla para salir.");
            Console.ReadKey();

            Console.WriteLine("Probando continue");
            for (int i = 1; i <= 10; i++)
            {
                if (i < 9)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
            Console.WriteLine("Presione una tecla para salir.");
            Console.ReadKey();
        }

        private static void OnNombreCambio2(string viejoValor, string nuevoValor)
        {
            Console.WriteLine("*****OnNombreCambio2****");
        }

        private static void OnNombreCambio(string viejoValor, string nuevoValor)
        {
            Console.WriteLine("El nombre cambio");
            Console.WriteLine("viejo valor {0} nuevo valor{1}", viejoValor, nuevoValor);
        }

        private static void EscribirNombres(params string[] nombres)
        {
            foreach (string nombre in nombres)
            {
                Console.WriteLine(nombre);
            }
        }
        private static void EscribirBytes(float nota)
        {
            byte[] bytes = BitConverter.GetBytes(nota);
            EscribirBytesArray(bytes);
        }

        private static void EscribirBytesArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0x{0:X} ", b);
            }
        }
        private static void EscribirBytes(int nota)
        {
            byte[] bytes = BitConverter.GetBytes(nota);
            EscribirBytesArray(bytes);
        }

        private static void sintetizador()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.SelectVoiceByHints(VoiceGender.Neutral);
            synth.Speak("Hola Nestor");
            synth.Speak("Mbaé tecó picó");
            synth.Speak("Emeé sheve nde factura");
            Arrays();
        }

        private static void Arrays()
        {
            float[] calificaciones;
            calificaciones = new float[3];
            AddCalificaciones(calificaciones);
            foreach (float calificacion in calificaciones)
            {
                Console.WriteLine(calificacion);
            }
        }

        private static void AddCalificaciones(float[] calificaciones)
        {
            calificaciones[0] = 91f;
            calificaciones[1] = 89.1f;
            calificaciones[2] = 75f;
        }

        private static void Inmutavilidad()
        {
            string nombre = " Nestor";
            nombre = nombre.Trim();
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddHours(25);
            Console.WriteLine(date);
            Console.WriteLine(nombre);

        }

        private static void PasoPorValorYPasoPorReferencia()
        {
            LibroDeCalificaciones e1 = new LibroDeCalificaciones();
            LibroDeCalificaciones e2 = e1;

            Program.RecuperarNombre(ref e2);

            Console.WriteLine(e2.Nombre);

            int x1;
            Program.IncrementarNumero(out x1);
            Console.WriteLine(x1);
            Console.ReadKey();
        }

        #endregion
    }
}

