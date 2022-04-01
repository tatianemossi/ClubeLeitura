using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista : RepositorioBase<Revista>
    {
        private int numeroRevista;
        private readonly Revista[] revistas;

        public RepositorioRevista(int qtdRevistas)
        {
            revistas = new Revista[qtdRevistas];
        }

        public string InserirRevista(Revista revista)
        {
            string validacao = revista.Validar();

            if (validacao != "REGISTRO_VALIDO")
                return validacao;

            revista.numero = ++numeroRevista;

            int posicaoVazia = ObterPosicaoVazia();

            revistas[posicaoVazia] = revista;

            return validacao;
        }
        
    }
}