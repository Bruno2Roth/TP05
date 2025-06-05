using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP05.Models
{
    public class Escape
    {
        public Dictionary<int, string> respuestas { get; private set; }
        public Dictionary<int, string> pistas { get; private set; }

        public int[] secuencias { get; private set; }
        public int salaActual { get; private set; }
        public string nombreJugador { get; private set; }

        public Escape(string nJ)
        {
            this.respuestas = new Dictionary<int, string>{{1, ""}, {2, ""}, {3, ""}, {4, ""}, {5, ""}};
            this.pistas = new Dictionary<int, string>{{1, ""}, {2, ""}, {3, ""}, {4, ""}, {5, ""}};
            this.secuencias = new int[] {8, 20, 30, 40, 50}; //Fibonacci, primos, multiplos de 3, cuadrados, factoriales
            this.salaActual = 0;
            this.nombreJugador = nJ;
        }
        public bool ValidarContraseña(string intento)
        {
            return intento == respuestas[salaActual];
        }
    }
}
