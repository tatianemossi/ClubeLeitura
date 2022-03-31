using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista : IRepositorio<Revista>
    {
        private int numeroRevista;
        private readonly Revista[] revistas;

        public RepositorioRevista(int qtdRevistas)
        {
            revistas = new Revista[qtdRevistas];
        }

        public string Inserir(Revista revista)
        {
            string validacao = revista.Validar();

            if (validacao != "REGISTRO_VALIDO")
                return validacao;

            revista.numero = ++numeroRevista;

            int posicaoVazia = ObterPosicaoVazia();

            revistas[posicaoVazia] = revista;

            return validacao;
        }

        public void Editar(int numeroSelecionado, Revista revista)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i].numero == numeroSelecionado)
                {
                    revista.numero = numeroSelecionado;
                    revistas[i] = revista;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i].numero == numeroSelecionado)
                {
                    revistas[i] = null;
                    break;
                }
            }
        }

        public Revista[] ObterTodosRegistros()
        {
            int quantidadeRevistas = ObterQuantidadeRegistros();

            Revista[] revistasInseridas = new Revista[quantidadeRevistas];

            int j = 0;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    revistasInseridas[j] = revistas[i];
                    j++;
                }
            }

            return revistasInseridas;
        }

        public Revista ObterRegistro(int numero)
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && numeroRevista == revistas[i].numero)
                    return revistas[i];
            }

            return null;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            bool numeroRevistaEncontrado = false;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null && revistas[i].numero == numeroRevista)
                {
                    numeroRevistaEncontrado = true;
                    break;
                }
            }

            return numeroRevistaEncontrado;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroRevistas = 0;

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                    numeroRevistas++;
            }

            return numeroRevistas;
        }
        
        public int ObterNumeroRegistro()
        {
            return ++numeroRevista;
        }

        void IRepositorio<Revista>.Inserir(Revista item)
        {
            throw new System.NotImplementedException();
        }
    }
}