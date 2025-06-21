using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace TP05.Models
{
    public class Simon
    {
        [JsonProperty]
        public List<char> respuestas { get; private set; }
        [JsonProperty]
        public int contador { get; private set; }
        [JsonProperty]
        public int meta { get; private set; }
        [JsonProperty]
        public char[] colores { get; private set; }

        public Simon()
        {
            this.colores = new char[] { 'R', 'G', 'B', 'Y' };
            this.contador = 1;
            this.meta = 10;
            this.respuestas = generarSecuencia();
        }
        public List<char> generarSecuencia()
        {
            List<char> secuencia = new List<char>();
            Random r = new Random();
            for (int i = 0; i < meta; i++)
            {
                secuencia.Add(colores[r.Next(colores.Length)]);
            }
            return secuencia;
        }
        public bool ValidarContraseña(string intento)
        {
            bool correcto = false;
            string bien = "";
            foreach (char c in this.respuestas)
            {
                bien = bien + c;
            }
            if(intento == bien)
            {
                correcto = true;
                contador++;
            }else
            {
                contador = 1;
            }
            return correcto;
        }
    }
}
