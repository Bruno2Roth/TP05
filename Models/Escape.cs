using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP05.Models
{
    public class Escape
    {
        [JsonProperty]
        public List<string> qrs { get; private set; }
        [JsonProperty]
        public Dictionary<int, string> respuestas { get; private set; }
        [JsonProperty]
        public Dictionary<int, string> pistas { get; private set; }
        [JsonProperty]
        public string[] secuencias { get; private set; }
        [JsonProperty]
        public bool[] SecuenciasAdivinadas { get; set; }
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
            this.qrs = new List<string> { "~/archivos/malisimo1.png", "~/archivos/malisimo2.png", "~/archivos/malisimo3.png", "~/archivos/malisimo4.png", "~/archivos/malisimo5.png", "~/archivos/malisimo6.png", "~/archivos/yendo.png", "~/archivos/malisimo8.png", "~/archivos/malisimo9.png" };
            this.respuestas = new Dictionary<int, string>{{1, "cable"}, {2, "a"}, {3, "1014"}, {4, "c"}, {5, "escapedone"}};
            this.pistas = new Dictionary<int, string>{{1, "Los números guardan secretos que hablan, cada cifra ingresada es un paso en el abecedario. Descifren su mensaje y encontrarán la palabra."}, {3, "Las cámaras no solo observan... esconden fragmentos del misterio. Fijen su mirada en las imágenes que cruzan rápido, pues allí está la suma que les falta."},
             {5, "No todos los caminos llevan a la salida... pero uno sí."}};
            this.secuencias = new string[] {"3", "1", "2", "12", "5"};
            this.SecuenciasAdivinadas = new bool[] {false, false, false, false, false};
            this.salaActual = 1;
            this.nombreJugador = nJ;
            this.wordle = new Wordle();
            this.simon = new Simon();
        }
        public bool Validar(string intento, string correcto)
        {
            return intento == correcto;
        }
        public void IntentarSecuencia(int indice, string intento)
        {
            if (intento == secuencias[indice])
            {
                SecuenciasAdivinadas[indice] = true;
            }
        }
        public bool Contraseña(string intento)
        {
            bool correcto = intento == respuestas[salaActual];
            if (correcto)
            {
                SumarSala();
            }
            return correcto;
        }
        public void SumarSala()
        {
            salaActual++;
        }
        public void ReiniciarWordle()
        {
            this.wordle = new Wordle();
        }
    }
}
