using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TP05.Models
{
    public class Wordle
    {
        public List<IntentoWordle> intentos { get; private set; }
        public string numeroElegido { get; private set; }
        public List<string> intentosAnteriores { get; private set; }

        public Wordle()
        {
            intentos = new List<IntentoWordle>();
            Random rnd = new Random();
            numeroElegido = rnd.Next(10000, 100000).ToString();
        }
        public void DevolverResultado(string intento)
        {
            Dictionary<string, int> resultado = new Dictionary<string, int>()
            {
                {"correctas", 0},
                {"incorrectas", 0},
                {"estan", 0}
            };

            for (int i = 0; i < intento.Count(); i++)
            {
                if (numeroElegido[i] == intento[i])
                {
                    resultado["correctas"]++;
                }
                else
                {
                    if (numeroElegido.Contains(intento[i]))
                    {
                        resultado["estan"]++;
                    }
                    else
                    {
                        resultado["incorrectas"]++;
                    }
                }
            }
            IntentoWordle nuevoIntento = new IntentoWordle(intento, resultado["correctas"], resultado["estan"], resultado["incorrectas"]);
            this.intentos.Add(nuevoIntento);
        }
    }
}