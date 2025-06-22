using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace TP05.Models
{
    public class SecuenciaSala1
    {
        [JsonProperty]
        public List<string> secuencia { get; private set; }
        [JsonProperty]
        public int indiceRespuesta { get; private set; }
        public SecuenciaSala1(List<string> s, int i)
        {
            this.secuencia = s;
            this.indiceRespuesta = i;
        }
    }
}