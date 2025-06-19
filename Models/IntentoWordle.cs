using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP05.Models
{
    public class IntentoWordle
    {
        public string intento { get; private set; }
        public int correctas { get; private set; }
        public int estan { get; private set; }
        public int incorrectas { get; private set; }
        public IntentoWordle(string i, int c, int e, int inc)
        {
            this.intento = i;
            this.correctas = c;
            this.estan = e;
            this.incorrectas = inc;
        }
    }
}