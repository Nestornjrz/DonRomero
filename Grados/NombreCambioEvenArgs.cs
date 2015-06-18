using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grados
{
   public class NombreCambioEvenArgs:EventArgs
    {
        public string ViejoValor { get; set; }
        public string NuevoValor { get; set; }
    }
}
