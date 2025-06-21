using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace TP05.Models
{
    public class Persona
    {
        [JsonProperty]
        public string nombre { get; private set; }
        [JsonProperty]
        public string rol { get; private set; }
        [JsonProperty]
        public string foto { get; private set; }
        public Persona(string n, string r, string f)
        {
            this.nombre = n;
            this.rol = r;
            this.foto = f;
        }
    }
}