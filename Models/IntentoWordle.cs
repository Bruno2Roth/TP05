using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP05.Models
{
    public class IntentoWordle
    {
        [JsonProperty]
        public string intento { get; private set; }
        [JsonProperty]
        public int correctas { get; private set; }
        [JsonProperty]
        public int estan { get; private set; }
        [JsonProperty]
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