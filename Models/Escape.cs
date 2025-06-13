using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP05.Models
{
    public class Escape
    {
        [JsonProperty]
        public Dictionary<int, string> respuestas { get; private set; }
        [JsonProperty]
        public Dictionary<int, string> pistas { get; private set; }
        [JsonProperty]
        public string[] secuencias { get; private set; }
        [JsonProperty]
        public int salaActual { get; private set; }
        [JsonProperty]
        public string nombreJugador { get; private set; }
        [JsonProperty]
        public Wordle wordle { get; private set; }
        [JsonProperty]
        public Simon simon { get; private set; }

        public Escape(string nJ)
        {
            this.respuestas = new Dictionary<int, string>{{1, "m"}, {2, "a"}, {3, "b"}, {4, "c"}, {5, "d"}};
            this.pistas = new Dictionary<int, string>{{1, ""}, {2, ""}, {3, ""}, {4, ""}, {5, ""}};
            this.secuencias = new string[] {"8", "20", "30", "40", "50"}; //Fibonacci, primos, multiplos de 3, cuadrados, factoriales
            this.salaActual = 1;
            this.nombreJugador = nJ;
            this.wordle = new Wordle();
            this.simon = new Simon();
        }
        public bool Validar(string intento, string correcto)
        {
            return intento == correcto;
        }
        public bool Contraseña(string intento)
        {
            bool correcto = intento == respuestas[salaActual];
            if(correcto)
            {
                SumarSala();
            }
            return correcto;

        }
        public void SumarSala()
        {
            salaActual++;
        }

    }
}
