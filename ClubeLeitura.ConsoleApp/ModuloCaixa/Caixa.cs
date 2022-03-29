namespace ClubeLeitura.ConsoleApp
{
    public class Caixa
    {
        private int _numero;
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _cor;
        public string Cor
        {
            get { return _cor; }
            set { _cor = value; }
        }

        private string _etiqueta;
        public string Etiqueta
        {
            get { return _etiqueta; }
            set { _etiqueta = value; }
        }
    }
}
