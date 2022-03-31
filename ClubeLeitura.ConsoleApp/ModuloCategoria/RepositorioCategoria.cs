using ClubeLeitura.ConsoleApp.Compartilhado;

namespace ClubeLeitura.ConsoleApp.ModuloCategoria
{
    public class RepositorioCategoria : IRepositorio<Categoria>
    {
        private readonly Categoria[] categorias;
        private int numeroCategoria;

        public RepositorioCategoria(int qtdCategorias)
        {
            categorias = new Categoria[qtdCategorias];
        }

        public void Inserir(Categoria categoria)
        {
            categoria.numero = ++numeroCategoria;

            int posicaoVazia = ObterPosicaoVazia();

            categorias[posicaoVazia] = categoria;
        }

        public void Editar(int numeroSelecionado, Categoria categoria)
        {
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i].numero == numeroSelecionado)
                {
                    categoria.numero = numeroSelecionado;
                    categorias[i] = categoria;

                    break;
                }
            }
        }

        public void Excluir(int numeroSelecionado)
        {
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i].numero == numeroSelecionado)
                {
                    categorias[i] = null;
                    break;
                }
            }
        }

        public Categoria[] ObterTodosRegistros()
        {
            int quantidadeCategorias = ObterQuantidadeRegistros();

            Categoria[] categoriasInseridas = new Categoria[quantidadeCategorias];

            int j = 0;

            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null)
                {
                    categoriasInseridas[j] = categorias[i];
                    j++;
                }
            }

            return categoriasInseridas;
        }

        public Categoria SelecionarCategoria(int numeroCategoria)
        {
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null && numeroCategoria == categorias[i].numero)
                    return categorias[i];
            }

            return null;
        }

        public bool ExisteNumeroRegistro(int numero)
        {
            bool numeroRevistaEncontrado = false;

            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null && categorias[i].numero == numeroCategoria)
                {
                    numeroRevistaEncontrado = true;
                    break;
                }
            }

            return numeroRevistaEncontrado;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] == null)
                    return i;
            }

            return -1;
        }

        public int ObterQuantidadeRegistros()
        {
            int numeroCategorias = 0;

            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null)
                    numeroCategorias++;
            }

            return numeroCategorias;
        }      

        public Categoria ObterRegistro(int numero)
        {
            for (int i = 0; i < categorias.Length; i++)
            {
                if (categorias[i] != null && numeroCategoria == categorias[i].numero)
                    return categorias[i];
            }

            return null;
        }             
                
        public int ObterNumeroRegistro()
        {
            return ++numeroCategoria;
        }
    }
}
