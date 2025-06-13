namespace TP05.Models
{
    public class Simon
    {
        public List<char> respuestas { get; private set; }
        public int contador { get; private set; }
        public int meta { get; private set; }
        public char[] colores { get; private set; }

        public Simon()
        {
            this.colores = new char[] { 'R', 'G', 'B', 'Y' };
            this.respuestas = generarSecuencia();
            this.contador = 0;
            this.meta = 10;
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
            }
            return correcto;
        }
    }
}
