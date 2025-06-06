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
            this.respuestas = generarSecuencia();
            this.contador = 0;
            this.colores = new char[] { 'R', 'G', 'B', 'Y' };
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
        public bool ValidarContraseña(char intento)
        {
            bool correcto;
            if(intento == respuestas[contador]){
                correcto = true;
                contador++;
            }
            else{
                correcto = false;
                contador = 0;
            }
            return correcto;
        }
    }
}
