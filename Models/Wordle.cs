using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TP05.Models
{
    public class Wordle
    {
        public int intentos { get; private set; }
        public string numeroElegido { get; private set; }
        public Wordle()
        {
            intentos = 0;
            Random rnd = new Random();
            numeroElegido = rnd.Next(10000, 100000).ToString();
        }
        public Dictionary<string, int> DevolverResultado(string intento)
        {
        Dictionary<string, int> resultado = new Dictionary<string, int>()
        {
            {"correctas", 0},
            {"incorrectas", 0},
            {"estan", 0}
        };
            foreach (char c in intento)
            {
                if (intento.Contains(c))
                {
                    if(intento.IndexOf(c) ==)
                    {

                    }
                }else
                {
                    resultado["incorrectas"]++;
                }
            }
        }
    }
}