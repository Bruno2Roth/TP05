using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP05.Models
{
    public class Escape
    {
        public Dictionary<int, string> respuestas { get; private set; }
        public int salaActual { get; private set; }
        public string nombreJugador { get; private set; }
        public Escape(string nJ)
        {
            this.respuestas = new Dictionary<int, string>{{1, ""}, {2, ""}, {2, ""}, {2, ""}, {2, ""}};
            this.salaActual = 0;
            this.nombreJugador = nJ;
        }
    }
}
