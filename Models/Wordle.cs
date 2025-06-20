using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace TP05.Models
{
    public class Wordle
    {
        [JsonProperty]
        public List<IntentoWordle> intentos { get; private set; }
        [JsonProperty]
        public string numeroElegido { get; private set; }

        public Wordle()
        {
            intentos = new List<IntentoWordle>();
            Random rnd = new Random();
            numeroElegido = rnd.Next(10000, 100000).ToString();
        }
        public void DevolverResultado(string intento)
        {
            Dictionary<char, int> letrasRestantes = new Dictionary<char, int>();
            foreach (char c in numeroElegido)
            {
                if (letrasRestantes.ContainsKey(c))
                    letrasRestantes[c]++;
                else
                    letrasRestantes[c] = 1;
            }

            int correctas = 0;
            int estan = 0;
            int incorrectas = 0;

            for (int i = 0; i < intento.Length; i++)
            {
                if (numeroElegido[i] == intento[i])
                {
                    correctas++;
                    letrasRestantes[intento[i]]--;
                }
            }
            for (int i = 0; i < intento.Length; i++)
            {
                if (numeroElegido[i] != intento[i])
                {
                    char letra = intento[i];
                    if (letrasRestantes.ContainsKey(letra) && letrasRestantes[letra] > 0)
                    {
                        estan++;
                        letrasRestantes[letra]--;
                    }
                    else
                    {
                        incorrectas++;
                    }
                }
            }
            IntentoWordle nuevoIntento = new IntentoWordle(intento, correctas, estan, incorrectas);
            this.intentos.Add(nuevoIntento);
        }

    }
}